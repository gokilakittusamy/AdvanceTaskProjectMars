﻿using AdvancedMarsAutomation.Pages.Components.ProfileOverview;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.AssertHelpers
{
    public class AssertHours
    {
        UserDetailsComponent userDetailsComponent = new UserDetailsComponent();

        public static void assertUpdatedHoursSuccessMessage(String expected, String actual)
        {
            Assert.Multiple(() =>
            {
                Assert.That(expected == actual, "Success message is correct for update hours");
                //Assert.That(expected != actual, $"Success message is incorrect for update hours. Actual message was {actual}");
            });
        }
    }
}
