using AdvancedMarsAutomation.Model;
using AdvancedMarsAutomation.Utilities;
using AventStack.ExtentReports.Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Pages.Components.HomePageOverveiw
{
    public class ExploreCategoriesComponent:GlobalHelper
    {
        private IWebElement mainCategoryLink;

        public void renderExploreCategoryComponents(String MainCategory)
        {
           try
            {
                mainCategoryLink = driver.FindElement(By.XPath($"//a[h3[text()='{MainCategory}']]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
      
        public void ClickOnMainCategory(SearchSkillModel Category)
        {
            renderExploreCategoryComponents(Category.MainCategory);
            Thread.Sleep(2000);
            mainCategoryLink.Click();
        }
    }
}
