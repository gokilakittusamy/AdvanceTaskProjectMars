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
    public class ShareSkillTest : GlobalHelper
    {
        LoginSteps loginSteps;
        HomePageSteps homePageSteps;
        ShareSkillSteps shareSkillSteps;
        TakeScreenshot takeScreenshot;
        public ShareSkillTest()
        {
            loginSteps = new LoginSteps();
            homePageSteps = new HomePageSteps();
            shareSkillSteps = new ShareSkillSteps();
            takeScreenshot = new TakeScreenshot();
        }
        [Test, Order(1)]
        [Ignore("Ignored as it is yet test")]
        /*  TC_ShareSkill_101 - Verify if the share skill button is visible and enabled
         *  TC_ShareSkill_102 - Verify if the share skill button redireects to ServiceListing page if clicked
            TC_ShareSkill_103 - Validate the add new share skill - with skill trade-Skill Exchange
            TC_ShareSkill_104 - Validate the add new share skill - with skill trade- credit
            TC_ShareSkill_106 - Validate the add new share skill
            TC_ShareSkill_107 to TC_ShareSkill_109 - Validate the input feilds in the add new share skill form 
        */
        public void AddValidSkillForValidUser()
        {
        }
    }
}
