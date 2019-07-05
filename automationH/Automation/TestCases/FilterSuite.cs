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
    class FilterSuite : TestCaseBase
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

        [Test, Description("Probar crear 1 usuario con Staff y 1 sin Staff y filtrarlos"), Order(1)]
        public void FilterTest()
        {
            String usuario1 = "USUARIO1";
            String usuario2 = "USUARIO2";
            LoginPage loginPage = new LoginPage(this.Driver);
            UserCommons.CreateUser(
                loginPage,
                ConfigurationManager.AppSettings["USERNAME"],
                ConfigurationManager.AppSettings["PASSWORD"],
                usuario1,
                "h9-Q)F5-59!N>nZC",
                true,//Con Staff
                true);
            UserCommons.CreateUser(
                loginPage,
                ConfigurationManager.AppSettings["USERNAME"],
                ConfigurationManager.AppSettings["PASSWORD"],
                usuario2,
                "L!JJKA<PYB4eP@u9",
                false,//Sin Staff
                true);

            DashBoardPage dashBoardPage = LoginCommons.Login(
                loginPage,
                ConfigurationManager.AppSettings["USERNAME"],
                ConfigurationManager.AppSettings["PASSWORD"]);
            AuthUserPage authUserPage = dashBoardPage.UsersLinkClick();

            authUserPage.FilterByStaffYesClick();
            Assert.IsTrue(authUserPage.IsStaffStatusIconDisplayed(usuario1, "True"), "NO se mostro el icono de Staff verde");
            authUserPage.FilterByStaffNoClick();
            Assert.IsTrue(authUserPage.IsStaffStatusIconDisplayed(usuario2, "False"), "NO se mostro el icono de Staff rojo");
            authUserPage.FilterByStaffAllClick();
            Assert.IsTrue(authUserPage.IsStaffStatusIconDisplayed(usuario1, "True"), "NO se mostro el icono de Staff verde");
            Assert.IsTrue(authUserPage.IsStaffStatusIconDisplayed(usuario2, "False"), "NO se mostro el icono de Staff rojo");

            LoginCommons.Logout(authUserPage);
            
            UserCommons.DeleteUser(
                loginPage,
                ConfigurationManager.AppSettings["USERNAME"],
                ConfigurationManager.AppSettings["PASSWORD"],
                usuario1);
            UserCommons.DeleteUser(
                loginPage,
                ConfigurationManager.AppSettings["USERNAME"],
                ConfigurationManager.AppSettings["PASSWORD"],
                usuario2);
        }
    }
}
