using AdvancedMarsAutomation.AssertHelpers;
using AdvancedMarsAutomation.Model;
using AdvancedMarsAutomation.Pages.Components.ProfileOverview;
using AdvancedMarsAutomation.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using OfficeOpenXml.Export.HtmlExport.StyleCollectors.StyleContracts;
using OpenQA.Selenium;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Steps
{
    public class SkillSteps : GlobalHelper
    {
        ProfileMenuTabsComponents profileMenuTabsComponents;
        ProfileSkillOverviewComponent profileSkillOverviewComponent;
        AddAndUpdateSkillComponent addAndUpdateSkillComponent;
       
        SkillModel skillModel;
        TakeScreenshot takeScreenshot;

        public SkillSteps()
        {
            profileMenuTabsComponents = new ProfileMenuTabsComponents();
            profileSkillOverviewComponent = new ProfileSkillOverviewComponent();
            addAndUpdateSkillComponent = new AddAndUpdateSkillComponent();

            skillModel = new SkillModel();
            takeScreenshot = new TakeScreenshot();
        }

        public void RemoveAllExistingSkills()
        {
            profileSkillOverviewComponent.RemoveAllSkill();
        }

        public void AddSkill(string validDataFile)
        {
            string screenshotPath = takeScreenshot.Screenshot(driver);

            List<SkillModel> skillDataList = JsonDataHelper.ReadJsonFile<SkillModel>(ConstantHelper.TestDataPath + validDataFile + ".json");
            if (skillDataList != null)
            {
                foreach (var item in skillDataList)
                {
                    addAndUpdateSkillComponent.AddEachSkill(item);
                    String acutalSuccessMessage = addAndUpdateSkillComponent.getStatusMessage();
                    test.Pass($"Screenshot for adding {item.SkillName}", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                    SkillAssertHelper.AssertSkillSuccessMessage($"{item.SkillName} has been added to your skills", acutalSuccessMessage);
                }
            }
            else
            {
                Assert.Fail("No data found in the Json file to change the availability.");
            }
        }

        public void DeleteSkill(string validDeleteDataFile)
        {
            string screenshotPath = takeScreenshot.Screenshot(driver);

            List<SkillModel> skillDataList = JsonDataHelper.ReadJsonFile<SkillModel>(ConstantHelper.TestDataPath + validDeleteDataFile + ".json");
            if (skillDataList != null)
            {
                foreach (var item in skillDataList)
                {
                    if (profileSkillOverviewComponent.IsSkillVisibleInSkillTable(item) == true)
                    {
                        profileSkillOverviewComponent.RemoveSkill(item);
                        Thread.Sleep(2000);
                        String acutalSuccessMessage = addAndUpdateSkillComponent.getStatusMessage();
                        test.Pass($"Screenshot for deleting {item.SkillName}", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                        SkillAssertHelper.AssertSkillSuccessMessage($"{item.SkillName} has been deleted", acutalSuccessMessage);
                    }
                    else
                    {
                        //There is an error when deleting skill
                        String acutalSuccessMessage = addAndUpdateSkillComponent.getStatusMessage();
                        test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                        SkillAssertHelper.AssertSkillCustomMessage($"There is an error when deleting skill - {item.SkillName}");
                    }
                }
            }
        }
       
        public void EditSkill(string validEditDataFile)
        {
            Dictionary<string, List<SkillModel>> skillData = JsonEditDataHelper.ReadEditSkillJsonFile(ConstantHelper.TestDataPath + validEditDataFile + ".json");

            //get each all skill under each category using the model
            foreach (var category in skillData)
            {
                UpdateSkill(category.Key,category.Value);
            }
        }

        public void UpdateSkill(String categoryKey, List<SkillModel> UpdateSkills)
        {
            string screenshotPath = takeScreenshot.Screenshot(driver);

            if (UpdateSkills.Count > 0)
            {
                SkillModel firstAddSkill = UpdateSkills[0];
                addAndUpdateSkillComponent.AddBeforeUpdateSkill(firstAddSkill);
                // Log skill added to edit

                if (profileSkillOverviewComponent.IsSkillVisibleInSkillTable(firstAddSkill) == true)
                {
                    SkillModel lastEditSkill = UpdateSkills[1];

                    profileSkillOverviewComponent.ClickEditSkill(firstAddSkill);
                    addAndUpdateSkillComponent.UpdateSkill(lastEditSkill);

                    String acutalSuccessMessage = addAndUpdateSkillComponent.getStatusMessage();
                    if (categoryKey == "SkillAlreadyExist")
                    {
                        //test.Log("");
                        test.Pass($"Screenshot for {categoryKey}", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                        SkillAssertHelper.AssertSkillSuccessMessage("This skill is already added to your skill list.", acutalSuccessMessage);
                    }
                    else {
                       test.Pass($"Screenshot for {categoryKey}", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                    }
                }
                else
                {
                    String acutalSuccessMessage = addAndUpdateSkillComponent.getStatusMessage();
                    SkillAssertHelper.AssertSkillCustomMessage($"There is an error when updating skill - {firstAddSkill.SkillName}");
                }
            }
        }
    }
}
