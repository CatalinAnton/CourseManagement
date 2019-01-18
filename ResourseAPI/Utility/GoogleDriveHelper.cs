using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System;
using System.Threading;

namespace ResourseAPI.Utility
{
    public class GoogleDriveHelper
    {
        static string[] Scopes = { DriveService.Scope.Drive };
        static string ApplicationName = "Resources for CourseManagement APP";
        public static string UploadFile(string base64File, string fileTitle, string fileType)
        {
            UserCredential credential;

            var fileCategory = "";
            
            if (fileType == "jpg") {
                fileCategory = "image/jpeg";
            } else if (fileType == "pdf") {
                fileCategory = "application/pdf";
            }

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = fileTitle + "." + fileType
            };

            Byte[] bytes = Convert.FromBase64String(base64File);

            FilesResource.CreateMediaUpload request;
            using (var stream = new MemoryStream(bytes))
            {
                request = service.Files.Create(fileMetadata, stream, fileCategory);
                request.Fields = "id, webViewLink";
                request.Upload();
            }

            var file = request.ResponseBody;
            Console.WriteLine("File ID: " + file.Id);
            Console.WriteLine("File URL: " + file.WebViewLink);

            Permission newPermission = new Permission();
            newPermission.Type = "anyone";
            newPermission.Role = "reader";
            service.Permissions.Create(newPermission, file.Id).Execute();

            return file.WebViewLink;
        }
    }
}