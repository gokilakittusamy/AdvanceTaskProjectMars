using AdvancedMarsAutomation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Pages.Components.HomePageOverveiw
{
    public class HomePage : GlobalHelper
    {
        private IWebElement userNameLabel;
        public void renderComponents()
        {
            try
            {
                userNameLabel = driver.FindElement(By.XPath("//span[contains(@class,'item ui')]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public string getFirstName()
        {
            //Return username
            try
            {
                renderComponents();
                return userNameLabel.Text;

            }
            catch (Exception ex)
            {
                driver.Navigate().Refresh();
                return ex.Message;
            }
        }

        public void NavigateToHomePage()
        {
            driver.Navigate().GoToUrl("http://localhost:5000");
        }
    }
}
