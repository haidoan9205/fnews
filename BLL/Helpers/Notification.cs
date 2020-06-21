using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;
using System.Threading.Tasks;

namespace BLL.Helpers
{
    public class Notification : INotification
    {
        private const string Path = "D:\\project-job-8a8a9-firebase-adminsdk-kh6x9-b6221ed5b9.json";
        private readonly FirebaseMessaging messaging;

        public Notification()
        {
            var app = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(Path).CreateScoped("https://www.googleapis.com/auth/firebase.messaging")
            });
            messaging = FirebaseMessaging.GetMessaging(app);
        }

        private Message CreateNotification(string title, string notificationBody, string token)
        {
            return new Message()
            {
                Token = token,
                Notification = new FirebaseAdmin.Messaging.Notification()
                {
                    Body = notificationBody,
                    Title = title,
                }
            };
        }

        public async Task SendNotification(string token, string title, string body)
        {

            var result = await messaging.SendAsync(CreateNotification(title, body, token));
        }
    }

    public interface INotification
    {
        public Task SendNotification(string token, string title, string body);
    }

}
