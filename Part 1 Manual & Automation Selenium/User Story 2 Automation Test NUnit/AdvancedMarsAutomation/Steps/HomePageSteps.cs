using AdvancedMarsAutomation.Model;
using AdvancedMarsAutomation.Utilities;
using OpenQA.Selenium;
using AdvancedMarsAutomation.Pages.Components.ProfileOverview;
using AdvancedMarsAutomation.Pages.Components.HomePageOverveiw;
using NUnit.Framework;
using AdvancedMarsAutomation.Pages.Components.SearchResultOverview;
using AdvancedMarsAutomation.AssertHelpers;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AdvancedMarsAutomation.Pages.Components.ServiceDetailOverView;

namespace AdvancedMarsAutomation.Steps
{
    public class HomePageSteps : GlobalHelper
    {
        private UserInformation userInformation;
        private HomePage homePage;
        private ExploreCategoriesComponent exploreCategoriesComponents;
        private UserDetailsComponent userDetailsComponent;
        private ProfileMenuTabsComponents profileMenuTabsComponents;
        private SearchResultComponents searchResultComponents;
        private RefineSearchCompenent refineSearchCompenent;
        private ServiceDetailsComponent serviceDetailsComponent;
        

        TakeScreenshot takeScreenshot;

        String JsonMainCategory = "";
        String JsonSubCategory = "";
        String JsonSkillTitle = "";
        String JsonFilter = "";
        String JsonSkillUserName = "";

        public HomePageSteps()
        {
            userInformation = new UserInformation();
            homePage = new HomePage();
            userDetailsComponent = new UserDetailsComponent();
            profileMenuTabsComponents = new ProfileMenuTabsComponents();
            exploreCategoriesComponents = new ExploreCategoriesComponent();
            searchResultComponents = new SearchResultComponents();
            refineSearchCompenent = new RefineSearchCompenent();
            serviceDetailsComponent = new ServiceDetailsComponent();

            takeScreenshot = new TakeScreenshot();
        }

        public bool validateIsLoggedIn()
        {
            bool validateIsLoggedIn = false;
            String currentUser = homePage.getFirstName();
            String ExcelFirstName = userInformation.getFirstName();
            
            if (currentUser == ExcelFirstName) {
                validateIsLoggedIn = true;
            }
            return true;
        }

        public void ClickOnAvailabilityEditButton()
        {
            userDetailsComponent.ClickAvailabilityEditButton();
        }

        public void ClickOnHoursEditButton()
        {
            userDetailsComponent.ClickHoursEditButton();
        }

        public void ClickOnEarnTargetEditButton()
        {
            userDetailsComponent.ClickEarnTargetEditButton();
        }

        public void ClickOnLangaugesTab()
        {
            profileMenuTabsComponents.ClickLangaugesTab();
        }

        public void ClickOnSkillsTab()
        {
            profileMenuTabsComponents.ClickSkillsTab();

        }

        public void GoToHomePage()
        {
            homePage.NavigateToHomePage();
        }

        public void CheckMainCategory(string validMainCategoryDataFile)
        {
            List<SearchSkillModel> mainSkillCategory = JsonDataHelper.ReadJsonFile<SearchSkillModel>(ConstantHelper.TestDataPath + validMainCategoryDataFile + ".json");
            String JsonMainCategory = "";
            if (mainSkillCategory != null)
            {
                foreach (var item in mainSkillCategory)
                {
                    JsonMainCategory = item.MainCategory;
                    exploreCategoriesComponents.ClickOnMainCategory(item);
                    break;
                }
                String mainCategoryFromServiceDetail = serviceDetailsComponent.GetMainCategoryFromLastSkill();
                string screenshotPath = takeScreenshot.Screenshot(driver);
                test.Pass($"Screenshot for Main category search {JsonMainCategory}", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                SearchSkillAssertHelper.AssertSearchSkillMainCategoryMessage(mainCategoryFromServiceDetail, JsonMainCategory);
            }
            else
            {
                Assert.Fail("No data found in the Json file to change the availability.");
            }
        }

        public void CheckMainAndSubCategory(string MainAndSubCategoryDataFile)
        {
            List<SearchSkillModel> mainAndSubCategory = JsonDataHelper.ReadJsonFile<SearchSkillModel>(ConstantHelper.TestDataPath + MainAndSubCategoryDataFile + ".json");

            if (mainAndSubCategory != null)
            {
                foreach (var item in mainAndSubCategory)
                {
                    JsonMainCategory = item.MainCategory;
                    JsonSubCategory = item.SubCategory;

                    exploreCategoriesComponents.ClickOnMainCategory(item);
                    refineSearchCompenent.ClickOnSubCategory(item);
                    break;
                }
                string[] mainCategory = new string[2];
                string[] subCategory = new string[2];

                mainCategory[0] = serviceDetailsComponent.GetMainCategoryFromLastSkill();
                mainCategory[1] = JsonMainCategory;

                subCategory[0] = serviceDetailsComponent.GetSubCategoryFromLastSkill();
                subCategory[1] = JsonSubCategory;

                string screenshotPath = takeScreenshot.Screenshot(driver);
                test.Pass($"Screenshot for Main and sub category search {JsonMainCategory}", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                SearchSkillAssertHelper.AssertSearchSkillMainSubCategoryMessage(mainCategory, subCategory);

            }
            else
            {
                Assert.Fail("No data found in the Json file to change the availability.");
            }
        }


        public void CheckCategoriesWithSkillTitle(string CategoriesWithSkillTitleDataFile)
        {
            List<SearchSkillModel> mainAndSubCategory = JsonDataHelper.ReadJsonFile<SearchSkillModel>(ConstantHelper.TestDataPath + CategoriesWithSkillTitleDataFile + ".json");

            if (mainAndSubCategory != null)
            {
                foreach (var item in mainAndSubCategory)
                {
                    JsonMainCategory = item.MainCategory;
                    JsonSubCategory = item.SubCategory;
                    JsonSkillTitle = item.SkillTitle;
                    /*
                    Console.WriteLine($"JsonMainCategory - {JsonMainCategory}");
                    Console.WriteLine($"JsonSubCategory -{JsonSubCategory}");
                    Console.WriteLine($"JsonSkillTitle - {JsonSkillTitle}");
                   */
                    exploreCategoriesComponents.ClickOnMainCategory(item);
                    refineSearchCompenent.ClickOnSubCategory(item);
                    refineSearchCompenent.SearchBySkillTitle(item);
                    break;
                }
                Thread.Sleep(3000);
                string[] mainCategory = new string[2];
                string[] subCategory = new string[2];
                string[] skillTitle = new string[2];

                mainCategory[0] = serviceDetailsComponent.GetMainCategoryFromLastSkill();
                mainCategory[1] = JsonMainCategory;

                subCategory[0] = serviceDetailsComponent.GetSubCategoryFromLastSkill();
                subCategory[1] = JsonSubCategory;

                skillTitle[0] = serviceDetailsComponent.GetSkillTitleFromLastSkill(); ;
                skillTitle[0] = JsonSkillTitle;

                string screenshotPath = takeScreenshot.Screenshot(driver);
                test.Pass($"Screenshot for Main and sub category search {JsonMainCategory}", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                SearchSkillAssertHelper.AssertSearchSkillCategoriesWithSkillTitleMessage(mainCategory, subCategory, skillTitle);
            }
            else
            {
                Assert.Fail("No data found in the Json file to change the availability.");
            }
        }

        public void CheckSkillUsingFilter(string SearchUsingFiltervalidDataFile)
        {
            List<SearchSkillModel> skillFilterDetails = JsonDataHelper.ReadJsonFile<SearchSkillModel>(ConstantHelper.TestDataPath + SearchUsingFiltervalidDataFile + ".json");

            if (skillFilterDetails != null)
            {
                foreach (var item in skillFilterDetails)
                {
                    JsonMainCategory = item.MainCategory;
                    JsonFilter = item.SkillFilter;
                    exploreCategoriesComponents.ClickOnMainCategory(item);
                    refineSearchCompenent.SearchByFilter(item);
                    break;
                }
                String serviceDetailsFilter = serviceDetailsComponent.GetFilterFromLastSkill();

                string screenshotPath = takeScreenshot.Screenshot(driver);
                test.Pass($"Screenshot search using Filter {JsonMainCategory}", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                SearchSkillAssertHelper.AssertSearchSkillUsingFilter(JsonFilter, serviceDetailsFilter);
            }
            else
            {
                Assert.Fail("No data found in the Json file to change the availability.");
            }
        }

        public void CheckSkillUsingUserName(string SearchUsingUserNameValidDataFile)
        {

            List<SearchSkillModel> skillUserNameDetails = JsonDataHelper.ReadJsonFile<SearchSkillModel>(ConstantHelper.TestDataPath + SearchUsingUserNameValidDataFile + ".json");

            if (skillUserNameDetails != null)
            {
                foreach (var item in skillUserNameDetails)
                {
                    JsonMainCategory = item.MainCategory;
                    JsonSkillUserName = item.SearchByUser;
                    exploreCategoriesComponents.ClickOnMainCategory(item);
                    refineSearchCompenent.SearchByUserName(item);
                    break;
                }
                String serviceDetailsFilter = serviceDetailsComponent.GetUserNameFromLastSkill();

                string screenshotPath = takeScreenshot.Screenshot(driver);
                test.Pass($"Screenshot search using main category {JsonMainCategory}", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                SearchSkillAssertHelper.AssertSearchSkillUsingUserName(JsonSkillUserName, serviceDetailsFilter);
            }
            else
            {
                Assert.Fail("No data found in the Json file to change the availability.");
            }
        }
    }
}