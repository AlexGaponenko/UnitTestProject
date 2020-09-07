using AventStack.ExtentReports;
using NewUnitProject.PajeObject;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnitTestProject1.PageObject;
using NUnitTestProject1.Test;
using UnitTestProject.PageObject;

namespace NUnitTestProject1
{
    [TestFixture]
    public class MainMenuLoginTest : ExtentSetUpFixture
    {
        private MainMenuPageObject mainMenu;
        private AuthorizationPajeObject authPage;
        private UserAccountPageObject userAcc;
        private HomePage homePage;
        private ExtentTest test;

        public static readonly string _loginRight = "Mytestmail92@tut.by";
        public static readonly string _passwordRight = "B00lIBN48";
        public static readonly string _userId = "3078328";
        public static readonly string _loginNotRight = "VitalMartal@mail.ru";
        public static readonly string _passwordNotRight = "12345678";
        public static readonly string _messegeWrongLoginOrPassword = "Неверный логин или пароль";


        [OneTimeSetUp]
        public void Setup()
        {
            mainMenu = new MainMenuPageObject();
            authPage = new AuthorizationPajeObject();
            userAcc = new UserAccountPageObject();
            homePage = new HomePage();
        }

        [SetUp]
        public void OpenTest()
        {
            homePage.openSite();
        }

        [Test]
        public void Test1()
        {
            mainMenu.openLoginMenu();
            authPage.TypeText(_loginRight,_passwordRight);
            mainMenu.clicProfileButton();
            Assert.AreEqual(mainMenu.waitMenu(), "Пользовательское соглашение");
            mainMenu.clicUserButton();
            Assert.AreEqual(_userId, userAcc.userIdSherch());
        }

        [Test]
        public void Test2()
        {
            homePage.openSite();
            mainMenu.openLoginMenu();
            authPage.TypeText(_loginNotRight, _passwordNotRight);
            authPage.messageIdentefication();
            Assert.AreEqual(_messegeWrongLoginOrPassword, authPage.messageIdentefication());
        }
    }
}