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
    class ChangePasswordLocators : PageObjectBase
    {
        public ChangePasswordLocators(IWebDriver Driver) : base(Driver)
        {
        }

        [FindsBy(How = How.Id, Using = "id_password1")]
        protected IWebElement IdPassword1Element { get; set; }

        [FindsBy(How = How.Id, Using = "id_password2")]
        protected IWebElement IdPassword2Element { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[type='submit']")]
        protected IWebElement SubmitElement { get; set; }
    }
}
