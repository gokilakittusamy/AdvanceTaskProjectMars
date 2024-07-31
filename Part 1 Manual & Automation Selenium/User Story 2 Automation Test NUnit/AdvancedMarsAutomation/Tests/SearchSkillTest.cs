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
    public class SearchSkillTest: GlobalHelper
    {
        LoginSteps loginSteps;
        HomePageSteps homePageSteps;
        SkillSteps skillSteps;
        TakeScreenshot takeScreenshot;

        public SearchSkillTest()
        {
            loginSteps = new LoginSteps();
            homePageSteps = new HomePageSteps();
            skillSteps = new SkillSteps();
            takeScreenshot = new TakeScreenshot();
        }
        
        [Test, Order(1)]
         /*  TestCaseID:TC_SearchSkill_207
                        Verify if the user can able to view a skill that he created using share skill form  by Main Category */
        public void SearchSkillByMainCategoryForValidUser()
        { 
            test = extent.CreateTest("Search Skill-search by main category")
                            .Info("TestCaseID:TC_SearchSkill_207- Verify if the user can able to view a skill that he created using share skill form  by Main Category");

            loginSteps.DoLogin();
            homePageSteps.validateIsLoggedIn();
            homePageSteps.GoToHomePage();
            Thread.Sleep(3000);
            String ValidDataFile = "SearchMainCategoryValidData";
            homePageSteps.CheckMainCategory(ValidDataFile);

            test.Log(Status.Pass, "TestCaseID:TC_202 - Verify if the valid user can search skill by main category - Passed");
        }

        [Test, Order(2)]
        /*  TestCaseID:TC_SearchSkill_207
                       Verify if the user can able to view a skill that he created using share skill form  by Main and sub Category */
        public void SearchSkillByMainAndSubCategoryForValidUser()
        {
            test = extent.CreateTest("Search Skill-search by main and sub category")
                            .Info("TestCaseID: - Verify if the user can able to view a skill that he created using share skill form by Main and sub Category");

            loginSteps.DoLogin();
            homePageSteps.validateIsLoggedIn();
            homePageSteps.GoToHomePage();
            Thread.Sleep(3000);
            String ValidDataFile = "SearchMainAndSubCategoryValidData";
            homePageSteps.CheckMainAndSubCategory(ValidDataFile);

            test.Log(Status.Pass, "TestCaseID:- Verify if the valid user can search skill by main and sub category - Passed");
        }

        [Test, Order(3)]
        /*  TestCaseID:
                       Verify if the user can able to view a skill that he created using share skill form  by Main and sub Category with the skill title */
        public void SearchByMainAndSubCategoryWithSkillTitleForValidUser()
        {
            test = extent.CreateTest("Search Skill-search by main and sub category with skill title")
                            .Info("TestCaseID: - Verify if the user can able to view a skill that he created using share skill form by Main and sub Category with skill title");

            loginSteps.DoLogin();
            homePageSteps.validateIsLoggedIn();
            homePageSteps.GoToHomePage();
            Thread.Sleep(3000);
            String ValidDataFile = "SearchCategoriesWithSkillTitleValidData";
            homePageSteps.CheckCategoriesWithSkillTitle(ValidDataFile);

            test.Log(Status.Pass, "TestCaseID:- Verify if the valid user can search skill by main and sub category with skill title- Passed");
        }

        [Test, Order(4)]
        /*  TestCaseID:
                       Verify if the user can able to view a skill that he created using share skill using filter */
        public void SearchSkillByFilterForValidUser()
        {
            test = extent.CreateTest("Search Skill-search by skill by filter")
                            .Info("TestCaseID: - Verify if the user can search by skill by filter");

            loginSteps.DoLogin();
            homePageSteps.validateIsLoggedIn();
            homePageSteps.GoToHomePage();
            Thread.Sleep(3000);
            String ValidDataFile = "SearchSkillUsingFilterValidData";
            homePageSteps.CheckSkillUsingFilter(ValidDataFile);

            test.Log(Status.Pass, "TestCaseID:- Verify if the user can search by skill by filter - Passed");
        }


        [Test, Order(4)]
        /*  TestCaseID:
                       Verify if the user can search using username */
        public void SearchSkillByUserNameForValidUser()
        {
            test = extent.CreateTest("Search Skill-searchskill by username")
                            .Info("TestCaseID: - Verify if the user can search using username");

            loginSteps.DoLogin();
            homePageSteps.validateIsLoggedIn();
            homePageSteps.GoToHomePage();
            Thread.Sleep(3000);
            String ValidDataFile = "SearchSkillUsingUserNameValidData";
            homePageSteps.CheckSkillUsingUserName(ValidDataFile);

            test.Log(Status.Pass, "TestCaseID:- Verify if the user can search using username - Passed");
        }
    }
}
