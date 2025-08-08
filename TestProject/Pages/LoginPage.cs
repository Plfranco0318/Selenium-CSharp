using OpenQA.Selenium;
using TestProject.Helpers;


namespace PageObjectModel.Source.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;

        private IWebElement EmailTxt => _driver.FindElement(By.Id("Input_Email"));
        
        private IWebElement PasswordTxt => _driver.FindElement(By.Id("Input_Password"));

        private IWebElement LoginBtn => _driver.FindElement(By.Id("login-submit"));

        private IWebElement ErrorMsg => _driver.FindElement(By.ClassName("text-danger"));

        private IWebElement UsernameInputMsg => _driver.FindElement(By.Id("Input_Email-error"));
        private IWebElement PasswordInputMsg => _driver.FindElement(By.Id("Input_Password-error"));


        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }
 
        public void ValidLogin(string username, string password)
        {

            try
            {
                EmailTxt.SendKeys(username);
                PasswordTxt.SendKeys(password);
                LoginBtn.Click();
                ReportHelper.LogPass("Login Successful");

            }catch (Exception)
            {
                ReportHelper.LogFail("Login Failed");
                TakeScreenshot("Login");
                ReportHelper.AddScreenShot(ReportHelper.ScreenshotPath);
                ReportHelper.FinalizeReport();
            }

        }

        public void InvalidLogin(string username, string password)
        {
            try
            {
                EmailTxt.SendKeys(username);
                PasswordTxt.SendKeys(password);
                LoginBtn.Click();

                Thread.Sleep(2000);

                Assert.That(ErrorMsg.Displayed, Is.True);

                if (string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(password))
                {
                    Assert.That(UsernameInputMsg.Displayed, Is.True);
                    Assert.That(PasswordInputMsg.Displayed, Is.True);
                }

                ReportHelper.LogPass("Invalid Login Successful");

            }catch (Exception e)
            {
                ReportHelper.LogFail("Error message is not displayed or assertion failed:" + e.Message);
                TakeScreenshot("Login");
                ReportHelper.AddScreenShot(ReportHelper.ScreenshotPath);
                ReportHelper.FinalizeReport();
            }

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



