using Firebase.Auth;
using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpexE_Comm.Service.Services
{
    public class FirebaseCloudStorageService : IFirebaseCloudStorageService
    {
        private static string ApiKey = "AIzaSyDY2h515pjJU1HFb3nktnwsccmnf6frS58";
        private static string Bucket = "spex-ecommerce.appspot.com";
        private static string AuthEmail = "sudhanshupal20199@gmail.com";
        private static string AuthPassword = "Spc@linux123";

        public async Task<string> UploadFileInFirebase(string fileName, Stream stream)
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

            // you can use CancellationTokenSource to cancel the upload midway
            var cancellation = new CancellationTokenSource();

            var task = new FirebaseStorage(
                Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true // when you cancel the upload, exception is thrown. By default no exception is thrown
                })
                .Child("images")
                .Child(fileName)
                .PutAsync(stream, cancellation.Token);

            try
            {
                string link = await task;
                return link;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");
            //if (task.TargetUrl != null)
            //{
            //    var url = Convert.ToString(task.TargetUrl);
            //    return url;
            //}
            //else
            //{
            //    return string.Empty;
            //}
        }
    }
}

