using NUnit.Framework;
using AdvancedMarsAutomation.Model;
using AdvancedMarsAutomation.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Pages.Components.ProfileOverview
{
    public class UserDetailsComponent:GlobalHelper
    {
        private IWebElement availabilityEditButton;
        private IWebElement availabilitySelectButton;
        private IWebElement updatedAvailability;

        private IWebElement hoursEditButton;
        private IWebElement hoursSelectButton;
        private IWebElement updatedHours;
        
        private IWebElement earnTargetEditButton;
        private IWebElement earnTargetSelectButton;
        private IWebElement updatedEarnTarget;
        
        private IWebElement cancelButton;
        private IWebElement messageWindow;
        private IWebElement closeMessageIcon;

        public void RenderAvailabilityEditButton()
        {
            try
            {
                availabilityEditButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));
                //cancelButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void RenderAvailabilitySelect()
        {
            try
            {
                 availabilitySelectButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void RenderHoursEditButton()
        {
            try
            {
                hoursEditButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i"));
                //cancelButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void RenderEarnTargetEditButton()
        {
            try
            {
                earnTargetEditButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i"));
                //cancelButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void RenderHoursSelect()
        {
            try
            {
                hoursSelectButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void RenderEarnTargetSelect()
        {
            try
            {
                earnTargetSelectButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select"));
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
                messageWindow = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                closeMessageIcon = driver.FindElement(By.XPath("//*[@class='ns-close']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void RenderUserDetailsAssert()
        {
            Thread.Sleep(1000);
            updatedAvailability = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span"));
            updatedHours = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span"));
            /* updatedEarnTarget = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span"));*/
        }

        public void ClickAvailabilityEditButton()
        {
            RenderAvailabilityEditButton();
            availabilityEditButton.Click();
            Thread.Sleep(1000);
        }

        public void EditAvailability(UserAvailability userAvailability)
        {
            RenderAvailabilitySelect();

            SelectElement availabilityDropdown = new SelectElement(availabilitySelectButton);
            availabilityDropdown.SelectByText(userAvailability.getAvailability());
            Thread.Sleep(1000);
        }
        public string AssertAvailability()
        {
            RenderUserDetailsAssert();
            return updatedAvailability.Text;
        }
        public void ClickHoursEditButton()
        {
            RenderHoursEditButton();
            hoursEditButton.Click();
            Thread.Sleep(1000);
        }


        public void EditHours(UserHours userHours)
        {
            RenderHoursSelect();

            SelectElement hoursDropdown = new SelectElement(hoursSelectButton);
            hoursDropdown.SelectByText(userHours.getHours());
            Thread.Sleep(1000);
        }


        public String getSuccessMessage()
        {
            //Saving error or success message
            renderAddMessage();
            String message = messageWindow.Text;

            //If any message visible close it
            Wait.WaitToBeClickable(driver, "XPath", "//*[@class='ns-close']", 5);
            closeMessageIcon.Click();
            /*
            if (message == "Please enter all the fields")
            {
                cancelButton.Click();
            }
            */
            return message;
        }

        public void ClickEarnTargetEditButton()
        {
            RenderEarnTargetEditButton();
            earnTargetEditButton.Click();
            Thread.Sleep(1000);
        }

        public void EditEarnTarget(UserEarnTarget userEarnTarget)
        {
            RenderEarnTargetSelect();

            SelectElement EarnTargetDropdown = new SelectElement(earnTargetSelectButton);
            EarnTargetDropdown.SelectByText(userEarnTarget.getEarnTarget());
            Thread.Sleep(1000);
        }

    }
}
