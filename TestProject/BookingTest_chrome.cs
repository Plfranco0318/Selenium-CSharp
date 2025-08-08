using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjectModel.Source.Pages;
using TestProject.Helpers;



namespace TestProject
{
    public class TestsBooking
    {
        private IWebDriver _driver;
        private BookingPage _bookingPage;

        [OneTimeSetUp]
        public void ReportInit() 
        {
            ReportHelper.InitializeReport("BookingTest");
        }


        [SetUp]

        public void Setup()
        {
            _driver = new ChromeDriver();
            _bookingPage = new BookingPage(_driver);
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void Booking()
        {   
            _bookingPage.Booking();
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Close();
            _driver?.Dispose();
            ReportHelper.FinalizeReport();
        }

    }
}
