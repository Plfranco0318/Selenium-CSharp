using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProject.Pages;

//using OpenQA.Selenium.Edge;



namespace TestProject
{
    public class TestsGolf
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            
            _driver = new ChromeDriver();
            //_driver = new FirefoxDriver();
            _driver.Manage().Window.Maximize();

        }

        //public static List<TestCaseData> TestCases
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

        public static List<TestCaseData> TestCases
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



        [Test]
        public void SearchTest()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver);

            try
            {
                g.Search("Sky Golf Course");
            }catch (NoSuchElementException e)
            {
                g.TakeScreenshot("golf");
            }

        }

        [TestCase("Sky Golf Course")]
        [TestCase("Tiger Golf")]
        [TestCase("Tiger B")]

        public void SearchTestCases(string name)
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver);

            try
            {
                g.Search(name);
            }catch(NoSuchElementException e)
            {
                g.TakeScreenshot("gold");
            }
        }

        [TestCaseSource("TestCases")]
        [Test]
        public void SelectTestCases(string country)
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver);
            try { g.Select(country); } catch (NoSuchElementException e) { Console.WriteLine(e); }
        }

        [TestCaseSource("TestCases")]
        [Test]
        public void AddGolfTestCases(string a, string b, string c, string d, string e, string f, string i, string h, string l, string m)
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver);

            g.AddGolfCourseTest(a, b, c, d, e, f, i, h, l, m);
        }



        [Test]
        public void SelectTest()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver);

            g.Select("Sweden");
        }


        [Test]
        public void AddGolfTest()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver);

            g.AddGolfCourse();
        }

        [Test]
        public void EditGolfTest() 
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver);

            g.EditGolfCourse();
        }

        [Test]
        public void RemoveGolfTest()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver);

            g.DeleteGolfCourse();
        }

        [TearDown]
        public void Teardown()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
                 
    }

}