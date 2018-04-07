import threading

from flask import Flask, jsonify, request
from android import Android

app = Flask(__name__)
android = Android()


@app.route("/sign", methods=['POST'])
def get_sign():
    finished_flag = threading.Event()

    if 'requestInfo' not in request.form:
        return jsonify('Invalid request'), 400

    request_info = request.form['requestInfo']
    android.add_to_queue(False, finished_flag, request_info)

    if not finished_flag.wait(timeout=5):
        return jsonify('Failed'), 500

    return jsonify({
        'sign': android.results.pop(request_info)
    })


def startup():
    android.start()
    app.run(debug=False)


if __name__ == '__main__':
    startup()
