using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjectModel.Source.Pages;
using TestProject.Helpers;


namespace TestProject
{
    public class LoginTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;

        private string _loginUrl;
        private string _validUser;
        private string _validPassword;

        [OneTimeSetUp]
        public void ReportInit()
        {
            ReportHelper.InitializeReport("LoginTest");
        }
      
        
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _loginPage = new LoginPage(_driver);

            _loginUrl = TestContext.Parameters["login_url"];
            _validUser = TestContext.Parameters["user"];
            _validPassword = TestContext.Parameters["password"];
            
        }

        [Test]
        public void Login()
        {
            ReportHelper.CreateTest("Valid Login");
            _driver.Navigate().GoToUrl(_loginUrl);
            _loginPage.ValidLogin(_validUser, _validPassword);
        }

        [Test]
        public void IncorrectPassword()
        {
            ReportHelper.CreateTest("Invalid Login: Incorrect Password");
            _driver.Navigate().GoToUrl(_loginUrl);
            _loginPage.InvalidLogin("test2@mail.com", "123456789");
        }


        [Test]
        public void IncorrectUsername()
        {
            ReportHelper.CreateTest("Invalid Login: Incorrect Username");
            _driver.Navigate().GoToUrl(_loginUrl);
            _loginPage.InvalidLogin("error@admlucid.com", _validPassword);
        }


        [Test]
        public void EmptyLogin()
        {
            ReportHelper.CreateTest("Invalid Login: Empty input fields");
            _driver.Navigate().GoToUrl(_loginUrl);
            _loginPage.InvalidLogin("", "");

        }
      
        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
            _driver?.Dispose();
            ReportHelper.FinalizeReport();
        }

    }
}