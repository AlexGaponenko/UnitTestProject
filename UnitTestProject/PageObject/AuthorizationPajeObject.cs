using OpenQA.Selenium;
using System.Threading;
using UnitTestProject.Core.SeleniumMethods;

namespace NewUnitProject.PajeObject
{
    class AuthorizationPajeObject
    {
        private readonly By _loginInput = By.CssSelector("div[class^=auth-input] input[type^=text]");
        private readonly By _passwordInput = By.CssSelector("input[type^=password]");
        private readonly By _continueButton = By.CssSelector("div[class^=auth-form] button[type^=submit]");
        private readonly By _notAuthMessage = By.CssSelector("div[class$=auth-form__line_condensed] div[class^=auth-form__description]");

        private Elements textField = new Elements();
        private ButtonOne button = new ButtonOne();
        private Element textName = new Element();


        public void TypeText(string _login, string _password)
        {
            textField.type(_loginInput, _login);
            textField.type(_passwordInput, _password);
            button.click(_continueButton);
        }

        public string messageIdentefication()
        {
            return textName.getText(_notAuthMessage);
        }


    }
}
