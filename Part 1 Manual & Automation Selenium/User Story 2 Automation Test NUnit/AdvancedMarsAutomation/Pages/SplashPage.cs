using AdvancedMarsAutomation.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Pages
{
    public class SplashPage:GlobalHelper
    {
        private IWebElement signInButton;
        public void renderComponents()
        {
            try
            {
                signInButton = driver.FindElement(By.XPath("//*[text()='Sign In']"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void ClickSignInButton()
        {
            //Click on "Sign In" button
            Wait.WaitToBeClickable(driver, "XPath", "//*[text()='Sign In']", 10);

            renderComponents();
            signInButton.Click();

        }
    }
}
