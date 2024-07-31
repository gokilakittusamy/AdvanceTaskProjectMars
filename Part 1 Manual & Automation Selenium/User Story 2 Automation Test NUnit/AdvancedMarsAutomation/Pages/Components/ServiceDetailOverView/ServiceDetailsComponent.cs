using AdvancedMarsAutomation.Pages.Components.HomePageOverveiw;
using AdvancedMarsAutomation.Pages.Components.ProfileOverview;
using AdvancedMarsAutomation.Pages.Components.SearchResultOverview;
using AdvancedMarsAutomation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Pages.Components.ServiceDetailOverView
{
    public class ServiceDetailsComponent:GlobalHelper
    {
        private SearchResultComponents searchResultComponents;

        private IWebElement mainCategoryFromServiceDetail;
        private IWebElement subCategoryFromServiceDetail;
        private IWebElement skillTitleFromServiceDetail;
        private IWebElement skillFilterFromServiceDetail;
        private IWebElement skillUserNameFromServiceDetail;
        public ServiceDetailsComponent()
        {
            searchResultComponents = new SearchResultComponents();
        }

        private void RenderUserNameFromServiceDetail()
        {
            try
            {
                skillUserNameFromServiceDetail = driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[2]/div[1]/div/div[1]/a/h3"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void RenderMainCategoryFromServiceDetail()
        {
            try
            {
                mainCategoryFromServiceDetail = driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[1]/div/div[2]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void RenderSubCategoryFromServiceDetail()
        {
            try
            {
                subCategoryFromServiceDetail = driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[2]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void RenderSkillTitleFromServiceDetail()
        {
            try
            {
                skillTitleFromServiceDetail = driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/h1/span"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void RenderFilterFromServiceDetail()
        {
            try
            {
                skillFilterFromServiceDetail = driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[3]/div/div[2]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public String GetMainCategoryFromLastSkill()
        {
            Thread.Sleep(4000);
            searchResultComponents.GetLastSkill();

            Thread.Sleep(2000);
            RenderMainCategoryFromServiceDetail();
            String maincategory = mainCategoryFromServiceDetail.Text;
            return maincategory;
        }
        public string GetSubCategoryFromLastSkill()
        {
            RenderSubCategoryFromServiceDetail();
            String subcategory = subCategoryFromServiceDetail.Text;
            return subcategory;
        }
        public string GetSkillTitleFromLastSkill()
        {
            RenderSkillTitleFromServiceDetail();
            String skillTitle = skillTitleFromServiceDetail.Text;
            return skillTitle;
        }

        public string GetFilterFromLastSkill()
        {
            Thread.Sleep(4000);
            searchResultComponents.GetLastSkill();

            Thread.Sleep(2000);
            RenderFilterFromServiceDetail();
            String skillFilter = skillFilterFromServiceDetail.Text;
            return skillFilter;
        }

        public string GetUserNameFromLastSkill()
        {
            Thread.Sleep(4000);
            searchResultComponents.GetLastSkill();

            Thread.Sleep(2000);
            RenderUserNameFromServiceDetail();
            String skillUserName = skillUserNameFromServiceDetail.Text;
            return skillUserName;
        }

    }
}
