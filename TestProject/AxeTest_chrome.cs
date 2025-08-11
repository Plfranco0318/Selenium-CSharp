using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Axe;
using NUnit.Framework;   

namespace TestProject
{
    public class AxeTest_chrome
    {
        private IWebDriver _driver;

        private string _loginUrl;
        private string _golfUrl;
        private string _homeUrl;

        [SetUp]
        public void Setup()
        {

            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");

            _driver = new ChromeDriver(options);
            _driver.Manage().Window.Maximize();

            _loginUrl = TestContext.Parameters["login_url"];
            _golfUrl = TestContext.Parameters["golf_url"];
            _homeUrl = TestContext.Parameters["home_url"];

        }


        [Test]
        public void AxeTest_Login()
        {
            _driver.Navigate().GoToUrl(_loginUrl);
            AxeResult axeResult = new AxeBuilder(_driver).Analyze();

            string path = Path.Combine(@"C:\Users\Paul Franco II\source\repos\TestProject\TestProject\Reports\", "AxeReport_Login.html");
            _driver.CreateAxeHtmlReport(axeResult, path);
        }

        [Test]
        public void AxeTest_Golf()
        {
            _driver.Navigate().GoToUrl(_golfUrl);
            AxeResult axeResult = new AxeBuilder(_driver).Analyze();

            string path = Path.Combine(@"C:\Users\Paul Franco II\source\repos\TestProject\TestProject\Reports\", "AxeReport_Golf.html");
            _driver.CreateAxeHtmlReport(axeResult, path);

        }

        [Test]
        public void AxeTest_Home()
        {
            _driver.Navigate().GoToUrl(_homeUrl);
            AxeResult axeResult = new AxeBuilder(_driver).Analyze();

            string path = Path.Combine(@"C:\Users\Paul Franco II\source\repos\TestProject\TestProject\Reports\", "AxeReport_Home.html");
            _driver.CreateAxeHtmlReport(axeResult, path);
        }


        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }

    }
}
