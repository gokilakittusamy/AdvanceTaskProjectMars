using AdvancedMarsAutomation.Pages;
using AdvancedMarsAutomation.Steps;
using AdvancedMarsAutomation.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Tests
{
    public class ShareSkillTest : GlobalHelper
    {
        LoginSteps loginSteps;
        HomePageSteps homePageSteps;
        NavigationMenuComponent navigationMenuComponent;
        ShareSkillSteps shareSkillSteps;
        TakeScreenshot takeScreenshot;
        public ShareSkillTest()
        {
            loginSteps = new LoginSteps();
            homePageSteps = new HomePageSteps();
            navigationMenuComponent = new NavigationMenuComponent();
            shareSkillSteps = new ShareSkillSteps();
            takeScreenshot = new TakeScreenshot();
        }
        [Test, Order(1)]
        /*  TC_ShareSkill_101 - Verify if the share skill button is visible and enabled
         *  TC_ShareSkill_102 - Verify if the share skill button redireects to ServiceListing page if clicked
            TC_ShareSkill_103 - Validate the add new share skill - with skill trade-Skill Exchange
            TC_ShareSkill_104 - Validate the add new share skill - with skill trade- credit
            TC_ShareSkill_106 - Validate the add new share skill
            TC_ShareSkill_107 to TC_ShareSkill_109 - Validate the input feilds in the add new share skill form 
        */
        public void AddValidShareSkillForValidUser()
        {
            test = extent.CreateTest("Share skill-Enter valid data").Info("Add skill with all possible valid data");

            loginSteps.DoLogin();
            homePageSteps.validateIsLoggedIn();
            String ValidDataFile = "ShareSkillWithValidData";
            shareSkillSteps.AddNewShareSkill(ValidDataFile);

            test.Log(Status.Pass, "TestCaseID:TC_106 - Verify if the valid user can add new valid share skill - Passed");
        }
        [Test, Order(2)]
        public void AddInvalidShareSkillForValidUser()
        {
            test = extent.CreateTest("Share skill-Enter Invalid data").Info("Add skill with all possible invalid data");

            loginSteps.DoLogin();
            homePageSteps.validateIsLoggedIn();
            String ValidDataFile = "ShareSkillWithInvalidData";
            shareSkillSteps.AddNewShareSkill(ValidDataFile);

            test.Log(Status.Pass, "TestCaseID:TC_106 - Verify if the Invalid user can add new valid share skill - Passed");
        }
    }
}
