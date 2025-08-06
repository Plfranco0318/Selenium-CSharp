using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;


namespace PageObjectModel.Source.Pages
{
    public class BookingPage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/table[1]/tbody/tr/td[4]/form/button")]
        private IWebElement BookingBtn;

        [FindsBy(How = How.Id, Using = "GolfName")]
        private IWebElement GolfNameSelect;

        [FindsBy(How = How.Id, Using = "Customer")]
        private IWebElement CustomerTxt;

        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement EmailTxt;

        [FindsBy(How = How.Id, Using = "Phone")]
        private IWebElement PhoneTxt;

        [FindsBy(How = How.Id, Using = "Date")]
        private IWebElement DateTxt;

        [FindsBy(How = How.Id, Using = "StartTime")]
        private IWebElement StartTimeTxt;

        [FindsBy(How = How.Id, Using = "EndTime")]
        private IWebElement EndTimeTxt;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div[1]/div/form/div[8]/input")]
        private IWebElement CreateBtn;

        public BookingPage(IWebDriver driver) { _driver = driver; PageFactory.InitElements(_driver, this); }

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
