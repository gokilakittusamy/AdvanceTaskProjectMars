using Advanced_ProjectMars.Utilities;
using AdvancedMarsAutomation.Model;
using AdvancedMarsAutomation.Pages;
using AdvancedMarsAutomation.Pages.Components.SignIn;
using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OfficeOpenXml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Utilities
{
    public class GlobalHelper
    {
        public static IWebDriver driver;

        public static ExtentReports extent;
        //public static AventStack.ExtentReports.ExtentReports extent;
        public static ExtentTest test;
        public String currentPageTitle;
        public String currentUserName;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ExtentReportHelper.ExtentStart();
        }

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Window.Maximize();
        }

       
        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }


        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
