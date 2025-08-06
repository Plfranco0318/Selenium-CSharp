using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProject.Pages;

//using OpenQA.Selenium.Edge;



namespace TestProject
{
    public class TestsGolf
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            
            _driver = new ChromeDriver();
            //_driver = new FirefoxDriver();
            _driver.Manage().Window.Maximize();

        }

        [Test]
        public void SearchTest()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver);

            try
            {
                g.Search("Sky Golf Course");
            }catch (NoSuchElementException e)
            {
                g.TakeScreenshot("golf");
            }

        }

        [Test]
        public void SelectTest()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver);

            g.Select("Sweden");
        }

        [Test]
        public void AddGolfTest()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver);

            g.AddGolfCourse();
        }

        [Test]
        public void EditGolfTest() 
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver);

            g.EditGolfCourse();
        }

        [Test]
        public void RemoveGolfTest()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver);

            g.DeleteGolfCourse();
        }

        [TearDown]
        public void Teardown()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
                 
    }

}