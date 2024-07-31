using AdvancedMarsAutomation.Model;
using AdvancedMarsAutomation.Utilities;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Pages.Components.ShareSkill
{
    public class AddShareSkillComponent: GlobalHelper
    {
        TakeScreenshot takeScreenshot;

        private IWebElement shareSkillTitleTextBox;
        private IWebElement shareSkillDescriptionTextArea;
        private IWebElement shareSkillCategorySelect;
        private IWebElement shareSkillSubcategorySelect;
        private IWebElement shareSkillTagsInputFields;
        private IWebElement shareSkillServiceTypeHourlyRadioBox;
        private IWebElement shareSkillServiceTypeOneOffRadioBox;
        private IWebElement shareSkillLocationTypeOnsiteRadioBox;
        private IWebElement shareSkillLocationTypeOnlineRadioBox;
        private IWebElement shareSkillAvailabledays;
        private IWebElement shareSkillTradeExChangeRadioBox;
        private IWebElement shareSkillTradeCreditRadioBox;
        private IWebElement shareSkillExchangeInputFields;
        private IWebElement shareSkillTradeCreditTextBox;
        private IWebElement shareSkillWorkSamplesFileInput;
        private IWebElement shareSkillActiveRadioBox;
        private IWebElement shareSkillInactiveRadioBox;


        private IWebElement saveShareSkillButton;
        private IWebElement cancelShareSkillButton;

        private IWebElement cancelButton;
        private IWebElement messageWindow;
        private IWebElement closeMessageIcon;

        public AddShareSkillComponent()        
        {
            takeScreenshot = new TakeScreenshot();
        }
        
        public void RenderAddSkillShare()
        {
            try
            {
                shareSkillTitleTextBox = driver.FindElement(By.Name("title"));
                shareSkillDescriptionTextArea = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea"));
                shareSkillCategorySelect = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[3]/div[2]/div/div[1]/select"));
                shareSkillTagsInputFields = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
                shareSkillServiceTypeHourlyRadioBox = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input"));
                shareSkillServiceTypeOneOffRadioBox = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input"));
                shareSkillLocationTypeOnsiteRadioBox = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input"));
                shareSkillLocationTypeOnlineRadioBox = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input"));
                //shareSkillAvailabledays =driver.FindElement(By.XPath(""));
                shareSkillTradeExChangeRadioBox = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input"));
                shareSkillTradeCreditRadioBox = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input"));
                shareSkillWorkSamplesFileInput = driver.FindElement(By.XPath("//*[@id=\"selectFile\"]"));
                shareSkillActiveRadioBox = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input"));
                shareSkillInactiveRadioBox = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input"));
                
                saveShareSkillButton = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]"));
                cancelShareSkillButton = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[2]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void RenderSubCategory()
        {
            shareSkillSubcategorySelect = driver.FindElement(By.Name("subcategoryId"));
        }
        public void RenderSkillExchangeInputField() {
            shareSkillExchangeInputFields = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));
         }
        public void RenderSkillCreditRadioBox()
        {
            shareSkillTradeCreditRadioBox = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input"));
        }  
        public void RenderSkillCreditTextBox()
        {
             shareSkillTradeCreditTextBox = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/input"));
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

        public void getScreenshot()
        {
            string screenshotPath = takeScreenshot.Screenshot(driver);
            test.Pass($"Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
        }
        public string getStatusMessage()
        {
            string screenshotPath = takeScreenshot.Screenshot(driver);
            //Saving error or success message
            RenderAddMessage();
            String message = messageWindow.Text;

            //If any message visible close it
            Wait.WaitToBeClickable(driver, "XPath", "//*[@class='ns-close']", 8);
            closeMessageIcon.Click();
            if (message == "Please enter all value")
            {
                cancelShareSkillButton.Click();
            }
            //Console.WriteLine($"message--{message}");
            test.Pass($"Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            return message;
        }
        public void AddEachShareSkill(ShareSkillModel shareSkillData)
        {
            RenderAddSkillShare();
            /*Console.WriteLine($"--------------------------------------------");

            Console.WriteLine($"ShareSkillTitle - {shareSkillData.ShareSkillTitle}");
            Console.WriteLine($"ShareSkillDescription - {shareSkillData.ShareSkillDescription}");
            Console.WriteLine($"ShareSkillCategory - {shareSkillData.ShareSkillCategory}");
            Console.WriteLine($"shareSkillSubcategorySelect - {shareSkillData.ShareSkillSubcategory}");
            Console.WriteLine($"ShareSkillTags - {shareSkillData.ShareSkillTags}");

            Console.WriteLine($"ShareSkillServiceType - {shareSkillData.ShareSkillServiceType}");
            Console.WriteLine($"ShareSkillLocationType - {shareSkillData.ShareSkillLocationType}");

            Console.WriteLine($"ShareSkillSkillTrade - {shareSkillData.ShareSkillSkillTrade}");
            Console.WriteLine($"ShareSkillSkillExchange - {shareSkillData.ShareSkillSkillExchange}");
            Console.WriteLine($"shareSkillSkillCredit - {shareSkillData.ShareSkillSkillCredit}");
            Console.WriteLine($"ShareSkillWorkSamples - {shareSkillData.ShareSkillWorkSamples}");
            Console.WriteLine($"ShareSkillActive - {shareSkillData.ShareSkillActive}");
            */
            shareSkillTitleTextBox.SendKeys(shareSkillData.ShareSkillTitle);
            shareSkillDescriptionTextArea.SendKeys(shareSkillData.ShareSkillDescription);

            SelectElement categoryDropdown = new SelectElement(shareSkillCategorySelect);
            categoryDropdown.SelectByText(shareSkillData.ShareSkillCategory);
            RenderSubCategory();

            SelectElement subCategoryDropdown = new SelectElement(shareSkillSubcategorySelect);
            subCategoryDropdown.SelectByText(shareSkillData.ShareSkillSubcategory);

            shareSkillTagsInputFields.SendKeys(shareSkillData.ShareSkillTags);
            shareSkillTagsInputFields.SendKeys(Keys.Enter);

           if (shareSkillData.ShareSkillServiceType == "Hourly basis service") {
                shareSkillServiceTypeHourlyRadioBox.Click();
            }
            else {
                shareSkillServiceTypeOneOffRadioBox.Click();
            }

            if (shareSkillData.ShareSkillLocationType == "On-site")
            {
                shareSkillLocationTypeOnsiteRadioBox.Click();
            }
            else {
                shareSkillLocationTypeOnlineRadioBox.Click();
            }
            //shareSkillAvailabledays
            
           if (shareSkillData.ShareSkillSkillTrade == "Skill-exchange")
            {
                RenderSkillExchangeInputField();
                shareSkillExchangeInputFields.SendKeys(shareSkillData.ShareSkillSkillExchange);
                shareSkillExchangeInputFields.SendKeys(Keys.Enter);
             }
            else {
                RenderSkillCreditRadioBox();
                shareSkillTradeCreditRadioBox.Click();
                RenderSkillCreditTextBox();
                shareSkillTradeCreditTextBox.Clear();
                shareSkillTradeCreditTextBox.SendKeys(shareSkillData.ShareSkillSkillCredit);
            }
            if (shareSkillData.ShareSkillWorkSamples != null) {
                shareSkillWorkSamplesFileInput.SendKeys(shareSkillData.ShareSkillWorkSamples);
            }

            if (shareSkillData.ShareSkillActive == "Active")
            {
                shareSkillActiveRadioBox.Click();
            }
            else {
                shareSkillInactiveRadioBox.Click();
            }

            saveShareSkillButton.Click();
        }

    }
}
