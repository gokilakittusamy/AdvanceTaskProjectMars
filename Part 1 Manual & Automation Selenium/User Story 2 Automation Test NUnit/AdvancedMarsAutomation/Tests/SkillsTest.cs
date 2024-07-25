
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
    public class SkillsTest : GlobalHelper
    {
        LoginSteps loginSteps;
        HomePageSteps homePageSteps;
        SkillSteps skillSteps;
        TakeScreenshot takeScreenshot;

        public SkillsTest()
        {
            loginSteps = new LoginSteps();
            homePageSteps = new HomePageSteps();
            skillSteps = new SkillSteps();
            takeScreenshot = new TakeScreenshot();
        }

        [Test, Order(1)]
        /*  TestCaseID:TC_202   */
        public void AddValidSkillForValidUser()
        {
            test = extent.CreateTest("Skill-Enter valid data").Info("TestCaseID:TC_202- Verify if the user can enter a new record using valid input &  select the level");

            loginSteps.DoLogin();
            //homePageSteps.validateIsLoggedIn();
            homePageSteps.ClickOnSkillsTab();
            skillSteps.RemoveAllExistingSkills();
            String ValidDataFile = "SkillsWithValidData";
            skillSteps.AddSkill(ValidDataFile);

           test.Log(Status.Pass, "TestCaseID:TC_202 - Verify if the valid user can add new valid skill - Passed");
        }

        [Test, Order(2)]
        /*  TestCaseID:TC_601 to TC_604   */
        public void UpdateSkillForValidUser()
        {
            test = extent.CreateTest("Skill - Update skill data").Info("TestCaseID:TC_202- Verify if the user can edit");

            loginSteps.DoLogin();
            //homePageSteps.validateIsLoggedIn();
            homePageSteps.ClickOnSkillsTab();
            skillSteps.RemoveAllExistingSkills();
            
            String ValidEditDataFile = "EditSkillsData";
            skillSteps.EditSkill(ValidEditDataFile);

            test.Log(Status.Pass, "TestCaseID:TC_601 to TC_604- Verify if the valid user can update different values using skill - Passed");

        }
        [Test, Order(3)]
        /*  TestCaseID:TC_701   */
        public void DeleteValidSkillForValidUser()
        {
            test = extent.CreateTest("Skill-Delete valid data").Info("TestCaseID:TC_202- Verify if the user can delete skill");

            loginSteps.DoLogin();
            //homePageSteps.validateIsLoggedIn();
            homePageSteps.ClickOnSkillsTab();
            skillSteps.RemoveAllExistingSkills();
            String ValidDataFile = "SkillsWithValidData";
            skillSteps.AddSkill(ValidDataFile);

            String ValidDeleteDataFile = "DeleteSkillsData";
            skillSteps.DeleteSkill(ValidDeleteDataFile);

            test.Log(Status.Pass, "TestCaseID:TC_202- Verify if the valid user can delete skill - Passed");
        }
    }
}
