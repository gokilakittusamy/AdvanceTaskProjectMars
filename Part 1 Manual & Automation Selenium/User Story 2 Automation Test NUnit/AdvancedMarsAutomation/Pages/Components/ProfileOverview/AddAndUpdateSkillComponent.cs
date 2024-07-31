using AdvancedMarsAutomation.Model;
using AdvancedMarsAutomation.Utilities;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Pages.Components.ProfileOverview
{
     public class AddAndUpdateSkillComponent:GlobalHelper
    {
        private IWebElement addNewSkillButton;
        private IWebElement skillNameTextBox;
        private IWebElement skillLevelSelect;
        private IWebElement addSkillButton;
        
        private IWebElement skillUpdateNameTextBox;
        private IWebElement skillUpdateLevelSelect;
        private IWebElement skillUpdateButton;
        private IWebElement skillCancelUpdateButton;

        private IWebElement cancelButton;
        private IWebElement messageWindow;
        private IWebElement closeMessageIcon;


        public void RenderAddSkillButton()
        {
            try {
                addNewSkillButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void RenderAddSkill()
        {
            try
            {
                skillNameTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
                skillLevelSelect = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
                addSkillButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void RenderUpdateSkill()
        {
            try
            {
                skillUpdateNameTextBox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
                skillUpdateLevelSelect = driver.FindElement(By.XPath("//select[@name='level']"));
                skillUpdateButton = driver.FindElement(By.XPath("//input[@value='Update']"));
                skillCancelUpdateButton = driver.FindElement(By.XPath("//input[@value='Cancel']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderAddMessage()
        {
            try
            {
                /*
                messageWindow = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                closeMessageIcon = driver.FindElement(By.XPath("//div[@class='ns-close']"));
                */
                //class="ns-box ns-growl ns-effect-jelly ns-type-success ns-show"
                //messageWindow = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
                messageWindow = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                closeMessageIcon = driver.FindElement(By.XPath("//a[@class='ns-close']"));
 }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void AddEachSkill(SkillModel skillData)
        {
            RenderAddSkillButton();
            Thread.Sleep(2000);
            addNewSkillButton.Click();
            
            RenderAddSkill();
            skillNameTextBox.Clear();
            skillNameTextBox.SendKeys(skillData.SkillName);

            SelectElement levelDropdown = new SelectElement(skillLevelSelect);
            levelDropdown.SelectByValue(skillData.SkillLevel);
            addSkillButton.Click();
            Thread.Sleep(2000);
        }

        public string getStatusMessage()
        {
            //Saving error or success message
            renderAddMessage();
            String message = messageWindow.Text;

            //If any message visible close it
            Wait.WaitToBeClickable(driver, "XPath", "//a[@class='ns-close']", 10);
            closeMessageIcon.Click();
            
            if (message == "Please enter all the fields")
            {
                cancelButton.Click();
            }
            //Console.WriteLine($"message--{message}");
            return message;
        }

        public void AddBeforeUpdateSkill(SkillModel addBeforeUpdateSkill)
        {
             AddEachSkill(addBeforeUpdateSkill);
        }

        public void UpdateSkill(SkillModel updateSkill)
        {
            Thread.Sleep(2000);
            RenderUpdateSkill();
            
            skillUpdateNameTextBox.Clear();
            skillUpdateNameTextBox.SendKeys(updateSkill.SkillName);

            SelectElement levelDropdown = new SelectElement(skillUpdateLevelSelect);
            levelDropdown.SelectByValue(updateSkill.SkillLevel);

            skillUpdateButton.Click();
            Thread.Sleep(2000);
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                IWebElement button = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@value='Update']")));

                skillCancelUpdateButton.Click();
            }
            catch (WebDriverTimeoutException)
            {
            }
        }
     }
}
