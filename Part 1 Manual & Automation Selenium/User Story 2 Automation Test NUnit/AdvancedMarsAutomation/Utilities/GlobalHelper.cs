using AdvancedMarsAutomation.Model;
using AdvancedMarsAutomation.Pages;
using AdvancedMarsAutomation.Pages.Components.SignIn;
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
        ReadExcelHelper excelObj = new ReadExcelHelper();
        private List<Dictionary<string, string>> _excelData;
        

        [SetUp]
        public void SetUp()
        {
            UserInformation userInformation = new UserInformation();
            LoginComponent loginpageComponentObj = new LoginComponent();
            SplashPage splashPageObj = new SplashPage();

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Window.Maximize();
            splashPageObj.ClickSignInButton();
                        
            // Read the Excel file ReadExcelHelper
            _excelData = excelObj.ReadExcelFile(ConstantHelper.loginExcelSheetPath);
            bool readOnlyFirstRow = false;
            // Use only the first set of data
            if (_excelData.Count > 0)
            {
                foreach (var row in _excelData)
                {
                    if (!readOnlyFirstRow)
                    {
                        userInformation.setEmail(row["UserName"].ToString());
                        userInformation.setPassword(row["Password"]);
                        readOnlyFirstRow = true;
                    }
                }
                loginpageComponentObj.DoSignIn(userInformation);
            }
            else
            {
                Assert.Fail("No data found in the Excel file to login in.");
            }
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
