
using AdvancedMarsAutomation.Pages;
using AdvancedMarsAutomation.Model;
using AdvancedMarsAutomation.Utilities;
using OpenQA.Selenium;
using AdvancedMarsAutomation.Pages.Components.ProfileOverview;

namespace AdvancedMarsAutomation.Steps
{
    public class HomePageSteps : GlobalHelper
    {
        private HomePage homePage;
        private UserDetailsComponent userDetailsComponent;
        private ProfileMenuTabsComponents profileMenuTabsComponents;
        public HomePageSteps()
        {
            homePage = new HomePage();
            userDetailsComponent = new UserDetailsComponent();
            profileMenuTabsComponents = new ProfileMenuTabsComponents();
        }

        public void validateIsLoggedIn()
        {
            homePage.getFirstName();
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
    }
    
}