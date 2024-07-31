using AdvancedMarsAutomation.Pages.Components.ProfileOverview;
using AdvancedMarsAutomation.Steps;
using AdvancedMarsAutomation.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Tests
{
    public class LanguageTest : GlobalHelper
    {
        LoginSteps loginSteps;
        HomePageSteps homePageSteps;
        LanguageSteps lanaguageSteps;
        TakeScreenshot takeScreenshot;

        public LanguageTest()
        {
            loginSteps = new LoginSteps();
            homePageSteps = new HomePageSteps();
            lanaguageSteps = new LanguageSteps();
            takeScreenshot = new TakeScreenshot();
        }

        [Test, Order(1)]
        /*  TestCaseID:TC_202   */
        public void AddValidLanguageForValidUser()
        {
            test = extent.CreateTest("Language-Enter valid data").Info("TestCaseID:TC_202- Verify if the user can enter a new record using valid input &  select the level");

            loginSteps.DoLogin();
            homePageSteps.validateIsLoggedIn();
            homePageSteps.ClickOnLangaugesTab();
            lanaguageSteps.RemoveAllExistingLanguages();
            String ValidDataFile = "LanguageWithValidData";
            lanaguageSteps.AddLanguage(ValidDataFile);
            
            test.Log(Status.Pass, "TestCaseID:TC_202- Verify if the valid user can add new valid language - Passed");
        }
        
        [Test, Order(2)]
        /*  TestCaseID:TC_204  to TC_208 */
        public void AddInvalidLanguageForValidUser()
        {
            test = extent.CreateTest("Language - User trying add invalid language and more than limited data")
                            .Info("TestCaseID:TC_204- Verify if the user can enter invalid data and more than limited data");

            loginSteps.DoLogin();
            homePageSteps.validateIsLoggedIn();
            homePageSteps.ClickOnLangaugesTab();
            lanaguageSteps.RemoveAllExistingLanguages();
            String LanguageWithInvalidData = "LanguageWithInvalidData";
            lanaguageSteps.AddLanguage(LanguageWithInvalidData);

            test.Log(Status.Pass, "TestCaseID:TC_204- Verify if the valid user can add new valid language - Passed");
        }
       
        [Test, Order(6)]
        /*  TestCaseID:TC_401  to TC_402 */
        public void UpdateLanguageForValidUser()
        {
            test = extent.CreateTest("Language - User update the language")
                                .Info("TestCaseID:TC_401- Verify if the user can click the edit button and update the record ");

            loginSteps.DoLogin();
            homePageSteps.validateIsLoggedIn();
            homePageSteps.ClickOnLangaugesTab();
            lanaguageSteps.RemoveAllExistingLanguages();
            
            String ValidEditLanguageDataFile = "EditLanguageData";
            lanaguageSteps.EditLanguage(ValidEditLanguageDataFile);
            
            test.Log(Status.Pass, "TestCaseID:TC_101- Verify if the valid user can add new valid language - Passed");
        }

        [Test, Order(5)]
        /*  TestCaseID:TC_301   */
        public void DeleteLanguageForValidUser()
        {
            test = extent.CreateTest("Language - User deleting the language")
                                .Info("TestCaseID:TC_301- Verify if the User can Click the Delete button to delete the created records");

            loginSteps.DoLogin();
            homePageSteps.validateIsLoggedIn();
            homePageSteps.ClickOnLangaugesTab();
            lanaguageSteps.RemoveAllExistingLanguages();
            String ValidDataFile = "DeleteLanguageData";
            lanaguageSteps.AddLanguage(ValidDataFile);

            lanaguageSteps.DeleteLanguage(ValidDataFile);

            test.Log(Status.Pass, "TestCaseID:TC_301- Verify if the valid user can delete valid language - Passed");
        }
    }
}
