using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjectModel.Source.Pages;



namespace TestProject
{
    public class TestsBooking
    {
        private IWebDriver _driver;
        [SetUp]

        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void Booking()
        {
            BookingPage b = new BookingPage(_driver);
            b.Booking();
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Close();
            _driver?.Dispose();
        }

    }
}
