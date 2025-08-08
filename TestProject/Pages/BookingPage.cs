using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestProject.Helpers;


namespace PageObjectModel.Source.Pages
{
    public class BookingPage
    {

        private IWebDriver _driver;

        private IWebElement BookingBtn => _driver.FindElement(By.XPath("/html/body/div/main/table[1]/tbody/tr/td[4]/form/button"));

        private IWebElement GolfNameSelect => _driver.FindElement(By.Id("GolfName"));

        private IWebElement CustomerTxt => _driver.FindElement(By.Id("Customer"));

        private IWebElement EmailTxt => _driver.FindElement(By.Id("Email"));

        private IWebElement PhoneTxt => _driver.FindElement(By.Id("Phone"));

        private IWebElement DateTxt => _driver.FindElement(By.Id("Date"));

        private IWebElement StartTimeTxt => _driver.FindElement(By.Id("StartTime"));

        private IWebElement EndTimeTxt => _driver.FindElement(By.Id("EndTime"));

        private IWebElement CreateBtn => _driver.FindElement(By.XPath("/html/body/div/main/div[1]/div/form/div[8]/input/"));

        public BookingPage(IWebDriver driver)
        {
            _driver = driver;
        }


        public void Booking()
        {

            try
            {
                _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);

                Assert.That(CreateBtn.Displayed, Is.True);
                ReportHelper.LogPass("Successfully navigated to the Booking Page");

            }
            catch (Exception e)
            {
                ReportHelper.LogFail("Failed to navigate to Booking Page:" + e.Message);
                TakeScreenshot();
                ReportHelper.AddScreenShot(ReportHelper.ScreenshotPath);
                Assert.Fail("Failed");


            }
        }
        public void TakeScreenshot()
        {
            try
            {
                ITakesScreenshot ts = (ITakesScreenshot)_driver;
                string filename = $@"C:\Users\Paul Franco II\source\repos\TestProject\TestProject\Screenshots\{ReportHelper.BaseName}.png";
                ts.GetScreenshot().SaveAsFile(filename);
       
            }
            catch (InvalidCastException e) { Console.WriteLine("Screenshot" + e.ToString()); }

        }


    }

}



//_driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
//ReportHelper.LogPass("Successfully navigated to the Booking Page");

//BookingBtn.Click();
//ReportHelper.LogPass("Successfully navigated to the Booking Details");

//var selectElement = GolfNameSelect;
//var selectGolfName = new SelectElement(selectElement);
//selectGolfName.SelectByText("Tiger sss");


//CustomerTxt.SendKeys("John Smith");
//EmailTxt.SendKeys("john@mail.com");
//PhoneTxt.SendKeys("09266663456");
//DateTxt.SendKeys("2024" + Keys.ArrowRight + "03" + Keys.ArrowRight + "18");
//StartTimeTxt.SendKeys("08:30AM");
//EndTimeTxt.SendKeys("09:30AM");
//ReportHelper.LogPass("Successfully entered data to the Booking Details");

//CreateBtn.Click();
//ReportHelper.LogPass("Successfully added the new booking");
