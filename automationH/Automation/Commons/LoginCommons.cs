using AutomationH.Automation.Configurations.Selenium;
using AutomationH.Automation.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationH.Automation.Commons
{
    class LoginCommons
    {
        public static DashBoardPage Login(LoginPage loginPage, String userName, String password)
        {
            loginPage.FillUserName(userName);
            loginPage.FillPassword(password);
            DashBoardPage dashBoardPage = loginPage.Submit();
            Assert.IsTrue(dashBoardPage.IsChangePasswordDisplayed(), "NO se mostro el link para cambio de contrasena");
            return dashBoardPage;
        }

        public static void Logout(PageObjectBase page)
        {
            page.Driver.FindElement(By.CssSelector("[href='/admin/logout/']")).Click();
            page.Driver.FindElement(By.CssSelector("[href='/admin/']")).Click();
        }
    }
}
