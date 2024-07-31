using AdvancedMarsAutomation.Model;
using AdvancedMarsAutomation.Utilities;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Pages.Components.ProfileOverview
{
    public class AddAndUpdateLanguageComponent : GlobalHelper
    {
        private IWebElement addNewLanguageButton;
        private IWebElement languageNameTextBox;
        private IWebElement languageLevelSelect;
        private IWebElement addLanguageButton;
        private IWebElement cancelLanguageButton;

        private IWebElement languageNameUpdateNameTextBox;
        private IWebElement languageNameUpdateLevelSelect;
        private IWebElement languageNameUpdateButton;
        private IWebElement languageNameCancelUpdateButton;

        private IWebElement cancelButton;
        private IWebElement messageWindow;
        private IWebElement closeMessageIcon;
        public void RenderAddLanguageButton()
        {
            addNewLanguageButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
        }
        public void RenderAddLanguage()
        {
            languageNameTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            languageLevelSelect = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            addLanguageButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            cancelLanguageButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[2]"));
        }
        private void RenderUpdateLanguage()
        {
            try
            {
                languageNameUpdateNameTextBox = driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
                languageNameUpdateLevelSelect = driver.FindElement(By.XPath("//select[@name='level']"));
                languageNameUpdateButton = driver.FindElement(By.XPath("//input[@value='Update']"));
                languageNameCancelUpdateButton = driver.FindElement(By.XPath("//input[@value='Cancel']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void RenderAddMessage()
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
    
        public void AddEachLanguage(LanguageModel languageData)
        {
            //Console.WriteLine($"languageData.LanguageName-{languageData.LanguageName}");
            //Console.WriteLine($"languageData.LanguageLevel-{languageData.LanguageLevel}");
            RenderAddLanguageButton();
            addNewLanguageButton.Click();
            RenderAddLanguage();
            languageNameTextBox.SendKeys(languageData.LanguageName);

            SelectElement levelDropdown = new SelectElement(languageLevelSelect);
            levelDropdown.SelectByValue(languageData.LanguageLevel);

            addLanguageButton.Click();
            Thread.Sleep(2000);
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                IWebElement button = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")));

                cancelLanguageButton.Click();
                Console.WriteLine("cancel is clicked");
            }
            catch (WebDriverTimeoutException)
            {
            }
        }

        public string getStatusMessage()
        {
            //Saving error or success message
            RenderAddMessage();
            String message = messageWindow.Text;

            //If any message visible close it
            Wait.WaitToBeClickable(driver, "XPath", "//*[@class='ns-close']", 8);
            closeMessageIcon.Click();
            /*
            if (message == "Please enter language and level")
            {
                cancelLanguageButton.Click();
            }*/

            //Console.WriteLine($"message--{message}");
            return message;
        }

        public void AddBeforeUpdateLanguage(LanguageModel addBeforeUpdateLanguage)
        {
            AddEachLanguage(addBeforeUpdateLanguage);
        }

        public void UpdateLanguage(LanguageModel updateLanguage)
        {
            Thread.Sleep(2000);
            RenderUpdateLanguage();

            languageNameUpdateNameTextBox.Clear();
            languageNameUpdateNameTextBox.SendKeys(updateLanguage.LanguageName);

            SelectElement levelDropdown = new SelectElement(languageNameUpdateLevelSelect);
            levelDropdown.SelectByValue(updateLanguage.LanguageLevel);

            languageNameUpdateButton.Click();
            Thread.Sleep(2000);
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                IWebElement button = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@value='Update']")));

                languageNameCancelUpdateButton.Click();
            }
            catch (WebDriverTimeoutException)
            {
            }
        }

       
    }
}

