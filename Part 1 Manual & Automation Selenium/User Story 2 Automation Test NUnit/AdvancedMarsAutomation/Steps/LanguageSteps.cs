using NUnit.Framework;
using AdvancedMarsAutomation.Model;
using AdvancedMarsAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AdvancedMarsAutomation.Pages.Components.ProfileOverview;
using AdvancedMarsAutomation.AssertHelpers;
using AventStack.ExtentReports;

namespace AdvancedMarsAutomation.Steps
{
    public class LanguageSteps:GlobalHelper
    {
        ProfileMenuTabsComponents profileMenuTabsComponents;
        ProfileLanguageOverviewComponent profileLanguageOverviewComponent;
        AddAndUpdateLanguageComponent addAndUpdateLanguageComponent;

        LanguageModel languageModel;
        TakeScreenshot takeScreenshot;
        public LanguageSteps()
        {
            profileMenuTabsComponents = new ProfileMenuTabsComponents();
            profileLanguageOverviewComponent = new ProfileLanguageOverviewComponent();
            addAndUpdateLanguageComponent = new AddAndUpdateLanguageComponent();
            
            languageModel = new LanguageModel();
            takeScreenshot = new TakeScreenshot();
        }

        /*if the table has more than 4 language the add button will be hiden*/
        public bool CheckAddNewLanguageVisible()
        {
            Boolean flag = false;
            try
            {
                Boolean isAddButtonPresent = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Displayed;
                if (isAddButtonPresent)
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is NoSuchElementException)
                {
                    flag = false;
                }
            }
            return flag;
        }
        
        public void AddLanguage(String LanguageDataFile)
        {
            string screenshotPath = takeScreenshot.Screenshot(driver);
            
            List<LanguageModel> languageDataList = JsonDataHelper.ReadJsonFile<LanguageModel>(ConstantHelper.TestDataPath + LanguageDataFile + ".json");
            if (languageDataList != null)
            {
                foreach (var item in languageDataList)
                {
                    if (CheckAddNewLanguageVisible() == true)
                    {
                        addAndUpdateLanguageComponent.AddEachLanguage(item);
                        
                        String acutalSuccessMessage = addAndUpdateLanguageComponent.getStatusMessage();
                        test.Pass($"Screenshot for adding {item}", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                       
                        if (acutalSuccessMessage == "Please enter language and level")
                        {
                             LanguageAssertHelper.AssertLangaugeSuccessMessage("Please enter language and level", acutalSuccessMessage);
                        }
                        else if (acutalSuccessMessage == "This language is already exist in your language list.")
                        {
                             LanguageAssertHelper.AssertLangaugeSuccessMessage("This language is already exist in your language list.", acutalSuccessMessage);
                         }
                        else
                        {
                           LanguageAssertHelper.AssertLangaugeSuccessMessage($"{item.LanguageName} has been added to your languages", acutalSuccessMessage);
                        }
                    }
                    else
                    {
                        test.Pass("Screenshot for crossed the limited of language addition", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                        LanguageAssertHelper.AssertLangaugeCustomMessage("Language table already has four language.");
                    }
                }
            }
            else
            {
                Assert.Fail("No data found in the Json file to change the availability.");
            }
        }

        public void RemoveAllExistingLanguages()
        {
            profileLanguageOverviewComponent.RemoveAllLanguage();
        }

        public void EditLanguage(string ValidEditLanguageDataFile)
        {
            
            Dictionary<string, List<LanguageModel>> languageData = JsonEditDataHelper.ReadEditLanguageJsonFile(ConstantHelper.TestDataPath + ValidEditLanguageDataFile + ".json");
            
            foreach (var category in languageData)
            {
                UpdateLanguage(category.Key, category.Value);
            }
        }

        public void UpdateLanguage(string categoryKey, List<LanguageModel> UpdateLanguage)
        {
            string screenshotPath = takeScreenshot.Screenshot(driver);
            Console.WriteLine($"categoryKey-{categoryKey}");
            if (UpdateLanguage.Count > 0)
            {
                LanguageModel firstAddLanguage = UpdateLanguage[0];
                addAndUpdateLanguageComponent.AddBeforeUpdateLanguage(firstAddLanguage);
                // Log Language added to edit

                if (profileLanguageOverviewComponent.IsLanguageVisibleInLanguageTable(firstAddLanguage) == true)
                {
                    LanguageModel lastEditLanguage = UpdateLanguage[1];

                    profileLanguageOverviewComponent.ClickEditLanguage(firstAddLanguage);
                    addAndUpdateLanguageComponent.UpdateLanguage(lastEditLanguage);

                    String acutalSuccessMessage = addAndUpdateLanguageComponent.getStatusMessage();
                    if (categoryKey == "LanguageAlreadyExist")
                    {
                        //test.Log("");
                        test.Pass($"Screenshot for {categoryKey}", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                        LanguageAssertHelper.AssertLangaugeSuccessMessage("This language is already added to your language list.", acutalSuccessMessage);
                    }
                    else
                    {
                        test.Pass($"Screenshot for {categoryKey}", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                    }
                }
                else
                {
                    String acutalSuccessMessage = addAndUpdateLanguageComponent.getStatusMessage();
                    LanguageAssertHelper.AssertLangaugeCustomMessage($"There is an error when updating Language - {firstAddLanguage.LanguageName}");
                }
            }
        }

        public int CheckLanguageRowCount()
        {
            int languageRowCount = profileLanguageOverviewComponent.CheckLanguageRowCount();
            return languageRowCount;
        }

        public void DeleteLanguage(String DeleteLanguageData)
        {
            string screenshotPath = takeScreenshot.Screenshot(driver);
            List<LanguageModel> languageDataList = JsonDataHelper.ReadJsonFile<LanguageModel>(ConstantHelper.TestDataPath + DeleteLanguageData + ".json");
            if (languageDataList != null)
            {
                foreach (var item in languageDataList)
                {
                    profileLanguageOverviewComponent.DeleteLanguage();
                    String acutalSuccessMessage = addAndUpdateLanguageComponent.getStatusMessage();
                    LanguageAssertHelper.AssertLangaugeSuccessMessage($"{item.LanguageName} has been deleted from your languages", acutalSuccessMessage);
                }
            }

        }

    }
}
