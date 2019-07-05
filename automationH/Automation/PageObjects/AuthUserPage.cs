using AutomationH.Automation.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationH.Automation.BotStyleTest;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationH.Automation.PageObjects
{
    class AuthUserPage : AuthUserLocators
    {
        public AuthUserPage(IWebDriver Driver) : base(Driver)
        {
        }

        public Boolean IsTitleDisplayed()
        {
            return this.TitleElement.Displayed;
        }

        public Boolean IsAddUserLinkDisplayed()
        {
            return this.AddUserLinkElement.Displayed;
        }

        public Boolean IsUserLinkDisplayed(String userName)
        {
            return this.Bot.IsXPathDisplayed(this.UserLinkElement, userName);
        }

        public Boolean IsStaffStatusIconDisplayed(String userName, String status)
        {
            return this.Bot.IsXPathDisplayed(this.StaffStatusIconElement, userName, status);
        }

        public AddUserPage AddUserClick()
        {
            this.AddUserLinkElement.Click();
            return new AddUserPage(this.Driver);
        }

        public ChangeUserPage UserLinkClick(String userName)
        {
            this.Bot.FindByXPath(this.UserLinkElement, userName).Click();
            return new ChangeUserPage(this.Driver);
        }

        public void FilterByStaffAllClick()
        {
            this.FilterByStaffAllElement.Click();
        }

        public void FilterByStaffYesClick()
        {
            this.FilterByStaffYesElement.Click();
        }

        public void FilterByStaffNoClick()
        {
            this.FilterByStaffNoElement.Click();
        }
    }
}
