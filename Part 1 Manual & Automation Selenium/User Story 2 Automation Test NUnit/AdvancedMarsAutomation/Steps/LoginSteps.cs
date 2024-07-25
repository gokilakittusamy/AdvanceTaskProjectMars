using AdvancedMarsAutomation.Model;
using AdvancedMarsAutomation.Pages;
using AdvancedMarsAutomation.Pages.Components.SignIn;
using AdvancedMarsAutomation.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Steps
{
    public class LoginSteps
    {
        SplashPage splashPageObj = new SplashPage();
        LoginComponent loginpageComponentObj = new LoginComponent();
        ReadExcelHelper excelObj = new ReadExcelHelper();
        UserInformation userInformation = new UserInformation();
        private List<Dictionary<string, string>> _excelData;

        public void DoLogin()
        {
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
                        userInformation.setEmail(row["UserName"]);
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
    }
}
