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
    class ChangeUserPage : ChangeUserLocators
    {
        public ChangeUserPage(IWebDriver Driver) : base(Driver)
        {
        }

        public Boolean IsTitleDisplayed()
        {
            return this.TitleElement.Displayed;
        }

        public Boolean IsChangePasswordLinkDisplayed()
        {
            return this.ChangePasswordLinkElement.Displayed;
        }

        public Boolean IsDeleteLinkDisplayed()
        {
            return this.DeleteLinkElement.Displayed;
        }

        public void CheckStaff()
        {
            this.Bot.Check(this.IdIsStaffElement);
        }

        public void CheckSuperuser()
        {
            this.Bot.Check(this.IdIsSuperUserElement);
        }

        public AuthUserPage Submit()
        {
            this.SubmitElement.Submit();
            return new AuthUserPage(this.Driver);
        }

        public ChangePasswordPage ChangePasswordClick()
        {
            this.ChangePasswordLinkElement.Click();
            return new ChangePasswordPage(this.Driver);
        }

        public DeleteUserPage DeleteLinkClick()
        {
            this.DeleteLinkElement.Click();
            return new DeleteUserPage(this.Driver);
        }
    }
}
