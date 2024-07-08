using AdvancedMarsAutomation.Steps;
using AdvancedMarsAutomation.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Tests
{
    public class AvailabilityTest:GlobalHelper
    {
        LoginSteps loginSteps;

        public AvailabilityTest()
        {
            loginSteps = new LoginSteps();
        }

        [Test]
        /*  TestCaseID:TC_101   */
        public void EditAvailabilityForValidUser()
        {
            Console.WriteLine("Hello World");
        }
    }
}
