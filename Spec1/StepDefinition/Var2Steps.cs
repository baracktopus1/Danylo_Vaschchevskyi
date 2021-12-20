using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace Spec1.Features
{
    [Binding]

    public class Var2Steps
    {

        string url = "https://opensource-demo.orangehrmlive.com";
        IWebDriver webdriver = new ChromeDriver(@"Driver");

        [Given(@"User logs in HRM")]
        public void GivenUserLogsInHRM()
        {
            
            webdriver.Navigate().GoToUrl(url);
            LoginPage lg = new LoginPage(webdriver);
            lg.LogIn("Admin", "admin123");



       


        }

        [Given(@"User goes to Jobs page")]
        public void GivenUserGoesToJobsPage()
        {
            Actions actions = new Actions(webdriver);
            IWebElement Admin_droplist = webdriver.FindElement(By.Id("menu_admin_viewAdminModule"));
            actions.MoveToElement(Admin_droplist).Build().Perform();

            IWebElement Job_droplist = webdriver.FindElement(By.Id("menu_admin_Job"));

            actions.MoveToElement(Job_droplist).Build().Perform();

            IWebElement Job_droplist_option = webdriver.FindElement(By.Id("menu_admin_viewJobTitleList"));

            Job_droplist_option.Click();
        }

        [When(@"User adds a new job")]
        public void WhenUserAddsANewJob()
        {
            IWebElement btnAdd = webdriver.FindElement(By.Id("btnAdd"));
            btnAdd.Click();

            JobPage jp = new JobPage(webdriver);
            jp.new_job("Student", "Description", "Note");
           
        }

        [When(@"User clicks on (.*)")]
        public void WhenUserClicksOn(string p0)
        {
            IWebElement job = webdriver.FindElement(By.XPath("//tr//td//a[text()=\"Student\"]"
));
            job.Click();
        }

        [When(@"User edits Job")]
        public void WhenUserEditsJob()
        {
            JobPage jp = new JobPage(webdriver);
            jp.edit_description("Hates life");
        }

        [When(@"User deletes (.*)")]
        public void WhenUserDeletes(string p0)
        {
            IWebElement chkbox = webdriver.FindElement(By.XPath("//tr//td//a[text()=\"Student\"]//..//..//td//input"
));
            chkbox.Click();
            IWebElement delete_btn = webdriver.FindElement(By.Id("btnDelete"));
            delete_btn.Click();
            delete_btn = webdriver.FindElement(By.Id("dialogDeleteBtn"));
            delete_btn.Click();
        }


        
        [Then(@"User is navigated to the homepagee")]

        public void ThenUserIsNavigatedToTheHomepagee()
        {

            IWebElement chkbox = webdriver.FindElement(By.Id("panel_wrapper_0"));
            Assert.IsNotNull(chkbox);
            
        }

        
        [Then(@"User notices new data on the page")]
        public void ThenUserNoticesNewDataOnThePage()
        {
            IWebElement chkbox = webdriver.FindElement(By.XPath("//tr//td//a[text()=\"Student\"]"));
            Assert.IsNotNull(chkbox);
        }
        
        
        [Then(@"User notices edited data on the page")]
        public void ThenUserNoticesEditedDataOnThePage()
        {
            IWebElement chkbox = webdriver.FindElement(By.XPath("//tr//td//a[text()=\"Student\"]"));
            Assert.IsNotNull(chkbox);
        }
        
        [Then(@"User notices his field deleted on Job title page")]
        public void ThenUserNoticesHisFieldDeletedOnJobTitlePage()
        {
            bool flag = false;
            try
            {
                IWebElement chkbox = webdriver.FindElement(By.XPath("//tr//td//a[text()=\"Student\"]"));
            }
            catch
            {
                flag = true;
            }
            Assert.IsTrue(flag);
        }

        [AfterScenario]
        public void ShutDown()
        {
            webdriver.Close();
        }
    }
    
}
