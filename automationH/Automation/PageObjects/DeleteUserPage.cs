using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationH.Automation.Locators;
using AutomationH.Automation.BotStyleTest;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationH.Automation.PageObjects
{
    class DeleteUserPage : DeleteUserLocators
    {
        public DeleteUserPage(IWebDriver Driver) : base(Driver)
        {
        }

        public AuthUserPage Submit()
        {
            this.SubmitElement.Submit();
            return new AuthUserPage(this.Driver);
        }
    }
}
