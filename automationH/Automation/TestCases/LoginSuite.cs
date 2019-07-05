using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationH.Automation.Configurations.Selenium;
using NUnit.Framework;
using AutomationH.Automation.PageObjects;
using System.Configuration;

namespace AutomationH.Automation.TestCases
{
    [TestFixture]
    class LoginSuite : TestCaseBase
    {
        [OneTimeSetUp]
        public void Init()
        {
            Console.Out.WriteLine("This code is executed one time in this class at the begining");
        }


        [OneTimeTearDown]
        public void Cleanup()
        {
            Console.Out.WriteLine("This code is executed one time in this class at the begining");
        }

        [SetUp]
        public void SetUp()
        {
            Console.Out.WriteLine("I am in the SetUP in the test!!");
        }

        [Test, Description("To test that user is able to login with valid credentials #1"), ]
        public void TestLoginValid()
        {
            LoginPage loginPage = new LoginPage(this.Driver);
            loginPage.FillUserName(ConfigurationManager.AppSettings["USERNAME"]);
            loginPage.FillPassword(ConfigurationManager.AppSettings["PASSWORD"]);
            DashBoardPage dashBoardPage = loginPage.Submit();
            Assert.IsTrue(dashBoardPage.IsLogOutDisplayed(), "Logout link not displayed");
            Assert.IsTrue(dashBoardPage.IsChangePasswordDisplayed(), "Change password link not displayed");
        }

        [Test, Description("To test that user is able to login with valid credentials #2"),]
        public void TestLoginValid2()
        {
            LoginPage loginPage = new LoginPage(this.Driver);
            loginPage.FillUserName(ConfigurationManager.AppSettings["USERNAME"]);
            loginPage.FillPassword(ConfigurationManager.AppSettings["PASSWORD"]);
            DashBoardPage dashBoardPage = loginPage.Submit();
            Assert.IsTrue(dashBoardPage.IsLogOutDisplayed(), "Logout link not displayed");
            Assert.IsTrue(dashBoardPage.IsChangePasswordDisplayed(), "Change password link not displayed");
        }
    }
}
