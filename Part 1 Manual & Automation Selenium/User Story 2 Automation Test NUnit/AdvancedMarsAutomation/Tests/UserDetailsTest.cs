using NUnit.Framework;
using AdvancedMarsAutomation.AssertHelpers;
using AdvancedMarsAutomation.Model;
using AdvancedMarsAutomation.Pages.Components.ProfileOverview;
using AdvancedMarsAutomation.Steps;
using AdvancedMarsAutomation.Utilities;
using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace AdvancedMarsAutomation.Tests
{

    public class UserDetailsTest : GlobalHelper
    {
        LoginSteps loginSteps;
        HomePageSteps homePageSteps;
        UserDetailsSteps userDetailsSteps;
        TakeScreenshot takeScreenshot;
        public UserDetailsTest()
        {
            loginSteps = new LoginSteps();
            homePageSteps = new HomePageSteps();
            userDetailsSteps = new UserDetailsSteps();
            takeScreenshot = new TakeScreenshot();
        }

        [Test]
        /*  TestCaseID:TC_101   */
        public void EditAvailabilityForValidUser()
        {
            test = extent.CreateTest("UserDetails-Availability").Info("TestCaseID:TC_101- Verify if the user can edit Availability ");

            loginSteps.DoLogin();
            homePageSteps.validateIsLoggedIn();
            homePageSteps.ClickOnAvailabilityEditButton();
            userDetailsSteps.EditAvailability();

            string screenshotPath = takeScreenshot.Screenshot(driver);
            test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            test.Log(Status.Pass, "TestCaseID:TC_101- Verify if the user can edit Availability - Passed");
        }

        
        [Test]
        /*  TestCaseID:TC_103 */
        public void EditHoursForValidUser()
        {
            test = extent.CreateTest("UserDetails-Hours").Info("TestCaseID:TC_103- Verify if the user can edit Hours");

            loginSteps.DoLogin();
            homePageSteps.validateIsLoggedIn();
            homePageSteps.ClickOnHoursEditButton();
            userDetailsSteps.EditHours();

            string screenshotPath = takeScreenshot.Screenshot(driver);
            test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            test.Log(Status.Pass, "TestCaseID:TC_101- Verify if the user can edit Hours - Passed");
        }

        [Test]
        /*  TestCaseID:TC_105  */
        public void EditEarnTargetForValidUser()
        {
            test = extent.CreateTest("UserDetails-EarnTarget").Info("TestCaseID:TC_105- Verify if the user can edit Earn Target ");

            loginSteps.DoLogin();
            homePageSteps.validateIsLoggedIn();
            homePageSteps.ClickOnEarnTargetEditButton();
            userDetailsSteps.EditEarnTarget();

            string screenshotPath = takeScreenshot.Screenshot(driver);
            test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            test.Log(Status.Pass, "TestCaseID:TC_101- Verify if the user can edit EarnTarget - Passed");
        }
    }
}
