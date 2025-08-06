using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace PageObjectModel.Source.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;

        private IWebElement EmailTxt => _driver.FindElement(By.Id("Input_Email"));
        
        private IWebElement PasswordTxt => _driver.FindElement(By.Id("Input_Password"));

        private IWebElement LoginBtn => _driver.FindElement(By.Id("login-submit"));    
        
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }
  
    

        public void login(string username, string password)
        {
            EmailTxt.SendKeys(username);
            PasswordTxt.SendKeys(password);
            LoginBtn.Click();
        }
    }
}



