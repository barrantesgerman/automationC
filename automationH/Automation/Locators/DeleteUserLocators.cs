using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationH.Automation.Configurations.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationH.Automation.Locators
{
    class DeleteUserLocators : PageObjectBase
    {
        public DeleteUserLocators(IWebDriver Driver) : base(Driver)
        {
        }

        [FindsBy(How = How.CssSelector, Using = "input[type='submit']")]
        protected IWebElement SubmitElement { get; set; }
    }
}
