using OpenQA.Selenium;

namespace Spec1.Features
{
    internal class JobPage
    {

        public JobPage(IWebDriver webdriver)
        {
            this.webdriver = webdriver;
            Job_title = webdriver.FindElement(By.Id("jobTitle_jobTitle"));
            Job_description = webdriver.FindElement(By.Id("jobTitle_jobDescription"));
            Job_note = webdriver.FindElement(By.Id("jobTitle_note"));
            btnSave = webdriver.FindElement(By.Id("btnSave"));
           



        }
        IWebDriver webdriver;
        IWebElement Job_title;
        IWebElement Job_description;
        IWebElement Job_note;
        IWebElement btnSave;

        public void new_job(string s1, string s2, string s3)
        {
            
            Job_title.SendKeys(s1);
            Job_description.SendKeys(s2);
            Job_note.SendKeys(s3);

            btnSave.Click();
        }

        public void edit_description(string s1)
        {
            btnSave.Click();
            Job_description.Clear();
            Job_description.SendKeys(s1);

            btnSave.Click();

        

           
        }

}
}