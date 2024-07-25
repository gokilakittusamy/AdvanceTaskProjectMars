using NUnit.Framework;
using AdvancedMarsAutomation.Pages.Components.ProfileOverview;

namespace AdvancedMarsAutomation.AssertHelpers

{
    public class AssertAvailability
    {
        public static void assertUpdatedAvailabilitySuccessMessage(String expected, String actual)
        {
            //Assert.AreEqual(expected, actual, "Success message is correct for  update availability");
            Assert.That(expected == actual, "Success message is correct for update availability");

        }
    }
}
