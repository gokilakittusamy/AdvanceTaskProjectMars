using AdvancedMarsAutomation.Utilities;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_ProjectMars.Utilities
{
    public class ExtentReportHelper:GlobalHelper
    {
        /*
        public static ExtentReports extent;
        //public static AventStack.ExtentReports.ExtentReports extent;
        public static ExtentTest test;
        */

        public static void ExtentStart()
        {
            if (extent == null)
            {
                //extent = new AventStack.ExtentReports.ExtentReports();
                extent = new ExtentReports();

                string ReportPath = ConstantHelper.ScreenShotPath;
                if (!Directory.Exists(ReportPath))
                {
                    Directory.CreateDirectory(ReportPath);
                }
                //var htmlReporter = new ExtentHtmlReporter($"{ConstantHelper.extendReportsPath}-{DateTime.Now:yyyyMMddHHmmssfff}.html");
                //var htmlReporter = new ExtentHtmlReporter($"{ConstantHelper.extendReportsPath}");
                var htmlReporter = new ExtentHtmlReporter(@"C:\Visual_studio_project\AdvanceTaskProjectMars\Part 1 Manual & Automation Selenium\User Story 2 Automation Test NUnit\AdvancedMarsAutomation\Reports\Report.html");
                extent.AttachReporter(htmlReporter);
            }
        }
    }
}