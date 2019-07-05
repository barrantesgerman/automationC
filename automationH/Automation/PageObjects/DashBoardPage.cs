using AutomationH.Automation.PageObjects;
using AutomationH.Automation.Locators;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationH.Automation.PageObjects
{
    class DashBoardPage : DashBoardLocators
    {
        public DashBoardPage(IWebDriver Driver) : base(Driver)
        {
        }

        public bool IsChangePasswordDisplayed()
        {
            return this.ChangePasswordElement.Displayed;
        }

        public bool IsLogOutDisplayed()
        {
            return this.ChangePasswordElement.Displayed;
        }

        public Boolean IsUserNameDisplayed(String name)
        {
            return this.Bot.IsXPathDisplayed(this.UserNameElement, name);
        }
        public Boolean IsFoldersLinkDisplayed()
        {
            return this.FoldersLinkElement.Displayed;
        }

        public Boolean IsUsersLinkDisplayed()
        {
            return this.UsersLinkElement.Displayed;
        }

        public AuthUserPage UsersLinkClick()
        {
            this.UsersLinkElement.Click();
            return new AuthUserPage(this.Driver);
        }
    }
}
