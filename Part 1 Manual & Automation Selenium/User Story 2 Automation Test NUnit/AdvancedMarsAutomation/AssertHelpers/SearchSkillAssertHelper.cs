using AdvancedMarsAutomation.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.AssertHelpers
{
    public class SearchSkillAssertHelper : GlobalHelper
    {
        public static void AssertSearchSkillMainCategoryMessage(string expectedMainCategory, string actualMainCategory)
        {
            if ((expectedMainCategory == actualMainCategory))
            {
                test.Log(Status.Pass, $"Expected main category({expectedMainCategory}) matches the actual main category({actualMainCategory})");
                Assert.That(expectedMainCategory == actualMainCategory, $"Expected main category({expectedMainCategory}) matches the actual main category({actualMainCategory})");
            }
            else
            {
                test.Log(Status.Fail, $"Expected main category is {expectedMainCategory} and the actual main category is {actualMainCategory}");
                Assert.That(expectedMainCategory == actualMainCategory, $"Expected main category is {expectedMainCategory} and the actual main category is {actualMainCategory}");
            }
        }

        public static void AssertSearchSkillMainSubCategoryMessage(string[] mainCategory, string[] subCategory)
        {
            /*Console.WriteLine($"mainCategory - {mainCategory[0]}");
            Console.WriteLine($"mainCategory from Json -{mainCategory[1]}");
            Console.WriteLine($"subCategory - {subCategory[0]}");
            Console.WriteLine($"subCategory from Json - {subCategory[1]}");*/
            if ((mainCategory[0] == mainCategory[1]))
            {
                test.Log(Status.Pass, $"Expected main category({mainCategory[0]}) matches the actual main category({mainCategory[1]})");
                if ((subCategory[0] == subCategory[1]))
                {
                    test.Log(Status.Pass, $"Expected main category({mainCategory[0]}) matches the actual main category({mainCategory[1]})" +
                         $"Expected sub category({subCategory[0]}) matches the actual sub category({subCategory[1]})"
                        );
                    Assert.That(subCategory == subCategory, $"Expected sub category({subCategory[0]}) matches the actual sub category({subCategory[1]})");
                }
                else
                {
                    test.Log(Status.Fail, $"Main category mactches({mainCategory[0]}) matches But the sub category({subCategory[1]} doesnt match with the expected and actual catgories)");
                    Assert.That(subCategory[0] == subCategory[1],
                        $"Expected main category is {mainCategory[0]} and the actual main category is {mainCategory[1]}." +
                        $"Expected sub category is {subCategory[0]} and the actual sub category is {subCategory[1]}."
                        );
                }
            }
            else
            {
                test.Log(Status.Fail, $"Expected main category({mainCategory[0]}) does not match the actual main category({mainCategory[1]})");
                Assert.That(mainCategory[0] == mainCategory[1], $"Expected main category is {mainCategory[0]} and the actual main category is {mainCategory[1]}");
            }
        }

        public static void AssertSearchSkillCategoriesWithSkillTitleMessage(string[] mainCategory, string[] subCategory, string[] skillTitle)
        {
            /*Console.WriteLine($"mainCategory - {mainCategory[0]}");
            Console.WriteLine($"mainCategory from Json -{mainCategory[1]}");
            Console.WriteLine($"subCategory - {subCategory[0]}");
            Console.WriteLine($"subCategory from Json - {subCategory[1]}");
            Console.WriteLine($"skillTitle - {skillTitle[0]}");
            Console.WriteLine($"skillTitle from Json - {skillTitle[1]}");*/
            if ((mainCategory[0] == mainCategory[1]))
            {
                test.Log(Status.Pass, $"Expected main category({mainCategory[0]}) matches the actual main category({mainCategory[1]})");
                if ((subCategory[0] == subCategory[1]))
                {
                    test.Log(Status.Pass, $"Expected main category({mainCategory[0]}) matches the actual main category({mainCategory[1]})" +
                         $"Expected sub category({subCategory[0]}) matches the actual sub category({subCategory[1]})"
                        );
                    if ((skillTitle[0] == skillTitle[1])) {
                        test.Log(Status.Pass, "All the category and the skill title passed the expected vs actual");
                        Assert.That(skillTitle[0] == skillTitle[1], $"Expected title({skillTitle[0]}) matches the actual title({skillTitle[1]})");
                    }
                    else {
                        test.Log(Status.Fail, "All the category matched but the skill title did't match the expected vs actual");
                    }
                }
                else
                {
                    test.Log(Status.Fail, $"Main category mactches({mainCategory[0]}) matches But the sub category({subCategory[1]} doesnt match with the expected and actual catgories)");
                    Assert.That(subCategory[0] == subCategory[1],
                        $"Expected main category is {mainCategory[0]} and the actual main category is {mainCategory[1]}." +
                        $"Expected sub category is {subCategory[0]} and the actual sub category is {subCategory[1]}."
                        );
                }
            }
            else
            {
                test.Log(Status.Fail, $"Expected main category({mainCategory[0]}) does not match the actual main category({mainCategory[1]})");
                Assert.That(mainCategory[0] == mainCategory[1], $"Expected main category is {mainCategory[0]} and the actual main category is {mainCategory[1]}");
            }
        }

        public static void AssertSearchSkillUsingFilter(string jsonFilter, string serviceDetailsFilter)
        {
            Assert.That(jsonFilter == serviceDetailsFilter, $"Expected and actual result are the same.");
        }

        public static void AssertSearchSkillUsingUserName(string jsonFilter, string serviceDetailsFilter)
        {
            StringAssert.Contains(serviceDetailsFilter, jsonFilter, "The actual user name does not matches with the expected  user name.");
}
    }
}
