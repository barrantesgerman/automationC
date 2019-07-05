using AutomationH.Automation.Configurations.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationH.Automation.Locators
{
    class AddUserLocators : PageObjectBase
    {
        public AddUserLocators(IWebDriver Driver) : base(Driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//h1[text()='Add user']")]
        protected IWebElement TitleElement { get; set; }

        [FindsBy(How = How.Id, Using = "id_username")]
        protected IWebElement UserNameElement { get; set; }

        [FindsBy(How = How.Id, Using = "id_password1")]
        protected IWebElement Password1Element { get; set; }

        [FindsBy(How = How.Id, Using = "id_password2")]
        protected IWebElement Password2Element { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name='_save']")]
        protected IWebElement SubmitElement { get; set; }
    }
}
