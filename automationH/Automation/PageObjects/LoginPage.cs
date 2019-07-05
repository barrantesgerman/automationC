using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationH.Automation.BotStyleTest;
using AutomationH.Automation.Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationH.Automation.PageObjects
{
    class LoginPage : LoginLocators
    {
        public LoginPage(IWebDriver Driver): base(Driver)
        {
        }

        public void FillUserName(String userName)
        {
            this.Bot.SendKeys(this.UserNameElement, userName);
        }

        public void FillPassword(String password)
        {
            this.Bot.SendKeys(this.PasswordElement, password);
        }

        public DashBoardPage Submit()
        {
            this.Driver.FindElement(this.SubmitElement).Submit();
            return new DashBoardPage(this.Driver);
        }
    }
}
