using OpenQA.Selenium;
using XUnitTestProject1.Core.SeleniumMethods;

namespace NewUnitProject.PajeObject
{
    class UserAccountPageObject
    {
        private readonly By _profileName = By.CssSelector("div.profile-header__name");

        private Element textName = new Element();

        public string userIdSherch()
        {
            return textName.getText(_profileName);          
        }
    }
}
