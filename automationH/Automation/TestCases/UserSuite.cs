using AutomationH.Automation.PageObjects;
using AutomationH.Automation.Configurations.Selenium;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationH.Automation.TestCases
{
    [TestFixture]
    class UserSuite : TestCaseBase
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

        [Test , Description("Probar que se agrega un usuario"), Order(1)]
        public void CreateUser()
        {
            LoginPage loginPage = new LoginPage(this.Driver);
            loginPage.FillUserName(ConfigurationManager.AppSettings["USERNAME"]);
            loginPage.FillPassword(ConfigurationManager.AppSettings["PASSWORD"]);

            DashBoardPage dashBoardPage = loginPage.Submit();
            Assert.IsTrue(dashBoardPage.IsLogOutDisplayed(), "Logout link not displayed");
            Assert.IsTrue(dashBoardPage.IsChangePasswordDisplayed(), "Change password link not displayed");

            AuthUserPage authUserPage = dashBoardPage.UsersLinkClick();
            Assert.IsTrue(authUserPage.IsTitleDisplayed(), "NO se mostro el titulo");
            Assert.IsTrue(authUserPage.IsAddUserLinkDisplayed(), "NO se mostro el boton de Add Users");

            authUserPage.FilterByStaffYesClick();
            authUserPage.FilterByStaffNoClick();
            authUserPage.FilterByStaffAllClick();

            AddUserPage addUserPage = authUserPage.AddUserClick();
            Assert.IsTrue(addUserPage.IsTitleDisplayed(), "No se mostro el titulo");

            addUserPage.FillUserName(ConfigurationManager.AppSettings["NEW_USER"]);
            addUserPage.FillPasswod1(ConfigurationManager.AppSettings["NEW_PASSWORD"]);
            addUserPage.FillPasswod2(ConfigurationManager.AppSettings["NEW_PASSWORD"]);
            ChangeUserPage changeUserPage = addUserPage.Submit();
            Assert.IsTrue(changeUserPage.IsTitleDisplayed(), "No se mostro el titulo");

            changeUserPage.CheckStaff();
            changeUserPage.CheckSuperuser();
            authUserPage = changeUserPage.Submit();

            Assert.IsTrue(authUserPage.IsUserLinkDisplayed(ConfigurationManager.AppSettings["NEW_USER"]), "No se mostro el nuevo usuario");
        }

        [Test, Description("Probar que se cambia la contrasena"), Order(2)]
        public void ChangePassword()
        {
            LoginPage loginPage = new LoginPage(this.Driver);
            loginPage.FillUserName(ConfigurationManager.AppSettings["USERNAME"]);
            loginPage.FillPassword(ConfigurationManager.AppSettings["PASSWORD"]);

            DashBoardPage dashBoardPage = loginPage.Submit();
            Assert.IsTrue(dashBoardPage.IsLogOutDisplayed(), "Logout link not displayed");
            Assert.IsTrue(dashBoardPage.IsChangePasswordDisplayed(), "Change password link not displayed");

            AuthUserPage authUserPage = dashBoardPage.UsersLinkClick();
            Assert.IsTrue(authUserPage.IsTitleDisplayed(), "NO se mostro el titulo");
            Assert.IsTrue(authUserPage.IsUserLinkDisplayed(ConfigurationManager.AppSettings["NEW_USER"]), "NO se mostro el link del usuario");

            ChangeUserPage changeUserPage = authUserPage.UserLinkClick(ConfigurationManager.AppSettings["NEW_USER"]);
            Assert.IsTrue(changeUserPage.IsChangePasswordLinkDisplayed(), "No se mostro el link para cambiar la clave");

            ChangePasswordPage changePasswordPage = changeUserPage.ChangePasswordClick();
            Assert.IsTrue(changePasswordPage.IsPassword1Displayed(), "No se mostro el campo Password1");
            Assert.IsTrue(changePasswordPage.IsPassword2Displayed(), "No se mostro el campo Password2");

            changePasswordPage.FillPassword1(ConfigurationManager.AppSettings["CHANGE_PASSWORD"]);
            changePasswordPage.FillPassword2(ConfigurationManager.AppSettings["CHANGE_PASSWORD"]);
            changeUserPage = changePasswordPage.Submit();

            Assert.IsTrue(changeUserPage.IsTitleDisplayed(), "No se mostro el titulo");
        }

        [Test, Description("Probar que se logea el nuevo usuario"), Order(3)]
        public void CheckUser()
        {
            LoginPage loginPage = new LoginPage(this.Driver);
            loginPage.FillUserName(ConfigurationManager.AppSettings["NEW_USER"]);
            loginPage.FillPassword(ConfigurationManager.AppSettings["CHANGE_PASSWORD"]);

            DashBoardPage dashBoardPage = loginPage.Submit();
            //Assert.IsTrue(DashBoardPage.IsLogOutDisplayed(), "Logout link not displayed");
            //Assert.IsTrue(DashBoardPage.IsChangePasswordDisplayed(), "Change password link not displayed");
            Assert.IsTrue(dashBoardPage.IsUserNameDisplayed(ConfigurationManager.AppSettings["NEW_USER"]), "NO se mostro el nombre de usuario");
        }

        [Test, Description("Probar borrar el nuevo usuario"), Order(4)]
        public void DeleteUser()
        {
            LoginPage loginPage = new LoginPage(this.Driver);
            loginPage.FillUserName(ConfigurationManager.AppSettings["USERNAME"]);
            loginPage.FillPassword(ConfigurationManager.AppSettings["PASSWORD"]);

            DashBoardPage dashBoardPage = loginPage.Submit();
            Assert.IsTrue(dashBoardPage.IsLogOutDisplayed(), "Logout link not displayed");
            Assert.IsTrue(dashBoardPage.IsChangePasswordDisplayed(), "Change password link not displayed");

            AuthUserPage authUserPage = dashBoardPage.UsersLinkClick();
            Assert.IsTrue(authUserPage.IsTitleDisplayed(), "NO se mostro el titulo");
            Assert.IsTrue(authUserPage.IsUserLinkDisplayed(ConfigurationManager.AppSettings["NEW_USER"]), "NO se mostro el link del usuario");

            ChangeUserPage changeUserPage = authUserPage.UserLinkClick(ConfigurationManager.AppSettings["NEW_USER"]);
            Assert.IsTrue(changeUserPage.IsDeleteLinkDisplayed(), "No se mostro el link para cambiar la clave");

            DeleteUserPage deleteUserPage = changeUserPage.DeleteLinkClick();
            authUserPage = deleteUserPage.Submit();
            Assert.IsFalse(authUserPage.IsUserLinkDisplayed(ConfigurationManager.AppSettings["NEW_USER"]), "SI se mostro el link del usuario");
        }
    }
}
