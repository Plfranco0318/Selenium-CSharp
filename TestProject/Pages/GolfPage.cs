using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestProject.Helpers;


namespace TestProject.Pages
{
    public class GolfPage
    {
        private IWebDriver _driver;


        private IWebElement SearchTxt => _driver.FindElement(By.Name("SearchString"));

        private IWebElement SearchBtn => _driver.FindElement(By.XPath("/html/body/div/main/table[1]/tbody/tr/td[1]/form/button"));

        private IWebElement ColumnName => _driver.FindElement(By.XPath("/html/body/div/main/table[2]/thead/tr/th[1]"));

        private IWebElement ColumnAddress => _driver.FindElement(By.XPath("/html/body/div/main/table[2]/thead/tr/th[2]"));

        private IWebElement ColumnDesc => _driver.FindElement(By.XPath("/html/body/div/main/table[2]/thead/tr/th[3]"));
        
        private IWebElement ColumnName_1 => _driver.FindElement(By.XPath("/html/body/div/main/table[2]/tbody/tr/td[1]"));

        private IWebElement ColumnContent => _driver.FindElement(By.XPath("/html/body/div/main/table[2]/tbody/tr"));

        private IWebElement SelectCountry => _driver.FindElement(By.ClassName("select"));

        private IWebElement Address_1 => _driver.FindElement(By.XPath("/html/body/div/main/table[2]/tbody/tr[1]/td[2]"));

        private IWebElement FilterBtn => _driver.FindElement(By.XPath("/html/body/div/main/table[1]/tbody/tr/td[2]/form/fieldset/button"));

        private IWebElement AddGolf => _driver.FindElement(By.XPath("/html/body/div/main/table[1]/tbody/tr/td[5]/form/button"));

        private IWebElement Name => _driver.FindElement(By.Id("Name"));
        
        private IWebElement Address => _driver.FindElement(By.Id("Address"));

        private IWebElement City => _driver.FindElement(By.Id("City"));

        private IWebElement Province => _driver.FindElement(By.Id("Province"));

        private IWebElement Country => _driver.FindElement(By.Id("Country"));

        private IWebElement Description => _driver.FindElement(By.Id("Description"));

        private IWebElement LongDesc => _driver.FindElement(By.Id("LongDes"));

        private IWebElement Owner => _driver.FindElement(By.Id("Owner"));

        private IWebElement Email => _driver.FindElement(By.Id("Email"));

        private IWebElement PhoneNumber => _driver.FindElement(By.Id("PhoneNumber"));

        private IWebElement CreateBtn => _driver.FindElement(By.XPath("/html/body/div/main/div[1]/div--/form/div[14]/input")); 

        private IWebElement LoginEmail => _driver.FindElement(By.Id("Input_Email"));

        private IWebElement LoginPassword => _driver.FindElement(By.Id("Input_Password"));

        private IWebElement LoginSubmit => _driver.FindElement(By.Id("login-submit"));

        private IWebElement LoginLink => _driver.FindElement(By.XPath("/html/body/header/nav/ul/li/a"));

        private IWebElement EditLink => _driver.FindElement(By.XPath("/html/body/div/main/table[2]/tbody/tr[1]/td[6]/a[2]"));

        private IWebElement EditSaveBtn => _driver.FindElement(By.XPath("/html/body/div/main/div[1]/div/form/div[11]/input"));

        private IWebElement DeleteLink => _driver.FindElement(By.XPath("/html/body/div/main/table[2]/tbody/tr/td[6]/a[3]"));

        private IWebElement DeleteSaveBtn => _driver.FindElement(By.XPath("/html/body/div/main/div/form/input[2]"));

        public GolfPage(IWebDriver driver)
        {
            _driver = driver;
        }
  

        public void Search(string searchStr)
        {
            string moduleName = "Search_Golf_Search";
            ReportHelper.InitializeReport(moduleName);
            ReportHelper.test.Info(moduleName);

            try
            {
                SearchTxt.Clear();
                SearchTxt.SendKeys(searchStr);
                
                SearchBtn.Click();
                ReportHelper.LogPass("Successfully searched for a golf course.");
            

            }catch(NoSuchElementException e)
            {
                ReportHelper.LogFail("Search failed:" + e.Message);
                TakeScreenshot(moduleName);
                ReportHelper.AddScreenShot(ReportHelper.ScreenshotPath);
                ReportHelper.FinalizeReport();

            }

            try
            {
                Assert.Multiple(() =>
                {
                    Assert.That(ColumnName.Text, Is.EqualTo("Name ^"));
                    Assert.That(ColumnAddress.Text, Is.EqualTo("Address"));
                    Assert.That(ColumnDesc.Text, Is.EqualTo("Description"));
                    Assert.That(ColumnContent.Displayed, Is.True);
                    ReportHelper.LogPass("Validate Golf Table");
                
                });
            }catch(Exception e)
            {
                ReportHelper.LogFail("Validate Golf table");
                TakeScreenshot(moduleName);
                ReportHelper.AddScreenShot(ReportHelper.ScreenshotPath);
                ReportHelper.FinalizeReport();
            }
        }

        public void Select(string country)
        {
            var selectElement = SelectCountry;
            var select = new SelectElement(selectElement);


            try
            {   
                select.SelectByText(country);
                FilterBtn.Click();
                ReportHelper.LogPass("Successfully selected a country.");

            }catch(Exception e)
            {

            }
            try
            {
                Assert.Multiple(() =>
                {
                    Assert.That(ColumnName.Text, Is.EqualTo("Name ^"));
                    Assert.That(ColumnAddress.Text, Is.EqualTo("Address"));
                    Assert.That(ColumnDesc.Text, Is.EqualTo("Description"));
                    Assert.That(Address_1.Text, Contains.Substring(country));
                });
            }catch(Exception e)
            {

            }

        }

        public void AddGolfCourseTest(string name, string address, string city, string province, string country, string desc, string longdesc, string owner, string email, string phone)
        {
            AddGolf.Click();

            string? User = TestContext.Parameters["user"];
            string? Password = TestContext.Parameters["password"];

            LoginEmail.SendKeys(User);
            LoginPassword.SendKeys(Password);
            LoginSubmit.Click();

            Thread.Sleep(4000);

            Name.SendKeys(name);
            Address.SendKeys(address);
            City.SendKeys(city);
            Province.SendKeys(province);
            Country.SendKeys(country);
            Description.SendKeys(desc);
            LongDesc.SendKeys(longdesc);
            Owner.SendKeys(owner);
            Email.SendKeys(email);
            PhoneNumber.SendKeys(phone);
            _driver.Manage().Window.FullScreen();
            CreateBtn.Click();

        }



        public void AddGolfCourse()
        {
            AddGolf.Click();

            string? User = TestContext.Parameters["user"];
            string? Password = TestContext.Parameters["password"];

            LoginEmail.SendKeys(User);
            LoginPassword.SendKeys(Password);  
            LoginSubmit.Click();

            Thread.Sleep(4000);

            Name.SendKeys("Testing GolF Course A");
            Address.SendKeys("1200 AVE NW");
            City.SendKeys("Edmonton");
            Province.SendKeys("AB");
            Country.SendKeys("Canada");
            Description.SendKeys("It's a nice golf course.");
            LongDesc.SendKeys("It's located in NW Edmonton. Its country style and full services.");
            Owner.SendKeys("Daniel Longbottom");
            Email.SendKeys("test2@admlucid.com");
            PhoneNumber.SendKeys("09266663456");
            _driver.Manage().Window.FullScreen();
            CreateBtn.Click();

        }

        public void EditGolfCourse()
        {
            LoginLink.Click();

            string? User = TestContext.Parameters["user"];
            string? Password = TestContext.Parameters["password"];

            LoginEmail.SendKeys(User);
            LoginPassword.SendKeys(Password);
            LoginSubmit.Click();

            Thread.Sleep(4000);

            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            Thread.Sleep(2000);

            SearchTxt.SendKeys("Testing Golf Course A");
            SearchBtn.Click();

            EditLink.Click();
            Owner.Clear(); Owner.SendKeys("Johnny Batongbakal"); EditSaveBtn.Click();
        }


        public void DeleteGolfCourse()
        {
            LoginLink.Click();

            string? User = TestContext.Parameters["user"];
            string? Password = TestContext.Parameters["password"];

            LoginEmail.SendKeys(User); 
            LoginPassword.SendKeys(Password); 
            LoginSubmit.Click();

            Thread.Sleep(4000);

            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]); 
            Thread.Sleep(2000);
            SearchTxt.SendKeys("Testing Golf Course A"); 
            SearchBtn.Click();
           
            DeleteLink.Click(); 
            DeleteSaveBtn.Click(); 
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
            }
            catch (InvalidCastException e) { Console.WriteLine("Screesnhot" + e.ToString()); }

        }

    }
}
