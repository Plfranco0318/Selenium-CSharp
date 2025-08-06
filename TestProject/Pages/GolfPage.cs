using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;


using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;


namespace TestProject.Pages
{
    public class GolfPage
    {
        private IWebDriver _driver;
        public static ExtentTest test;
        public static ExtentReports extent;


        [FindsBy(How = How.Name, Using = "SearchString")]
        private IWebElement searchTxt;
        
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/table[1]/tbody/tr/td[1]/form/button")]
        private IWebElement searchBtn;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/table[2]/thead/tr/th[1]")]
        private IWebElement columnName;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/table[2]/thead/tr/th[2]")]
        private IWebElement columnAddress;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/table[2]/thead/tr/th[3]")]
        private IWebElement columnDesc;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/table[2]/tbody/tr/td[1]")]  
        private IWebElement columnName_1;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/table[2]/tbody/tr")]
        private IWebElement column_content;

        [FindsBy(How = How.ClassName, Using = "select")]
        private IWebElement selectCountry;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/table[2]/tbody/tr[1]/td[2]")]
        private IWebElement address_1;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/table[1]/tbody/tr/td[2]/form/fieldset/button")]
        private IWebElement filter_btn;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/table[1]/tbody/tr/td[5]/form/button")]
        private IWebElement addGolf;

        [FindsBy(How = How.Id, Using = "Name")]
        private IWebElement Name;

        [FindsBy(How = How.Id, Using = "Address")]
        private IWebElement Address;

        [FindsBy(How = How.Id, Using = "City")]
        private IWebElement City;

        [FindsBy(How = How.Id, Using = "Province")]
        private IWebElement Province;

        [FindsBy(How = How.Id, Using = "Country")]
        private IWebElement Country;

        [FindsBy(How = How.Id, Using = "Description")]
        private IWebElement Description;

        [FindsBy(How = How.Id, Using = "LongDes")]
        private IWebElement LongDes;

        [FindsBy(How = How.Id, Using = "Owner")]
        private IWebElement Owner;

        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement Email;

        [FindsBy(How = How.Id, Using = "PhoneNumber")]
        private IWebElement PhoneNumber;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div[1]/div--/form/div[14]/input")]
        private IWebElement CreateBtn;

        [FindsBy(How = How.Id, Using = "Input_Email")]
        private IWebElement login_email;

        [FindsBy(How = How.Id, Using = "Input_Password")]
        private IWebElement login_password;

        [FindsBy(How = How.Id, Using = "login-submit" )]
        private IWebElement loginBtn;

        [FindsBy(How = How.XPath, Using = "/html/body/header/nav/ul/li/a")]
        private IWebElement loginLink;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/table[2]/tbody/tr[1]/td[6]/a[2]")]
        private IWebElement editLink;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div[1]/div/form/div[11]/input")]
        private IWebElement editSavebtn;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/table[2]/tbody/tr/td[6]/a[3]")]
        private IWebElement deleteLink;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div/form/input[2]")]
        private IWebElement deleteSaveBtn;
        public GolfPage(IWebDriver driver) { _driver = driver; PageFactory.InitElements(driver, this); }



        public void search(string searchStr)
        {
            string screensh = @"C:\Users\Paul Franco II\source\repos\TestProject\TestProject\Screenshots\" + "Golf" + DateTime.Now.ToString("_MMddyyyy_hhmmt") + ".png";
            var extent = new ExtentReports();
            var spark = new ExtentSparkReporter(@"C:\Users\Paul Franco II\source\repos\TestProject\TestProject\Reports\" + "Golf" + DateTime.Now.ToString("_MMddyyyy_hhmmt") + ".html");
            extent.AttachReporter(spark);

            var test = extent.CreateTest("SearchTest");
            test.Info("Starting search for Golf Course ");
            extent.Flush();

            try
            {
                searchTxt.Clear();
                searchTxt.SendKeys(searchStr);
                
                searchBtn.Click();
                test.Pass("Search for Golf Course");
                extent.Flush();
            }catch(NoSuchElementException e)
            {
                test.Fail("Search for Golf Course");
                TakeScreenshot("Golf");
                test.AddScreenCaptureFromPath(screensh);
                extent.Flush();
            }

            try
            {
                Assert.Multiple(() =>
                {
                    Assert.That(columnName.Text, Is.EqualTo("Name ^"));
                    Assert.That(columnAddress.Text, Is.EqualTo("Address"));
                    Assert.That(columnDesc.Text, Is.EqualTo("Description"));
                    Assert.That(column_content.Displayed, Is.True);
                    test.Pass("Validate Golf Table");
                    extent.Flush();
                });
            }catch(Exception e)
            {
                test.Fail("Validate Golf table");
                TakeScreenshot("Golf");
                test.AddScreenCaptureFromPath(screensh);
                extent.Flush();
            }
        }

        public void select(string country)
        {
            var selectElement = selectCountry;
            var select = new SelectElement(selectElement);
            select.SelectByText(country);

            filter_btn.Click();

            Assert.Multiple(() =>
            {
                Assert.That(columnName.Text, Is.EqualTo("Name ^"));
                Assert.That(columnAddress.Text, Is.EqualTo("Address"));
                Assert.That(columnDesc.Text, Is.EqualTo("Description"));
                Assert.That(address_1.Text, Contains.Substring(country));
            });
        }

        public void addGolfCourse()
        {
            addGolf.Click();

            string? User = TestContext.Parameters["user"];
            string? Password = TestContext.Parameters["password"];

            login_email.SendKeys(User);
            login_password.SendKeys(Password);  
            loginBtn.Click();

            Thread.Sleep(4000);

            Name.SendKeys("Testing GolF Course A");
            Address.SendKeys("1200 AVE NW");
            City.SendKeys("Edmonton");
            Province.SendKeys("AB");
            Country.SendKeys("Canada");
            Description.SendKeys("It's a nice golf course.");
            LongDes.SendKeys("It's located in NW Edmonton. Its country style and full services.");
            Owner.SendKeys("Daniel Longbottom");
            Email.SendKeys("test2@admlucid.com");
            PhoneNumber.SendKeys("09266663456");
            _driver.Manage().Window.FullScreen();
            CreateBtn.Click();

        }

        public void editGolfCourse()
        {
            loginLink.Click();

            string? User = TestContext.Parameters["user"];
            string? Password = TestContext.Parameters["password"];

            login_email.SendKeys(User);
            login_password.SendKeys(Password);
            loginBtn.Click();

            Thread.Sleep(4000);

            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            Thread.Sleep(2000);

            searchTxt.SendKeys("Testing Golf Course A");
            searchBtn.Click();

            editLink.Click();
            Owner.Clear(); Owner.SendKeys("Johnny Batongbakal"); editSavebtn.Click();
        }


        public void deleteGolfCourse()
        {
            loginLink.Click();

            string? User = TestContext.Parameters["user"];
            string? Password = TestContext.Parameters["password"];

            login_email.SendKeys(User); 
            login_password.SendKeys(Password); 
            loginBtn.Click();

            Thread.Sleep(4000);

            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]); 
            Thread.Sleep(2000);
            searchTxt.SendKeys("Testing Golf Course A"); 
            searchBtn.Click();
           
            deleteLink.Click(); 
            deleteSaveBtn.Click(); 
            Thread.Sleep(2000);
        }

        public void TakeScreenshot(string screenshotname)
        {
            try
            {
                ITakesScreenshot ts = (ITakesScreenshot)_driver;
                string filename = @"C:\Users\Paul Franco II\source\repos\TestProject\TestProject\Screenshots\" + screenshotname + DateTime.Now.ToString("_MMddyyyy_hhmmt") + ".png";
                ts.GetScreenshot().SaveAsFile(filename);
                Console.WriteLine(filename);
            }catch(InvalidCastException e) { Console.WriteLine("Screesnhot" + e.ToString()); }

        }

    }
}
