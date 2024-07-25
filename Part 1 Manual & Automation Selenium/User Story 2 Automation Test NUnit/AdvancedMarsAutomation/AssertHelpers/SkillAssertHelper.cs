using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.AssertHelpers
{
    public class SkillAssertHelper
    {
        public static void AssertSkillSuccessMessage(String expected, String actual)
        {
            Assert.That(expected == actual, "Success message is correct for skill");
        }

        public static void AssertSkillErrorMessage(string expected, string actual)
        {
            Assert.That(expected == actual, "Error message is correct for skill");
        }
        public static void AssertSkillCustomMessage(string customMessage)
        {
            Assert.Inconclusive(customMessage);
        }

        internal static void AssertLanguageCustomMessage(string v)
        {
            throw new NotImplementedException();
        }
    }
}
