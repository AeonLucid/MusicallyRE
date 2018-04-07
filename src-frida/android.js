var util = {
    decodeBase64: function (s) {
        var e={},i,b=0,c,x,l=0,a,r='',w=String.fromCharCode,L=s.length;
        var A="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
        for(i=0;i<64;i++){e[A.charAt(i)]=i;}
        for(x=0;x<L;x++){
            c=e[s.charAt(x)];b=(b<<6)+c;l+=6;
            while(l>=8){((a=(b>>>(l-=8))&0xff)||(x<(L-2)))&&(r+=w(a));}
        }
        return r;
    }
};

var contextInstance;
var secureInstance;
var currentDeviceId;

var hasher = {
    init: function () {
        console.log('[Script] Initializing hasher.');

        Java.perform(function () {
            // Find context instance.
            Java.choose('com.zhiliaoapp.musically.MusicallyApplication', {
                onMatch: function (instance) {
                    console.log('[Script] > Found context instance.');

                    this.secureInstance = instance;
                },
                onComplete: function () {
                    contextInstance = this.secureInstance;
                }
            });

            // Find secure instance.
            Java.choose('eeo', {
                onMatch: function (instance) {
                    console.log('[Script] > Found secure instance.');

                    this.secureInstance = instance;
                },
                onComplete: function () {
                    secureInstance = this.secureInstance;
                }
            });

            // Hook device id getter.
            var deviceIdClass = Java.use('eep');
            deviceIdClass.a.overload('android.content.Context').implementation = function () {
                console.log('[Script] Intercepted device id, modifying to ' + currentDeviceId + '.');

                return currentDeviceId;
            };
        });

        console.log('[Script] Initialized hasher.');
    },
    hash: function (deviceId, requestInfo) {
        currentDeviceId = deviceId;
        var response = 'empty';

        Java.perform(function () {
            // Retrieve context.. hash?
            var contextRetVal = secureInstance.c(contextInstance);

            // Save the token.
            secureInstance.e.value.saveToken(deviceId, contextRetVal, "0335", 1);

            // Sign with token.
            var stringClass = Java.use("java.lang.String");
            var inputString = stringClass.$new(requestInfo);

            response = "01a6" + secureInstance.e.value.signWithToken(deviceId, inputString.getBytes("UTF-8"), 0);
        });

        return response;
    }
};

function listenForReceive() {
    recv('hash', function (data) {
        var requestInfoBody = data['requestInfo'];
        var requestInfo = JSON.parse(util.decodeBase64(requestInfoBody));
        var deviceId = requestInfo['deviceid'];

        var sign = hasher.hash(deviceId, requestInfoBody);

        send({
            'type': 'hash_result',
            'request': requestInfoBody,
            'result': sign
        });

        listenForReceive();
    });
}

hasher.init();
listenForReceive();