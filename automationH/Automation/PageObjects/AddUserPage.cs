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
    class AddUserPage : AddUserLocators
    {
        public AddUserPage(IWebDriver Driver) : base(Driver)
        {
        }

        public Boolean IsTitleDisplayed()
        {
            return this.TitleElement.Displayed;
        }

        public void FillUserName(String userName)
        {
            this.UserNameElement.SendKeys(userName);
        }

        public void FillPasswod1(String password1)
        {
            this.Password1Element.SendKeys(password1);
        }

        public void FillPasswod2(String password2)
        {
            this.Password2Element.SendKeys(password2);
        }

        public ChangeUserPage Submit()
        {
            this.SubmitElement.Submit();
            return new ChangeUserPage(this.Driver);
        }
    }
}
