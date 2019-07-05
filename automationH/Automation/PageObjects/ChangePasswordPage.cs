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
    class ChangePasswordPage : ChangePasswordLocators
    {
        public ChangePasswordPage(IWebDriver Driver) : base(Driver)
        {
        }

        public Boolean IsPassword1Displayed()
        {
            return this.IdPassword1Element.Displayed;
        }

        public Boolean IsPassword2Displayed()
        {
            return this.IdPassword2Element.Displayed;
        }

        public void FillPassword1(String password1)
        {
            this.IdPassword1Element.SendKeys(password1);
        }

        public void FillPassword2(String password2)
        {
            this.IdPassword2Element.SendKeys(password2);
        }

        public ChangeUserPage Submit()
        {
            this.SubmitElement.Submit();
            return new ChangeUserPage(this.Driver);
        }
    }
}
