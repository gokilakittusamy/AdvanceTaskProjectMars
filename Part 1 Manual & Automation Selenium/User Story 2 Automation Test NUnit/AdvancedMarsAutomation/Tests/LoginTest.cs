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
    public class LoginTest:GlobalHelper
    {
        LoginSteps loginSteps;

        public LoginTest() {
           
            loginSteps = new LoginSteps();
        }
        
       

    }
}
