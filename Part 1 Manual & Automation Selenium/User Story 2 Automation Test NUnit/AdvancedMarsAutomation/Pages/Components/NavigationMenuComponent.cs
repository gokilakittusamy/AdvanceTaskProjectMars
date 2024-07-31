using AdvancedMarsAutomation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Pages
{
    public class NavigationMenuComponent: GlobalHelper
    {
        private IWebElement shareSkillLink;

        public void RenderShareSkillLink()
        {
            try
            {
                shareSkillLink = driver.FindElement(By.LinkText("Share Skill"));
                /*
                 shareSkillLink = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/div[2]/a"));
                
                 //*[@id="listing-management-section"]/section[1]/div/div[2]/a
                 */
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void ClickOnShareSkillsLink()
        {
            RenderShareSkillLink();
            shareSkillLink.Click();
            Thread.Sleep(1000);
        }
    }
}
