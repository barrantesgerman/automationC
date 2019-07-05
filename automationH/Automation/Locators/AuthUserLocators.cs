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
    class AuthUserLocators : PageObjectBase
    {
        public AuthUserLocators(IWebDriver Driver) : base(Driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//h1[text()='Select user to change']")]
        protected IWebElement TitleElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[href='/admin/auth/user/add/']")]
        protected IWebElement AddUserLinkElement { get; set; }

        protected String UserLinkElement = "//table[@id='result_list']/tbody/tr/th/a[text()='{0}']";

        [FindsBy(How = How.XPath, Using = "//div[@id='changelist-filter']/ul[1]/li[1]/a")]
        protected IWebElement FilterByStaffAllElement { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='changelist-filter']/ul[1]/li[2]/a")]
        protected IWebElement FilterByStaffYesElement { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[@id='changelist-filter']/ul[1]/li[3]/a")]
        protected IWebElement FilterByStaffNoElement { get; set; }

        protected String StaffStatusIconElement = "//table[@id='result_list']/tbody/tr[descendant::th[@class='field-username']/a[text()='{0}']]/td[@class='field-is_staff']/img[@alt='{1}']";
    }
}
