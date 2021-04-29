using System.Net.Http;
using System.IO;

namespace FileUploadingClient
{
    class Program
    {
        static void Main()
        {
            //DownloadFile();
            //UploadFile1();
            //UploadFile2();
            //UploadFiles();
        }

        public static void UploadFile1()
        {
            using var client = new HttpClient();
            var content = new MultipartFormDataContent();

            var fileName = "file1.txt";
            using var fs = File.OpenRead(fileName);
            content.Add(new StreamContent(fs), "file", fileName);

            client.PostAsync("http://localhost:5000/uploading/AddFileToDisk", content).GetAwaiter().GetResult();
        }

        public static void UploadFile2()
        {
            using var client = new HttpClient();
            var content = new MultipartFormDataContent();

            var fileName = "file2.txt";
            var fileBytes = File.ReadAllBytes(fileName);
            var contentBytes = new ByteArrayContent(fileBytes);
            content.Add(contentBytes, "file", fileName);

            client.PostAsync("http://localhost:5000/uploading/AddFileToDisk", content).GetAwaiter().GetResult();
        }

        public static void UploadFiles()
        {
            using var client = new HttpClient();
            var content = new MultipartFormDataContent();

            var fileName1 = "file2.txt";
            var fileName2 = "file3.txt";

            using var fs1 = File.OpenRead(fileName1);
            content.Add(new StreamContent(fs1), "file", fileName1);
            using var fs2 = File.OpenRead(fileName2);
            content.Add(new StreamContent(fs2), "file", fileName2);

            client.PostAsync("http://localhost:5000/uploading/AddFilesToDisk", content).GetAwaiter().GetResult();
        }

        public static void DownloadFile()
        {
            using var client = new HttpClient();
            var response = client.GetAsync("http://localhost:5000/uploading/DownloadFromDisk1/1").GetAwaiter().GetResult();
            var fileName = response.Content.Headers.ContentDisposition.FileName;
            using var fileStream = File.OpenWrite(fileName);
            
            response.Content.CopyToAsync(fileStream).GetAwaiter().GetResult();
            fileStream.Close();
        }
    }
}
