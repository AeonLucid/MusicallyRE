import queue
import threading
from threading import Thread

import frida


class Android:

    def __init__(self):
        self.queue = queue.PriorityQueue()
        self.results = dict()
        self.thread = None
        self.wait_flag = threading.Event()

        with open('android.js') as jscode_file:
            script_code = jscode_file.read()

        device = frida.get_usb_device()
        process = device.attach('com.zhiliaoapp.musically')
        self.script = process.create_script(script_code)
        self.script.on('message', self._on_message)
        self.script.load()

    def start(self):
        if self.thread is not None:
            raise Exception('Android has already been started.')

        self.thread = Thread(target=self._processor)
        self.thread.daemon = True
        self.thread.start()

    def add_to_queue(self, priority, finished_flag, request_info):
        if priority:
            self.queue.put((1, finished_flag, request_info))
        else:
            self.queue.put((10, finished_flag, request_info))

    def _processor(self):
        while True:
            (_, finished_flag, request_info) = self.queue.get()

            self.script.post({
                'type': 'hash',
                'requestInfo': request_info
            })

            try:
                if not self.wait_flag.wait(timeout=2):
                    self.queue.task_done()
                    continue

                finished_flag.set()
            finally:
                self.wait_flag.clear()
                self.queue.task_done()

    def _on_message(self, message, data):
        if message['type'] == 'send':
            payload = message['payload']
            if payload['type'] == 'hash_result':
                self.results[payload['request']] = payload['result']
                self.wait_flag.set()
        else:
            print("[Android.other] {0}".format(message))
