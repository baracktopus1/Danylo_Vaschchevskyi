using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Spec1.Features
{
    internal class LoginPage
    {
        public LoginPage(IWebDriver webdriver)
        {
            this.webdriver = webdriver;
            login = webdriver.FindElement(By.Id("txtUsername"));
            password = webdriver.FindElement(By.Id("txtPassword"));
            login_button = webdriver.FindElement(By.Id("btnLogin"));
        }
        IWebDriver webdriver;
        IWebElement login;
        IWebElement password;
        IWebElement login_button;


        public void LogIn(string log, string pass)
        {
            login.SendKeys(log);
            password.SendKeys(pass);
            login_button.Click();
        }

        
    }
}