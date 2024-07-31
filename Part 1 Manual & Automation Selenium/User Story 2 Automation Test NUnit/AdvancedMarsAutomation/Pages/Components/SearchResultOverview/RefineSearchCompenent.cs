using AdvancedMarsAutomation.Model;
using AdvancedMarsAutomation.Utilities;
using AventStack.ExtentReports.Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Pages.Components.SearchResultOverview
{
    public class RefineSearchCompenent:GlobalHelper
    {
        private IWebElement subCategoryLink;
        private IWebElement skillTitleTextBox;
        private IWebElement skillFilterOnline;
        private IWebElement skillFilterOnSite;
        private IWebElement skillFilterShowAll;
        private IWebElement skillUserName;
        public void RenderSubCategory(String SubCategory)
        {
            try
            {
                subCategoryLink = driver.FindElement(By.XPath($"//a[text()='{SubCategory}']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void RenderSkillTitle()
        {
            try
            {
                skillTitleTextBox = driver.FindElement(By.XPath($"//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[2]/input"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void RenderSkillUserName()
        {
            try
            {
                skillUserName = driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[1]/input"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }
        private void RenderSkillFilter()
        {
            try
            {
                skillFilterOnline = driver.FindElement(By.XPath($"//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[5]/button[1]"));
                skillFilterOnSite = driver.FindElement(By.XPath($"//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[5]/button[2]"));
                skillFilterShowAll = driver.FindElement(By.XPath($"//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[5]/button[3]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void ClickOnSubCategory(SearchSkillModel Category)
        {
            RenderSubCategory(Category.SubCategory);
            Thread.Sleep(3000);
            subCategoryLink.Click();
        }

        public void SearchBySkillTitle(SearchSkillModel Category)
        {
            RenderSkillTitle();
            Thread.Sleep(3000);
            skillTitleTextBox.SendKeys(Category.SkillTitle);
            skillTitleTextBox.SendKeys(Keys.Enter);
        }

        public void SearchByFilter(SearchSkillModel Category)
        {
            RenderSkillFilter();
            Thread.Sleep(3000);
            skillFilterOnSite.Click();
        }

        public void SearchByUserName(SearchSkillModel Category)
        {
            RenderSkillUserName();
            Thread.Sleep(3000);
            skillUserName.SendKeys(Category.SearchByUser);
            skillUserName.SendKeys(Keys.ArrowDown);
            skillUserName.SendKeys(Keys.Enter);
        }

    }
}
