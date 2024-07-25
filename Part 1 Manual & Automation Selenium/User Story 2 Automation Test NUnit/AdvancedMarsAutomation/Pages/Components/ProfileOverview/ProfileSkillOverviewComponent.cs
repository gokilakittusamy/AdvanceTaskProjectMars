using AdvancedMarsAutomation.Model;
using AdvancedMarsAutomation.Utilities;
using NUnit.Framework.Interfaces;
using OfficeOpenXml.Export.HtmlExport.StyleCollectors.StyleContracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Pages.Components.ProfileOverview
{
    public class ProfileSkillOverviewComponent : GlobalHelper
    {
        private int skillRowCount = 0;
        String matchedSkill = "";

        private IWebElement skillTable;
        private List<IWebElement> allSkillRow;

        private IWebElement deleteSkillButton;
        public void RenderSkillsTable()
        {
            try
            {
                skillTable = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table"));
                allSkillRow = new List<IWebElement>(skillTable.FindElements(By.TagName("tbody")));
                skillRowCount = allSkillRow.Count();
           }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void RenderDeleteSkillButton()
        {
            try
            {
                deleteSkillButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void RemoveAllSkill()
        {
            RenderSkillsTable();
            for (int i = 1; i <= skillRowCount; i++)
            {
                RenderDeleteSkillButton();
                deleteSkillButton.Click();
                Thread.Sleep(3000);
            }
        }

        public bool IsSkillVisibleInSkillTable(SkillModel findSkillData)
        {

            RenderSkillsTable();

            foreach (IWebElement row in allSkillRow)
            {
                IEnumerable<IWebElement> tableData = row.FindElements(By.TagName("td"));

                foreach (IWebElement data in tableData)
                {
                    if (data.Text.Contains(findSkillData.SkillName))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void RemoveSkill(SkillModel deleteSkillData)
        {
            RenderSkillsTable();

            foreach (IWebElement row in allSkillRow)
            {
                IEnumerable<IWebElement> tableData = row.FindElements(By.TagName("td"));

                foreach (IWebElement data in tableData)
                {
                    if (data.Text.Contains(deleteSkillData.SkillName))
                    {
                        RenderSingleSkillDeleteButton(deleteSkillData.SkillName);
                    }
                }
            }
        }

        private void RenderSingleSkillDeleteButton(String deleteSkillData)
        {
            RenderSkillsTable();

            IWebElement trContainingSkill = driver.FindElement(By.XPath($"//tr[td[contains(text(), '{deleteSkillData}')]]"));
            Thread.Sleep(2000);
            IWebElement removeIcon = trContainingSkill.FindElement(By.XPath(".//i[contains(@class, 'remove icon')]"));
            removeIcon.Click();
        }

        public void ClickEditSkill(SkillModel firstAddSkill)
        {
            RenderSkillsTable();

            foreach (IWebElement row in allSkillRow)
            {
                IEnumerable<IWebElement> tableData = row.FindElements(By.TagName("td"));

                foreach (IWebElement data in tableData)
                {
                    if (data.Text.Contains(firstAddSkill.SkillName))
                    {
                        RenderSingleSkillEditButton(firstAddSkill.SkillName);
                        break;
                    }
                }
            }
        }

        private void RenderSingleSkillEditButton(string editSkillName)
        {
            RenderSkillsTable();

            IWebElement trContainingSkill = driver.FindElement(By.XPath($"//tr[td[contains(text(),'{editSkillName}')]]"));
            Thread.Sleep(2000);
            IWebElement editIcon = trContainingSkill.FindElement(By.XPath(".//i[contains(@class,'outline write icon')]"));
         
            editIcon.Click();
}
    }
}
