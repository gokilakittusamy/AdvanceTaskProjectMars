using AdvancedMarsAutomation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Pages.Components.ProfileOverview
{
    public class ProfileMenuTabsComponents:GlobalHelper
    {
        private IWebElement languagesTab;
        private IWebElement skillsTab;
        private IWebElement educationTab;
        private IWebElement certificationsTab;
    
        public void RenderComponents()
        {
            try
            {
                languagesTab = driver.FindElement(By.XPath("//a[text()='Languages']"));
                skillsTab = driver.FindElement(By.XPath("//a[text()='Skills']"));
                /*educationTab = driver.FindElement(By.XPath("//a[text()='Education']"));
                certificationsTab = driver.FindElement(By.XPath("//a[text()='Certifications']"));*/
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void ClickLangaugesTab()
        {
            RenderComponents();
            languagesTab.Click();
            Thread.Sleep(1000);
        }

        public void ClickSkillsTab()
        {
            RenderComponents();
            skillsTab.Click();
            Thread.Sleep(1000);
        }
    }
}
