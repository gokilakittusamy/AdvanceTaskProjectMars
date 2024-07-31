using AdvancedMarsAutomation.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.AssertHelpers
{
    public class ShareSkillAssertHelper:GlobalHelper
    {
        public static void AssertShareSkillCustomMessage(string customMessage)
        {
            Assert.Inconclusive(customMessage);
        }

        public static void AssertPageTitleSuccessMessage(string expectedPageTitle, string currentPageTitle)
        {
            currentPageTitle = driver.Title;
            Assert.That(expectedPageTitle == currentPageTitle, "Page redirected to listing mangement sucessfully after creating the share skill");
        }

        public static void AssertSkillShareSuccessMessage(string expected, string actual)
        {
            Console.WriteLine($"expected-{expected}");

            Console.WriteLine($"actual-{actual}");

            Assert.That(expected == actual, "Success message is correct for share skill");
        }
    }
}
