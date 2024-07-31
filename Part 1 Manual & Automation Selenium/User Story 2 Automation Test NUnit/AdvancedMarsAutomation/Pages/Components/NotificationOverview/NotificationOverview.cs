using AdvancedMarsAutomation.Utilities;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Pages.Components.CompactMenu
{
    public class NotificationOverview:GlobalHelper
    {
        TakeScreenshot takeScreenshot;
        
        public NotificationOverview()
        {
            takeScreenshot = new TakeScreenshot();
        }
        
        private IWebElement selectAllnotification;
        private IWebElement unSelectAllNotification;
        private IWebElement markAsReadNotification;
        private IWebElement deleteNotification;
        private IWebElement firstNotificationSelect;
        private IWebElement messageWindow;
        private IWebElement closeMessageIcon;


        public void renderAddMessage()
        {
            try
            {/*
              ns-box ns-growl ns-effect-jelly ns-type-success ns-show
              */
                messageWindow = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                closeMessageIcon = driver.FindElement(By.XPath("//a[@class='ns-close']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void RenderAllDiv()
        {
            try
            {
                unSelectAllNotification = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[2]"));
                markAsReadNotification = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[4]"));
                deleteNotification = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[3]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
          }
        public void RenderSelectAllDiv()
        {
            try
            {
                    selectAllnotification = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[1]/i"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void RenderUnselectAllDiv()
        {
            try
            {
                unSelectAllNotification = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[2]/i"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void RenderFirstNotificationSelect()
        {
            
            try
            {
                firstNotificationSelect = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[3]/input"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void getScreenshot()
        {
            string screenshotPath = takeScreenshot.Screenshot(driver);
            test.Pass($"Screenshot:---", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
        }
        public void ClickOnSelectAll()
        {
            RenderSelectAllDiv();
            selectAllnotification.Click();
        }

        public void ClickOnUnSelectAll()
        {
            RenderAllDiv();
            unSelectAllNotification.Click();
            Thread.Sleep(1000);
        }

        private void selectFirstNotification()
        {
            RenderFirstNotificationSelect();
            firstNotificationSelect.Click();
        }
        public void DeleteNotification()
        {
            selectFirstNotification();
            ClickOnDeleteNotification();
        }

        public void ClickOnDeleteNotification()
        {
            RenderAllDiv();
            Thread.Sleep(2000);
            deleteNotification.Click();
        }
        private void RenderSelectAllCheckbox()
        {
            try
            {
                IList<IWebElement> selectAllCheckBoxList = driver.FindElements(By.CssSelector("input[type='checkbox']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public bool AssertSelectAll()
        {
            /*RenderSelectAllCheckbox();
            foreach (IWebElement selectAllCheckBox in selectAllCheckBoxList)
            {
                if (!selectAllCheckBox.Selected)
                {
                    return false;
                }
            }
            return true;*/
            IList<IWebElement> selectAllCheckBoxList = driver.FindElements(By.CssSelector("input[type='checkbox']"));
            foreach (IWebElement selectAllCheckBox in selectAllCheckBoxList)
            {
                if (!selectAllCheckBox.Selected)
                {
                    return false;
                }
            }
            return true;
        }

        public bool AssertUnSelectAll()
        {
            IList<IWebElement> checkBoxList = driver.FindElements(By.CssSelector("input[type='checkbox']"));
            foreach (IWebElement checkbox in checkBoxList)
            {
                if (checkbox.Selected)
                {
                    return false;
                }
            }
            return true;
        }


        public string getStatusMessage()
        {
            //Saving error or success message
            renderAddMessage();
            String message = messageWindow.Text;

            //If any message visible close it
            Wait.WaitToBeClickable(driver, "XPath", "//a[@class='ns-close']", 10);
            closeMessageIcon.Click();
            //Console.WriteLine($"message--{message}");
            return message;
        }
        /*
        public void MarkAsReadNotification()
        {
            selectFirstNotification();
            ClickOnMarkAsReadNotification();
        }*/

        public void MarkAsReadNotification()
        {
            RenderAllDiv();
            Thread.Sleep(2000);
            markAsReadNotification.Click();
        }
    }
}
