using AdvancedMarsAutomation.Model;
using AdvancedMarsAutomation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MongoDB.Driver.WriteConcern;

namespace AdvancedMarsAutomation.Pages.Components.ProfileOverview
{
    public class ProfileLanguageOverviewComponent:GlobalHelper
    {
        private IWebElement languageTable;
        private List<IWebElement> allLanguageRow;
        private int languageRowCount = 0;

        private IWebElement addLanguageButton;
        private IWebElement languageNameTextBox;
        private IWebElement languageLevelSelect;
        private IWebElement addButton;
        private IWebElement cancelButton;
        private IWebElement editLanguageButton;

        private IWebElement deleteLanguageButton;

        /*
        public void renderComponents()
        {
            try
            {
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }*/

        public void RenderLanguageTable()
        {
            try
            {
                languageTable = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table"));
                allLanguageRow = new List<IWebElement>(languageTable.FindElements(By.TagName("tbody")));
                languageRowCount = allLanguageRow.Count();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void RenderDeleteLanguageButton()
        {
            try
            {
                deleteLanguageButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void RemoveAllLanguage()
        {
            RenderLanguageTable();
            for (int i = 1; i <= languageRowCount; i++)
            {
                RenderDeleteLanguageButton();
                deleteLanguageButton.Click();
                Thread.Sleep(2000);
            }
        }

        public int CheckLanguageRowCount()
        {
            RenderLanguageTable();
            return languageRowCount;
        }

        public void DeleteLanguage()
        {
            RenderDeleteLanguageButton();
            deleteLanguageButton.Click();
            Thread.Sleep(2000);
        }

        public bool IsLanguageVisibleInLanguageTable(LanguageModel findLanguageData)
        {
            RenderLanguageTable();

            foreach (IWebElement row in allLanguageRow)
            {
                IEnumerable<IWebElement> tableData = row.FindElements(By.TagName("td"));

                foreach (IWebElement data in tableData)
                {
                    if (data.Text.Contains(findLanguageData.LanguageName))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void ClickEditLanguage(LanguageModel firstAddLanguage)
        {
            RenderLanguageTable();

            foreach (IWebElement row in allLanguageRow)
            {
                IEnumerable<IWebElement> tableData = row.FindElements(By.TagName("td"));

                foreach (IWebElement data in tableData)
                {
                    if (data.Text.Contains(firstAddLanguage.LanguageName))
                    {
                        RenderSingleLanguageEditButton(firstAddLanguage.LanguageName);
                        break;
                    }
                }
            }
        }

        private void RenderSingleLanguageEditButton(string editLanguageName)
        {
            RenderLanguageTable();

            IWebElement trContainingSkill = driver.FindElement(By.XPath($"//tr[td[contains(text(),'{editLanguageName}')]]"));
            Thread.Sleep(2000);
            IWebElement editIcon = trContainingSkill.FindElement(By.XPath(".//i[contains(@class,'outline write icon')]"));

            editIcon.Click();
        }
    }
}
