using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Firebase.Storage;
using PetraEntity.Assets.Pages;
using System.Windows;
using mainUI;
using System.Data.Entity;

namespace PetraEntity.FireBase
{
    public class FireBaseUpload
    {
        

        private static string ApiKey = "*****************";
        private static string Bucket = "********************";
        private static string AuthEmail = "****************";
        private static string AuthPassword = "**********";

        public static string FBDirectory
        {
            get
            {
                var directoryPath = AppDomain.CurrentDomain.BaseDirectory;
                return Path.GetFullPath(Path.Combine(directoryPath, "..//..//Data"));
            }
        }


         private  async Task Run()
        {
            try

               var stream = new FileStream (FBDirectory+ ***************, FileMode.Open);

                var auth = new FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig(ApiKey));
                var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);
                var cancellation = new CancellationTokenSource();

                var task = new FirebaseStorage(
                        Bucket,
                        new FirebaseStorageOptions
                        {
                            AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                            ThrowOnCancel = true 
                    })
                        .Child("************")
                        .Child("********")
                        .PutAsync(stream, cancellation.Token);

                int progres;
                StartPage sp = new StartPage();
                sp.messegaTXT.Text = "tamam";

                task.Progress.ProgressChanged += (s, e) =>
                {
                    progres = e.Percentage;
                    sp.messegaTXT.Text = e.ToString();

                    if (progres == 100)
                    {
                        MessageBox.Show("ok");
                        sp.messegaTXT.Text = "tamam";
                        stream.Close();
                    }

                };


                var downloadUrl = await task;

            }
            catch (Exception er)
            {

                MessageBox.Show(er.ToString());

            }

        }


        static void FBasdGO()
        {
            StartPage sp = new StartPage();
            sp.messegaTXT.Text = "tamam";
        }


        public void FBGO()
        {
           Run();
        }

    }
}
