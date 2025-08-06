using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using PageObjectModel.Source.Pages;
using System.Configuration;
using OpenQA.Selenium.Firefox;
using TestProject.Pages;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;

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

        [Test]
        public void SearchTest()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver);

            try
            {
                g.search("Sky Golf Course");
            }catch (NoSuchElementException e)
            {
                g.TakeScreenshot("golf");
            }

        }

        [Test]
        public void SelectTest()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver);

            g.select("Sweden");
        }

        [Test]
        public void AddGolfTest()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver);

            g.addGolfCourse();
        }

        [Test]
        public void EditGolfTest() 
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver);

            g.editGolfCourse();
        }

        [Test]
        public void RemoveGolfTest()
        {
            _driver.Navigate().GoToUrl(TestContext.Parameters["golf_url"]);
            GolfPage g = new GolfPage(_driver);

            g.deleteGolfCourse();
        } }

    }