# Need hosting with https
Can use firebase hosting because we need https https://firebase.google.com/docs/hosting/quickstart or you can use your own domain with ssl.

# Firebase get token
Folder "public" follow instruciton https://firebase.google.com/docs/cloud-messaging/js/client

- Must need mainfest.json and firebase-messaging-sw.js just copy it and should not modify. And they should be place in root web.
- file app.js your own script to working with firebase

# Folder "Api.FirebaseNotification" C#
FirebaseController Asp.net restfulApi

- Api to save token from firebase (check app.js). Ajax will call to api "../firebase/savetoken?token=...". You should change your own.

- Api Send message notify to firebase "../firebase/send?msg=..." using HttpClient 


