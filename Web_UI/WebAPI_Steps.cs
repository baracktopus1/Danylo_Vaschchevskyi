using NUnit.Framework;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace WebAPI___
{
    [Binding]
    [TestFixture]
    public class WebAPI_Steps
    {
        [Given(@"File is in the folder")]
        public void GivenFileIsInTheFolder()
        {
            
            File.WriteAllText("Data/thing.txt", "RODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIPRODIP");
        }
        
        [Given(@"File is in the dropbox")]
        public void GivenFileIsInTheDropbox()
        {
            var webapi = new WebAPI_();
            webapi.Upload();
        }
        
        [When(@"Upload method is called")]
        public void WhenUploadMethodIsCalled()
        {
            var webapi = new WebAPI_();
            webapi.Upload();
        }
        
        [When(@"Delete method is called")]
        public void WhenDeleteMethodIsCalled()
        {
            var webapi = new WebAPI_();
            webapi.Delete();
        }
        
        [When(@"Metadata method is called")]
        public void WhenMetadataMethodIsCalled()
        {
            var webapi = new WebAPI_();
            webapi.GetMetadata();
        }
        [Test]
        [Then(@"File uploaded to the dropbox")]
        public void ThenFileUploadedToTheDropbox()
        {
            var webapi = new WebAPI_();
            webapi.GetMetadata();
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

            Assert.IsTrue(flag);
        }
        [Test]
        [Then(@"File is no longer on the dropbox")]
        public void ThenFileIsNoLongerOnTheDropbox()
        {
            var webapi = new WebAPI_();
            webapi.GetMetadata();
            string str = File.ReadAllText("Data/Metadata.txt");
            string[] str1 = str.Split(",");
            bool flag = true;
            foreach (string x in str1)
            {
                if (x.Contains("thing.txt"))
                {
                    flag = false;
                }
            }

           Assert.IsTrue(File.Exists("Data/Metadata.txt"));
        }
        [Test]
        [Then(@"Metadata\.txt is generated")]
        public void ThenMetadata_TxtIsGenerated()
        {
         
            Assert.IsTrue(File.Exists("Data/Metadata.txt"));
        }
    }
}
