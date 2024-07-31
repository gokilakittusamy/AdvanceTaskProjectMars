using AdvancedMarsAutomation.AssertHelpers;
using AdvancedMarsAutomation.Pages.Components.CompactMenu;
using AdvancedMarsAutomation.Pages.Components.HomePageOverveiw;
using AdvancedMarsAutomation.Pages.Components.ProfileOverview;
using AdvancedMarsAutomation.Pages.Components.ShareSkill;
using AdvancedMarsAutomation.Steps;
using AdvancedMarsAutomation.Utilities;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Tests
{
    public class NotificationSteps:GlobalHelper
    {
        private IWebElement notificationDiv;
        private IWebElement SeeAllNotificationDiv;
        private IEnumerable<IWebElement> selectAllCheckBoxList;
        private IWebElement unSelectAllNotification;
        private IWebElement markAsReadNotification;
        private IWebElement deleteNotification;
        private IWebElement firstNotificationSelect;

        NotificationOverview notificationOverview;
        NotificationAssertHelper notificationAssertHelper;
        CompactMenuComponent compactMenuComponent; 

        TakeScreenshot takeScreenshot;
        public NotificationSteps()
        {
           notificationOverview = new NotificationOverview();
           notificationAssertHelper = new NotificationAssertHelper();
           compactMenuComponent = new CompactMenuComponent();
           
            takeScreenshot = new TakeScreenshot();
        }

        public void SeeAllNotification()
        {
            compactMenuComponent.ClickOnNotification();
            compactMenuComponent.SeeAllNotification();
            Thread.Sleep(2000);
            notificationOverview.getScreenshot();
            //NotificationAssertHelper.AssertPageTitleSuccessMessage("", );
        }

        public void SelectAllNotification()
        {
            notificationOverview.ClickOnSelectAll();
            Thread.Sleep(1000);
            notificationOverview.getScreenshot();
            //NotificationAssertHelper.AssertNotificationSelectAll(notificationComponent);
            //NotificationAssertHelper.AssertNotificationSelectAll();
            notificationAssertHelper.AssertNotificationSelectAll();
        }

        public void UnSelectAllNotification()
        {
            notificationOverview.ClickOnSelectAll();
            notificationOverview.ClickOnUnSelectAll();
            notificationOverview.getScreenshot();
            notificationAssertHelper.AssertNotificationUnSelectAll();
        }

        public void DeleteNotification()
        {
            string screenshotPath = takeScreenshot.Screenshot(driver);
            notificationOverview.DeleteNotification();
            Thread.Sleep(2000);
            String acutalSuccessMessage = notificationOverview.getStatusMessage();
            notificationOverview.getScreenshot();
            notificationAssertHelper.AssertNotificationMessage("Notification updated", acutalSuccessMessage);
        }

        public void MarkAsReadNotification()
        {
            string screenshotPath = takeScreenshot.Screenshot(driver);
            notificationOverview.ClickOnSelectAll();
            notificationOverview.MarkAsReadNotification();
            Thread.Sleep(1000);
            String acutalSuccessMessage = notificationOverview.getStatusMessage();
            notificationOverview.getScreenshot();
            notificationAssertHelper.AssertNotificationMessage("Notification updated", acutalSuccessMessage);

        }
    }
}
