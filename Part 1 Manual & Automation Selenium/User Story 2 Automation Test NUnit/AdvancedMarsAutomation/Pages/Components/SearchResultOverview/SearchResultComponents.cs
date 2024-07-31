using AdvancedMarsAutomation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Pages.Components.SearchResultOverview
{
    public class SearchResultComponents : GlobalHelper
    {
        private IWebElement lastPageButton;
        private IWebElement lastSkill;

        public void RenderLastPage()
        {
            IWebElement paginationContainer = driver.FindElement(By.CssSelector("div.ui.buttons.semantic-ui-react-button-pagination"));

            IList<IWebElement> pageButtons = paginationContainer.FindElements(By.CssSelector("button"));

            if (pageButtons.Count > 0)
            {
                try
                {
                    lastPageButton = driver.FindElement(By.XPath($"//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[3]/div[2]/div/button[{pageButtons.Count - 1}]"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            else
            {
                Console.WriteLine("No pagination buttons found.");
            }
        }
        public void RenderLastSkill()
        {
            try{
                lastSkill = driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[last()]/a"));
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

        public void GetLastSkill()
        {
            RenderLastPage();
            Thread.Sleep(4000);
            lastPageButton.Click();
            Thread.Sleep(4000);
            RenderLastSkill();
            lastSkill.Click();
        }
    }
}
