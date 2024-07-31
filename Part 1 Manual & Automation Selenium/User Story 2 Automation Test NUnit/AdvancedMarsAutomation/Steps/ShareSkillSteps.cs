using AdvancedMarsAutomation.AssertHelpers;
using AdvancedMarsAutomation.Model;
using AdvancedMarsAutomation.Pages;
using AdvancedMarsAutomation.Pages.Components.ProfileOverview;
using AdvancedMarsAutomation.Pages.Components.ShareSkill;
using AdvancedMarsAutomation.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Steps
{
    public class ShareSkillSteps:GlobalHelper
    {
        AddShareSkillComponent addShareSkillComponent;
        NavigationMenuComponent navigationMenuComponent;

        ShareSkillModel skillShareModel;
       
        public ShareSkillSteps()
        {
            addShareSkillComponent = new AddShareSkillComponent();
            navigationMenuComponent = new NavigationMenuComponent();

            skillShareModel = new ShareSkillModel();
           
        }
        public void AddNewShareSkill(string validDataFile)
        {
            Dictionary<string, List<ShareSkillModel>> skillData = JsonAddDataHelper.ReadAddShareSkillJsonFile(ConstantHelper.TestDataPath + validDataFile + ".json");

            //get each all skill under each category using the model
            foreach (var category in skillData)
            {
                navigationMenuComponent.ClickOnShareSkillsLink();
                AddShareSkill(category.Key, category.Value);
            }
        }

        private void AddShareSkill(String categoryKey, List<ShareSkillModel> ShareSkills)
        {
            if (ShareSkills.Count > 0)
            {
                ShareSkillModel addShareSkillData = ShareSkills[0];
                if (categoryKey == "HappyPathSkillExchange") {
                    
                    addShareSkillComponent.AddEachShareSkill(addShareSkillData);
                    /*
                    String acutalSuccessMessage = addShareSkillComponent.getStatusMessage();
                    Console.WriteLine($"acutalSuccessMessage - {acutalSuccessMessage}");
                    ShareSkillAssertHelper.AssertSkillShareSuccessMessage("Service Listing Added successfully", acutalSuccessMessage);
                    ShareSkillAssertHelper.AssertSkillShareSuccessMessage("Please complete the form correctly.", acutalSuccessMessage);
                    */
                    test.Pass("HappyPath-SkillExchange");
                    addShareSkillComponent.getScreenshot();
                    Thread.Sleep(5000);
                    ShareSkillAssertHelper.AssertPageTitleSuccessMessage("ListingManagement", currentPageTitle);
                }
                else if (categoryKey == "HappyPathCredit") {

                    addShareSkillComponent.AddEachShareSkill(addShareSkillData);
                    test.Pass("HappyPath-Credit");
                    addShareSkillComponent.getScreenshot(); 
                    Thread.Sleep(5000);
                    ShareSkillAssertHelper.AssertPageTitleSuccessMessage("ListingManagement", currentPageTitle);
                }
                else if (categoryKey == "InvalidShareSkill")
                {
                    addShareSkillComponent.AddEachShareSkill(addShareSkillData);
                    test.Pass("Invalid ShareSkill");
                    String acutalSuccessMessage = addShareSkillComponent.getStatusMessage();
                    ShareSkillAssertHelper.AssertSkillShareSuccessMessage("Please complete the form correctly.", acutalSuccessMessage);
                    Thread.Sleep(5000);
                }
                else {
                    addShareSkillComponent.AddEachShareSkill(addShareSkillData);
                    test.Pass("HappyPath-WorkSample");
                    addShareSkillComponent.getScreenshot(); 
                    Thread.Sleep(5000);
                    ShareSkillAssertHelper.AssertPageTitleSuccessMessage("ListingManagement", currentPageTitle);
                }
            }
            else
            {
                String acutalSuccessMessage = addShareSkillComponent.getStatusMessage();
                ShareSkillAssertHelper.AssertShareSkillCustomMessage($"There is an error when adding skill share");
            }
        }
    }
}
