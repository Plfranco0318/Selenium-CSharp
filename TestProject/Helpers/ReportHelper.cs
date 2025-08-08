using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium.BiDi.Script;


namespace TestProject.Helpers
{
    public static class ReportHelper
    {
        public static ExtentReports extent;
        public static ExtentTest test;
        public static string ScreenshotPath { get; private set; }
        public static string ReportPath { get; private set; }

        public static string BaseName { get; private set;  }

        public static void InitializeReport(string testName)
        {
            string timestamp = DateTime.Now.ToString("_MMddyyyy_hhmmt");


            BaseName = $"{testName}{timestamp}";
            ScreenshotPath = $@"C:\Users\Paul Franco II\source\repos\TestProject\TestProject\Screenshots\{BaseName}.png";
            ReportPath = $@"C:\Users\Paul Franco II\source\repos\TestProject\TestProject\Reports\{BaseName}.html";


            var spark = new ExtentSparkReporter(ReportPath);
            extent = new ExtentReports();
            extent.AttachReporter(spark);

            test = extent.CreateTest($"{testName} Test Suite");
            test.Info($"Initialized reporting for {testName}");
        }

        public static void CreateTest(string testName)
        {
            test = extent.CreateTest(testName);
        }


        public static void LogPass(string message)
        {
            test.Pass(message);
            extent.Flush();
        }

        public static void LogFail(string message) 
        {
            test.Fail(message);
            extent.Flush();
        }

        public static void AddScreenShot(string path)
        {
            test.AddScreenCaptureFromPath(path);
            extent.Flush();
        } 

        public static void FinalizeReport()
        {
            extent.Flush();
        }
    }
}