using AdvancedMarsAutomation.Pages.Components.CompactMenu;
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
    public class NotificationTest:GlobalHelper
    {
        LoginSteps loginSteps;
        HomePageSteps homePageSteps;
        SkillSteps skillSteps;
        NotificationSteps notificationSteps;
        NotificationOverview notificationOverview;

        TakeScreenshot takeScreenshot;

        public NotificationTest()
        {
            loginSteps = new LoginSteps();
            homePageSteps = new HomePageSteps();
            skillSteps = new SkillSteps();
            notificationSteps = new NotificationSteps();
            notificationOverview = new NotificationOverview();

            takeScreenshot = new TakeScreenshot();
        }
        
        [Test, Order(1)]
        /*  TestCaseID:Verify if the user can view all of his notification */
        public void SeeAllNotificationForValidUser()
        {
            test = extent.CreateTest("Notification -see all notification")
                       .Info("TestCaseID:- Verify if the user can view all of his notification");

            loginSteps.DoLogin();
            homePageSteps.validateIsLoggedIn();
            Thread.Sleep(3000);
            notificationSteps.SeeAllNotification();

            test.Log(Status.Pass, "TestCaseID:Verify if the user can view all of his notification - Passed");
        }

        [Test, Order(2)]
        /*  TestCaseID:Verify if the user can select all of his notification */
        public void SelectAllNotificationForValidUser()
        {
            test = extent.CreateTest("Notification -select all notification")
                       .Info("TestCaseID:- Verify if the user can select all of his notification");

            loginSteps.DoLogin();
            homePageSteps.validateIsLoggedIn();
            Thread.Sleep(3000);
            notificationSteps.SeeAllNotification();
            notificationSteps.SelectAllNotification();

            test.Log(Status.Pass, "TestCaseID:Verify if the user can select all of his notification - Passed");
        }

        [Test, Order(3)]
        /*  TestCaseID:Verify if the user can unselect all of his notification */
        public void UnselectAllNotificationForValidUser()
        {
            test = extent.CreateTest("Notification -unselect all notification")
                       .Info("TestCaseID:- Verify if the user can unselect all of his notification");

            loginSteps.DoLogin();
            homePageSteps.validateIsLoggedIn();
            Thread.Sleep(3000);
            notificationSteps.SeeAllNotification();
            notificationSteps.SelectAllNotification();
            notificationSteps.UnSelectAllNotification();

            test.Log(Status.Pass, "TestCaseID:Verify if the user can unselect all of his notification - Passed");
        }

        [Test, Order(4)]
        /*  TestCaseID:Verify if the user can unselect all of his notification */
        public void DeleteSelectedNotificationForValidUser()
        {
            test = extent.CreateTest("Notification -Delete Selected notification")
                       .Info("TestCaseID:- Verify if the user can Delete Selected notification");

            loginSteps.DoLogin();
            homePageSteps.validateIsLoggedIn();
            Thread.Sleep(3000);
            notificationSteps.SeeAllNotification();
            notificationSteps.DeleteNotification();
            
            test.Log(Status.Pass, "TestCaseID:Verify if the user can Delete Selected notification - Passed");
        }


        [Test, Order(4)]
        [Ignore ("just once")]
        /*  TestCaseID:Verify if the user can unselect all of his notification */
        public void MarkSelectedAsReadNotificationForValidUser()
        {
            test = extent.CreateTest("Notification -mark as read notification")
                       .Info("TestCaseID:- Verify if the user can mark as read notification");

            loginSteps.DoLogin();
            homePageSteps.validateIsLoggedIn();
            Thread.Sleep(3000);
            notificationSteps.SeeAllNotification();
            notificationSteps.MarkAsReadNotification();

            test.Log(Status.Pass, "TestCaseID:Verify if the user can mark as read notification - Passed");
        }
    }
}
