using AutomationH.Automation.PageObjects;
using AutomationH.Automation.Configurations.Selenium;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using AutomationH.Automation.Commons;

namespace AutomationH.Automation.TestCases
{
    [TestFixture]
    class UserProviderSuite : TestCaseBase
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

        [TestCase("DotNet", "MXtja+a7HWqx*R{4")]
        [TestCase("NuGet", "7#,vE6pRtDR?c/~K")]
        [TestCase("Selenium", "9*T9=7srTL5.8TeS")]
        [TestCase("NUnit", "5Fe()&e',-[FV,EU")]
        [TestCase("CSharp", "3{qXPR@>gp$E_C#a")]
        [Test, Description("Probar que se agrega 5 usuarios"), Order(1)]
        public void CreateUser(String newUser, String newPassword)
        {
            LoginPage loginPage = new LoginPage(this.Driver);
            UserCommons.CreateUser(
                loginPage,
                ConfigurationManager.AppSettings["USERNAME"],
                ConfigurationManager.AppSettings["PASSWORD"],
                newUser,
                newPassword,
                true,
                true);
        }

        [TestCase("DotNet")]
        [TestCase("NuGet")]
        [Test, Description("Probar que se eliminan 2 usuarios"), Order(2)]
        public void Delete2User(String newUser)
        {
            LoginPage loginPage = new LoginPage(this.Driver);
            UserCommons.DeleteUser(
                loginPage,
                ConfigurationManager.AppSettings["USERNAME"],
                ConfigurationManager.AppSettings["PASSWORD"],
                newUser);
        }

        [TestCase("Selenium", "9*T9=7srTL5.8TeS")]
        [TestCase("NUnit", "5Fe()&e',-[FV,EU")]
        [TestCase("CSharp", "3{qXPR@>gp$E_C#a")]
        [Test, Description("Probar que se logean 3 usuarios"), Order(3)]
        public void CheckUser(String newUser, String newPassword)
        {
            LoginPage loginPage = new LoginPage(this.Driver);
            UserCommons.CheckUser(
                loginPage,
                newUser,
                newPassword);
        }

        [TestCase("Selenium")]
        [TestCase("NUnit")]
        [TestCase("CSharp")]
        [Test, Description("Probar que se eliminan 3 usuarios"), Order(4)]
        public void Delete3User(String newUser)
        {
            LoginPage  loginPage = new LoginPage(this.Driver);
            UserCommons.DeleteUser(
                loginPage,
                ConfigurationManager.AppSettings["USERNAME"],
                ConfigurationManager.AppSettings["PASSWORD"],
                newUser);
        }
    }
}
