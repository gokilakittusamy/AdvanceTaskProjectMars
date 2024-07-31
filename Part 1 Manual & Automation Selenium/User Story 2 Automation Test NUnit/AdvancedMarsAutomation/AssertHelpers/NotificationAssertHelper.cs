using AdvancedMarsAutomation.Pages.Components.CompactMenu;
using AdvancedMarsAutomation.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.AssertHelpers
{
    public class NotificationAssertHelper
    {
        NotificationOverview notificationOverview = new NotificationOverview();
       
        public void AssertNotificationSelectAll()
        {
            bool allchecked = notificationOverview.AssertSelectAll();
            Assert.That(allchecked, Is.True, "All the notification are not selected");
        }

        public void AssertNotificationUnSelectAll()
        {
            bool allnotchecked = notificationOverview.AssertUnSelectAll();
            Assert.That(allnotchecked, Is.True, "All the notification are selected");
        }

        public void AssertNotificationMessage(string expectedMessage, string acutalMessage)
        {
            Assert.That(expectedMessage == acutalMessage, "Success message is correct for notification");

        }
    }
}
