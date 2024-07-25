using AdvancedMarsAutomation.Pages.Components.ProfileOverview;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.AssertHelpers
{
    public class LanguageAssertHelper
    {
        public static void AssertLangaugeSuccessMessage(String expected, String actual)
        {
            Assert.That(expected == actual, "Success message is correct for Langauge");
        }

        public static void AssertAddLangaugeErrorMessage(string expected, string actual)
        {
            Assert.That(expected == actual, "Error message is correct for Langauge");
        }

        public static void AssertLangaugeCustomMessage(string customMessage)
        {
            //Assert.Inconclusive(customMessage);
            //Assert.Warn(customMessage);
            Assert.Ignore(customMessage);
        }

        public static void AssumeLangaugeMessage(string expected, string acutalSuccessMessage)
        {
            //Assume.That(expected,);
            Assert.Warn($"{acutalSuccessMessage}");
        }
    }
}
