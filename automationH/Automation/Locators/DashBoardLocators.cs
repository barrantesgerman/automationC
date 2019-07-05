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
    class DashBoardLocators : PageObjectBase
    {
        public DashBoardLocators(IWebDriver Driver) : base(Driver)
        {
        }

        protected String UserNameElement = "//div[@id='user-tools']/strong[text()='{0}']";

        [FindsBy(How = How.CssSelector, Using = "[href='/admin/logout/']")]
        protected IWebElement LogOutElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[href='/admin/logout/']")]
        protected IWebElement ChangePasswordElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[href='/admin/filer/folder/']")]
        protected IWebElement FoldersLinkElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[href='/admin/auth/user/']")]
        protected IWebElement UsersLinkElement { get; set; }
    }
}
