using APIMusic.Models.Responses.Dto;
using Firebase.Storage;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace APIMusic.Services.Impl
{
    public class FirebaseStorageService:IFirebaseStorageService
    {
        private readonly string _bucket = "dacn-fa06d.appspot.com";

        public async Task<string> PutFileToFirebaseAsync(Stream stream, string extensionFileName)
        {
            var fileName = Guid.NewGuid().ToString() + extensionFileName;
            await new FirebaseStorage(_bucket,
                           new FirebaseStorageOptions
                           {
                               AuthTokenAsyncFactory = () => Task.FromResult(GetFirebaseToken()),
                               ThrowOnCancel = true,
                           })
                          .Child(fileName)
                          .PutAsync(stream);
            using (var client = new WebClient())
            {
                var url = await new FirebaseStorage(_bucket,
                           new FirebaseStorageOptions
                           {
                               AuthTokenAsyncFactory = () => Task.FromResult(GetFirebaseToken()),
                               ThrowOnCancel = true,
                           })
                          .Child($"{fileName}")
                          .GetDownloadUrlAsync();
                return url;
            }
        }
        public async Task<string[]> PutFile(Stream stream, string extensionFileName)
        {
            var fileName = Guid.NewGuid().ToString() + extensionFileName;
            await new FirebaseStorage(_bucket,
                           new FirebaseStorageOptions
                           {
                               AuthTokenAsyncFactory = () => Task.FromResult(GetFirebaseToken()),
                               ThrowOnCancel = true,
                           })
                          .Child(fileName)
                          .PutAsync(stream);
            using (var client = new WebClient())
            {
                var url = await new FirebaseStorage(_bucket,
                           new FirebaseStorageOptions
                           {
                               AuthTokenAsyncFactory = () => Task.FromResult(GetFirebaseToken()),
                               ThrowOnCancel = true,
                           })
                          .Child($"{fileName}")
                          .GetDownloadUrlAsync();
                return new string[] { url , fileName };
            }
        }

        public async Task<FileDto> DownloadFileFromFireBaseAsync(string fileName)
        {
            using (var client = new WebClient())
            {
                var url = await new FirebaseStorage(_bucket,
                           new FirebaseStorageOptions
                           {
                               AuthTokenAsyncFactory = () => Task.FromResult(GetFirebaseToken()),
                               ThrowOnCancel = true,
                           })
                          .Child($"{fileName}")
                          .GetDownloadUrlAsync();
                var content = client.DownloadData(url);
                var contentType = client.ResponseHeaders["Content-Type"];
                using (var stream = new MemoryStream(content))
                {
                    return new FileDto
                    {
                        Content = stream,
                        ContentType = contentType
                    };
                }
            }
        }

        private string GetFirebaseToken()
        {
            var firebaseConfig = new Firebase.Auth.FirebaseConfig("AIzaSyDtEurPdLWlPH67T_VuqUESsI9YXcmZayw");
            var auth = new Firebase.Auth.FirebaseAuthProvider(firebaseConfig);
            var login = auth.SignInWithEmailAndPasswordAsync("tranvanlong230900@gmail.com", "dacn123456");
            return login.GetAwaiter().GetResult().FirebaseToken;
        }

       
    }
}
