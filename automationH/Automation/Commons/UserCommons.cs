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
    class UserCommons
    {
        public static void CreateUser(LoginPage loginPage, String userName, String password, String newUser, String newPassword, Boolean checkStaff, Boolean checkSuperuser)
        {
            // llenar el formulario de login
            DashBoardPage dashBoardPage = LoginCommons.Login(loginPage, userName, password);

            Assert.IsTrue(dashBoardPage.IsUsersLinkDisplayed(), "NO se mostro el link de Users");

            AuthUserPage authUserPage = dashBoardPage.UsersLinkClick();
            Assert.IsTrue(authUserPage.IsTitleDisplayed(), "NO se mostro el titulo");
            Assert.IsTrue(authUserPage.IsAddUserLinkDisplayed(), "NO se mostro el boton de Add Users");

            AddUserPage addUserPage = authUserPage.AddUserClick();
            Assert.IsTrue(addUserPage.IsTitleDisplayed(), "No se mostro el titulo");

            addUserPage.FillUserName(newUser);
            addUserPage.FillPasswod1(newPassword);
            addUserPage.FillPasswod2(newPassword);
            ChangeUserPage changeUserPage = addUserPage.Submit();
            Assert.IsTrue(changeUserPage.IsTitleDisplayed(), "No se mostro el titulo");

            if(checkStaff)
            {
                changeUserPage.CheckStaff();
            }
            if(checkSuperuser)
            {
                changeUserPage.CheckSuperuser();
            }
            authUserPage = changeUserPage.Submit();

            Assert.IsTrue(authUserPage.IsUserLinkDisplayed(newUser), "No se mostro el nuevo usuario");
            LoginCommons.Logout(authUserPage);
        }

        public static void ChangePassword(LoginPage loginPage, String userName, String password, String newUser, String changePassword)
        {
            DashBoardPage dashBoardPage = LoginCommons.Login(loginPage, userName, password);

            Assert.IsTrue(dashBoardPage.IsUsersLinkDisplayed(), "NO se mostro el link de Users");

            AuthUserPage authUserPage = dashBoardPage.UsersLinkClick();
            Assert.IsTrue(authUserPage.IsTitleDisplayed(), "NO se mostro el titulo");
            Assert.IsTrue(authUserPage.IsUserLinkDisplayed(newUser), "NO se mostro el link del usuario");

            ChangeUserPage changeUserPage = authUserPage.UserLinkClick(newUser);
            Assert.IsTrue(changeUserPage.IsChangePasswordLinkDisplayed(), "No se mostro el link para cambiar la clave");

            ChangePasswordPage changePasswordPage = changeUserPage.ChangePasswordClick();
            Assert.IsTrue(changePasswordPage.IsPassword1Displayed(), "No se mostro el campo Password1");
            Assert.IsTrue(changePasswordPage.IsPassword2Displayed(), "No se mostro el campo Password2");

            changePasswordPage.FillPassword1(changePassword);
            changePasswordPage.FillPassword2(changePassword);
            changeUserPage = changePasswordPage.Submit();

            Assert.IsTrue(changeUserPage.IsTitleDisplayed(), "No se mostro el titulo");
            LoginCommons.Logout(changeUserPage);
        }

        public static void CheckUser(LoginPage loginPage, String newUser, String changePassword)
        {
            DashBoardPage dashBoardPage = LoginCommons.Login(loginPage, newUser, changePassword);

            Assert.IsTrue(dashBoardPage.IsUserNameDisplayed(newUser), "NO se mostro el nombre de usuario");
            LoginCommons.Logout(dashBoardPage);
        }

        public static void DeleteUser(LoginPage loginPage, String userName, String password, String newUser)
        {
            // llenar el formulario de login
            DashBoardPage dashBoardPage = LoginCommons.Login(loginPage, userName, password);

            Assert.IsTrue(dashBoardPage.IsUsersLinkDisplayed(), "NO se mostro el link de Users");

            AuthUserPage authUserPage = dashBoardPage.UsersLinkClick();
            Assert.IsTrue(authUserPage.IsTitleDisplayed(), "NO se mostro el titulo");
            Assert.IsTrue(authUserPage.IsUserLinkDisplayed(newUser), "NO se mostro el link del usuario");

            ChangeUserPage changeUserPage = authUserPage.UserLinkClick(newUser);
            Assert.IsTrue(changeUserPage.IsDeleteLinkDisplayed(), "No se mostro el link para cambiar la clave");

            DeleteUserPage deleteUserPage = changeUserPage.DeleteLinkClick();
            authUserPage = deleteUserPage.Submit();
            Assert.IsFalse(authUserPage.IsUserLinkDisplayed(newUser), "SI se mostro el link del usuario");
            LoginCommons.Logout(authUserPage);
        }
    }
}
