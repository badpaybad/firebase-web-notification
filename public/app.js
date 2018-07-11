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

  messaging.usePublicVapidKey("BCfw9LQO1Mg82wVJciJXyht__PpdFLjl3Iw77T42jqS2-s0M90RU-DtQpCgucqBkRZyAhbL8vXEKllPI2yNtZCs");

  messaging.requestPermission().then(function() {
    console.log("ok permission");
     return messaging.getToken();
  }).then(function(token){    
    console.log("get token");
    console.log(token);
    document.getElementById('token').innerHTML= token;

    $.ajax({
      url: 'http://localhost:53188/firebase/savetoken?token='+token,
      type: "POST",
      data: {},
      success: function (res) {
        alert("success: "+res);
      },
      error: function(error) {
        alert("error: "+error);
      }
    });

  }).catch(function(err) {
    console.log('Permission denied', err);
  });

messaging.onTokenRefresh(function() {
  messaging.getToken().then(function(refreshedToken) {
    console.log('Token refreshed.');
    console.log(refreshedToken);
  }).catch(function(err) {
    console.log('Unable to retrieve refreshed token ', err);
  });
});

messaging.onMessage(function(payload){
console.log('onMessage: ',payload);
var message= document.getElementById('message').innerHTML;
message=message+'<div>'+JSON.stringify(payload)+'</div>';

document.getElementById('message').innerHTML= message;
});
