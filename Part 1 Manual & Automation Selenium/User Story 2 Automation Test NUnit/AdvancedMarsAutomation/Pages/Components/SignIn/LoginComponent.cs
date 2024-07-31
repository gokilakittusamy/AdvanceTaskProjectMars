using AdvancedMarsAutomation.Model;
using AdvancedMarsAutomation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Pages.Components.SignIn
{
    public class LoginComponent:GlobalHelper
    {
        private IWebElement _emailIdTextBox;
        private IWebElement _passwordTextBox;
        private IWebElement _loginButton;

        public void renderComponents()
        {
            try
            {
                _emailIdTextBox = driver.FindElement(By.Name("email"));
                _passwordTextBox = driver.FindElement(By.Name("password"));
                _loginButton = driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void DoSignIn(UserInformation userInformation)
        {

            renderComponents();

            _emailIdTextBox.SendKeys(userInformation.getEmail());
            _passwordTextBox.SendKeys(userInformation.getPassword());
            _loginButton.Click();

            Thread.Sleep(3000);
        }
    }
}
