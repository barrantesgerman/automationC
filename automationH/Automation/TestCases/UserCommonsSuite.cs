using AutomationH.Automation.PageObjects;
using AutomationH.Automation.Configurations.Selenium;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationH.Automation.Commons;
using System.Configuration;

namespace AutomationH.Automation.TestCases
{
    [TestFixture]
    class UserCommonsSuite : TestCaseBase
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

        [Test, Description("Probar que funcione el Commons de Usuario"), Order(1)]
        public void Commons()
        {
            LoginPage loginPage = new LoginPage(this.Driver);
            UserCommons.CreateUser(
                loginPage,
                ConfigurationManager.AppSettings["USERNAME"],
                ConfigurationManager.AppSettings["PASSWORD"],
                ConfigurationManager.AppSettings["NEW_USER"],
                ConfigurationManager.AppSettings["NEW_PASSWORD"],
                true,
                true);
            UserCommons.ChangePassword(
                loginPage,
                ConfigurationManager.AppSettings["USERNAME"],
                ConfigurationManager.AppSettings["PASSWORD"],
                ConfigurationManager.AppSettings["NEW_USER"],
                ConfigurationManager.AppSettings["CHANGE_PASSWORD"]);
            UserCommons.CheckUser(
                loginPage,
                ConfigurationManager.AppSettings["NEW_USER"],
                ConfigurationManager.AppSettings["CHANGE_PASSWORD"]);
            UserCommons.DeleteUser(
                loginPage,
                ConfigurationManager.AppSettings["USERNAME"],
                ConfigurationManager.AppSettings["PASSWORD"],
                ConfigurationManager.AppSettings["NEW_USER"]);
        }
    }
}
