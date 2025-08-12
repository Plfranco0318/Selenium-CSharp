using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProject.Helpers;
using TestProject.Pages;

//using OpenQA.Selenium.Edge;



namespace TestProject
{
    public class TestsGolf
    {
        private IWebDriver _driver;
        private GolfPage _golfPage;
        private string _loginUrl;
        private string _golfUrl;


        [OneTimeSetUp]
        public void ReportInit()
        {
            ReportHelper.InitializeReport("GolfPageTest");
        }

        [SetUp]
        public void Setup()
        {

            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();

            _loginUrl = TestContext.Parameters["login_url"];
            _golfUrl = TestContext.Parameters["golf_url"];
            _golfPage = new GolfPage(_driver);

        }

        //public static List<TestCaseData> CountryTestCases
        //{
        //    get
        //    {
        //        var testCases = new List<TestCaseData>();


        //        using (var sr = new StreamReader(@"C:\Users\Paul Franco II\source\repos\TestProject\TestProject\Data\countries.csv"))
        //        {
        //            string line;


        //            while ((line = sr.ReadLine()) != null)
        //            {
        //                if (string.IsNullOrWhiteSpace(line))
        //                    continue;

        //                var testCase = new TestCaseData(line.Trim());
        //                testCases.Add(testCase);
        //            }
        //        }

        //        return testCases;
        //    }
        //}

        public static List<TestCaseData> GolfTestCases
        {
            get
            {
                var testCases = new List<TestCaseData>();

                using (var fs = File.OpenRead(@"C:\Users\Paul Franco II\source\repos\TestProject\TestProject\Data\golf.csv"))
                using (var sr = new StreamReader(fs))
                {
                    string line = string.Empty;
                    while (line != null)
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            string[] golf = line.Split(new char[] { ',' },
                                StringSplitOptions.None);

                            var testCase = new TestCaseData(golf);
                            testCases.Add(testCase);
                        }
                    }
                }

                return testCases;
            }
        }


        [TestCase("Sky Golf Course")]
        [TestCase("Tiger Golf")]
        [TestCase("Tiger B")]
        [TestCase("Dummy")]

        public void SearchTestCases(string name)
        {
            ReportHelper.CreateTest("Search for a golf course:" + name);
            _driver.Navigate().GoToUrl(_golfUrl);
            _golfPage.Search(name);
        }

        //[TestCaseSource("CountryTestCases")]
        //[Test]
        //public void SelectTestCases(string country)
        //{
        //    _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
        //    GolfPage g = new GolfPage(_driver);
        //    try { g.Select(country); } catch (NoSuchElementException e) { Console.WriteLine(e); }
        //}

        [TestCaseSource("GolfTestCases")]
        [Test]
        public void AddGolfTestCases(string name, string address, string city, string province, string country,
                              string desc, string longdesc, string owner, string email, string phone)
        {
            ReportHelper.CreateTest("Data Driven Test: Adding a golf course");
            _driver.Navigate().GoToUrl(_golfUrl);
            _golfPage.AddGolfCourseTest(name, address, city, province, country, desc, longdesc, owner, email, phone);
        }

        [Test]
        public void SearchTest()
        {
            ReportHelper.CreateTest("Search for a golf course");
            _driver.Navigate().GoToUrl(_golfUrl);
            _golfPage.Search("Sky Golf Course");
        }

        [Test]
        public void SelectTest()
        {
            ReportHelper.CreateTest("Select from the dropdown");
            _driver.Navigate().GoToUrl(_golfUrl);
            _golfPage.Select("Sweden");
        }


        [Test]
        public void AddGolfTest()
        {
            ReportHelper.CreateTest("Add a golf course");
            _driver.Navigate().GoToUrl(_golfUrl);
            _golfPage.AddGolfCourse();
        }

        [Test]
        public void EditGolfTest()
        {
            ReportHelper.CreateTest("Editing a golf course information");
            _driver.Navigate().GoToUrl(_golfUrl);
            _golfPage.EditGolfCourse();
        }

        [Test]
        public void RemoveGolfTest()
        {
            ReportHelper.CreateTest("Delete an existing Golf Course");
            _driver.Navigate().GoToUrl(_golfUrl);
            _golfPage.DeleteGolfCourse();
        }

        [TearDown]
        public void Teardown()
        {
            _driver?.Quit();
            _driver?.Dispose();
            ReportHelper.FinalizeReport();
        }

    }
}