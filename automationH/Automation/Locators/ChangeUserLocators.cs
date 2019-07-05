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
    class ChangeUserLocators : PageObjectBase
    {
        public ChangeUserLocators(IWebDriver Driver) : base(Driver)
        {
        }
        
        [FindsBy(How = How.XPath, Using = "//h1[text()='Change user']")]
        protected IWebElement TitleElement { get; set; }

        [FindsBy(How = How.Id, Using = "id_is_staff")]
        protected IWebElement IdIsStaffElement { get; set; }

        [FindsBy(How = How.Id, Using = "id_is_superuser")]
        protected IWebElement IdIsSuperUserElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href='../password/']")]
        protected IWebElement ChangePasswordLinkElement { get; set; }

        [FindsBy(How = How.ClassName, Using = "deletelink")]
        protected IWebElement DeleteLinkElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name='_save']")]
        protected IWebElement SubmitElement { get; set; }
    }
}
