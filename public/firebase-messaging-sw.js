importScripts('https://www.gstatic.com/firebasejs/5.2.0/firebase.js');
importScripts('https://www.gstatic.com/firebasejs/5.2.0/firebase-app.js');
importScripts('https://www.gstatic.com/firebasejs/5.2.0/firebase-messaging.js');

 // Initialize Firebase
 var config = {
  apiKey: "AIzaSyBv9tOL37n3WYSOLh2k2d-8YDlPYCOa-AA",
  authDomain: "juljulsausau.firebaseapp.com",
  databaseURL: "https://juljulsausau.firebaseio.com",
  projectId: "juljulsausau",
  storageBucket: "juljulsausau.appspot.com",
  messagingSenderId: "102211866511"
};

firebase.initializeApp(config);

var messaging = firebase.messaging();