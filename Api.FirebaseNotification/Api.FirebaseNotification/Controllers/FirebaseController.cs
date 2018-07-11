using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api.FirebaseNotification.Controllers
{
    [RoutePrefix("firebase")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FirebaseController : ApiController
    {
        [HttpGet]
        [Route("savetoken")]
        public string SaveFirebaseToken(string token)
        {
            System.Web.HttpContext.Current.Cache["firebasetoken"] = token;
            return token;
        }

        [HttpGet]
        [Route("send")]
        public string Send(string msg)
        {
            var token = System.Web.HttpContext.Current.Cache["firebasetoken"]?? "e6Wol62oK-E:APA91bFXsQOFOcEu0vs33irZw0rQHfYpSh9soSPDE_7TQFdeSNN7blQyAisTUm3O8NENhza_huBDYbggKXt0_mVAyWm03BIEJfZ33fzEjjifp3fS9ubANsTHLwSMDVqgvxbl58mlfx9A";

            using (var c = new HttpClient())
            {
                //https://console.firebase.google.com/u/0/project/_/settings/cloudmessaging/
                //Authorize legacy protocol send requests 
                //https://firebase.google.com/docs/cloud-messaging/auth-server?authuser=0#authorize_http_requests
                var firebaseUrl = "https://fcm.googleapis.com/fcm/send";
                c.BaseAddress = new Uri(firebaseUrl);
                c.DefaultRequestHeaders.Add("Authorization", "key =AAAAF8xNT48:APA91bEkMq7QCpBM0j03LF6noqCyC-7GynZngeAJx1IY3XlqL48EPryZtgADzEcOLhk12fiVEJpcdRzdFwOz1rlss_mx3qS8Tcl9KIn7bLBh_VVyyyenViuN8jbynsXohZdep3LnQV4RRVr5cuOT5qs3BUjrxpPZVg");
                c.DefaultRequestHeaders.Add("Sender", "id =102211866511");

                var response = c.PostAsJsonAsync(firebaseUrl, new FirebaseMessage()
                {
                    to = token.ToString(),
                    data = new FirebaseMessage.Notification()
                    {
                        body = "Hello body",
                        title = msg+ " At " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    }
                }).Result.Content.ReadAsStringAsync().Result;

                return response;
            }
        }

        public class FirebaseMessage
        {
            public string to;
            public Notification data;

            public class Notification
            {
                public string body;
                public string title;
            }
        }
    }
}