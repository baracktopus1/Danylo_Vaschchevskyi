using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Dropbox.Api;
using Dropbox.Api.Files;
using NUnit.Framework;
using RestSharp;

namespace WebAPI___
{
    [TestFixture]
    public class WebAPI_
    {
        public void existential_check()
        {
            if(!Directory.Exists("Data"))
            {
                Directory.CreateDirectory("Data");
                File.WriteAllText("Data/thing.txt", "RODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIP");
            }
        }
        static string token = "oyXxbQG-igAAAAAAAAAAAbkmRNE11Ye6bQlJ6jI-r3Zlw1anVNghAYipGuxemjh-";
        [Test]
        public void TestUpload()
        {

            existential_check();
            Upload();

            GetMetadata();
            string str = File.ReadAllText("Data/Metadata.txt");
            string[] str1 = str.Split(",");
            bool flag = false;
            foreach (string x in str1){
                if(x.Contains("thing.txt"))
                {
                    flag = true;
                }
            }

            Assert.IsTrue(flag);

        }
       public void Upload()
        {
            var client = new RestClient("https://content.dropboxapi.com/2/files/upload");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            
            request.AddHeader("Authorization", "Bearer 49--Sp2XJKwAAAAAAAAAAcOJXw2u0A4JWmoQUez5pCh9sB8_rVmqFfkJbBteGV79");
            request.AddHeader("Dropbox-API-Arg", "{\"path\": \"/thing.txt\",\"mode\": \"add\",\"autorename\": true,\"mute\": false,\"strict_conflict\": false}");
            request.AddHeader("Content-Type", "application/octet-stream");
            request.AddHeader("data-binary", "@local_file.txt");
           
            request.AddBody("file", "Data/thing.txt");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

        }

        [Test]
        public void TestDelete()
        {
            existential_check();
            Delete();

            GetMetadata();
            string str = File.ReadAllText("Data/Metadata.txt");
            string[] str1 = str.Split(",");
            bool flag = false;
            foreach (string x in str1)
            {
                if (x.Contains("thing.txt"))
                {
                    flag = true;
                }
            }

        }
        public void Delete()
        {
            var client = new RestClient("https://api.dropboxapi.com/2/files/delete_v2");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer 49--Sp2XJKwAAAAAAAAAAcOJXw2u0A4JWmoQUez5pCh9sB8_rVmqFfkJbBteGV79");
            request.AddHeader("Content-Type", "application/json");
            var body = @"{""path"": ""/thing.txt""}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        [Test]
        public void TestMetadata()
        {
            existential_check();
            GetMetadata();

            Assert.IsTrue(File.Exists("Data/Metadata.txt"));

        }
        public void GetMetadata()
        {
            
            File.WriteAllText("Data/thing.txt", "RODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIP");
            var client = new RestClient("https://api.dropboxapi.com/2/files/get_metadata");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", " Bearer 49--Sp2XJKwAAAAAAAAAAcOJXw2u0A4JWmoQUez5pCh9sB8_rVmqFfkJbBteGV79");
            request.AddHeader("data", "\"{\"path\": \"/thing\",\"include_media_info\": false,\"include_deleted\": false,\"include_has_explicit_shared_members\": false}\"");
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
" + "\n" +
            @"    ""path"": ""/thing.txt"",
" + "\n" +
            @"    ""include_media_info"": false,
" + "\n" +
            @"    ""include_deleted"": false,
" + "\n" +
            @"    ""include_has_explicit_shared_members"": false
" + "\n" +
            @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            File.WriteAllText("Data/Metadata.txt",response.Content.ToString());
        }
    }
}
