using AdvancedMarsAutomation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Pages.Components.HomePageOverveiw
{
    public class CompactMenuComponent:GlobalHelper
    {
        private IWebElement SeeAllNotificationDiv;
        private IWebElement notificationDiv;

        public void RenderNotificationDiv()
        {
            try
            {
                notificationDiv = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div/i[1]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void RenderSeeAllNotification()
        {
            try
            {
                SeeAllNotificationDiv = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div/div/span/div/div[2]/div/center"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void ClickOnNotification()
        {
            Thread.Sleep(2000);
            RenderNotificationDiv();
            notificationDiv.Click();
        }
        public void SeeAllNotification()
        {
            Thread.Sleep(2000);
            RenderSeeAllNotification();
            SeeAllNotificationDiv.Click();
        }
    }
}