# Firebase console
Create your project firebase https://console.firebase.google.com/u/0/ you will need server key, sender id, project id

# Folder "public"
Deploy to get token with javascript setup. Can use firebase hosting because we need https https://firebase.google.com/docs/hosting/quickstart or you can use your own domain with ssl.

## Firebase get token
Folder "public" follow instruciton https://firebase.google.com/docs/cloud-messaging/js/client

- Must need mainfest.json and firebase-messaging-sw.js just copy it and should not modify. And they should be place in root web. Just change config filebase, find var config ={ ... }
- file app.js your own script to working with firebase
- find and replace your own config firebase (app.js , firebase-messaging-sw.js)
    // Initialize Firebase
    var config = { ...}

# Folder "Api.FirebaseNotification" C#
FirebaseController Asp.net restfulApi

- Api to save token from firebase (check app.js). Ajax will call to api "../firebase/savetoken?token=...". You should change your own.

- Api Send message notify to firebase "../firebase/send?msg=..." using HttpClient 

# All in one
You can combind folder "public" inside "Api.FirebaseNotification" with MVC asp.net can use html and javascript to _Layout.cshtml . 
## Need mainfest.json and firebase-messaging-sw.js in root web and should not change it, just change config for firebase
If you want to change firebase-messaging-sw.js please check https://firebase.google.com/docs/web/setup
