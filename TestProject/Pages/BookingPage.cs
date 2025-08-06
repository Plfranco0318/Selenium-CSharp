using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


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

        private IWebElement CreateBtn => _driver.FindElement(By.XPath("/html/body/div/main/div[1]/div/form/div[8]/input"));

        public BookingPage(IWebDriver driver)
        {
            _driver = driver;
        }


        public void Booking()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);

            BookingBtn.Click();

            var selectElement = GolfNameSelect;
            var selectGolfName = new SelectElement(selectElement);
            selectGolfName.SelectByText("Tiger A");
            CustomerTxt.SendKeys("John Smith");
            EmailTxt.SendKeys("john@mail.com");
            PhoneTxt.SendKeys("09266663456");
            DateTxt.SendKeys("2024" + Keys.ArrowRight + "03" + Keys.ArrowRight + "18");
            StartTimeTxt.SendKeys("08:30AM");
            EndTimeTxt.SendKeys("09:30AM");
            CreateBtn.Click();

        }


    }
    
   
}
