using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace AutomationH.Automation.Configurations.Selenium
{
    class TestCaseBase : SeleniumBase
    {
        [SetUp]
        public void SetUpTestCaseBase()
        {
            SetUpBase(ConfigurationManager.AppSettings["BROWSER"], ConfigurationManager.AppSettings["URL"]);
        }

        [TearDown]
        public void TearDownTestCaseBase()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                String dir = TestContext.CurrentContext.WorkDirectory;
                String method = TestContext.CurrentContext.Test.MethodName;
                String path = dir + "/" + method + ".jpg";
                Console.Out.WriteLine("### SCREENSHOT on " + path);
                var screenshot = ((ITakesScreenshot)this.Driver).GetScreenshot();
                screenshot.SaveAsFile(path, ScreenshotImageFormat.Jpeg);
            }
            TearDownBase();
        }
    }
}
