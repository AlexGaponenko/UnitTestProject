using OpenQA.Selenium;
using System.Threading;
using XUnitTestProject1.Core.SeleniumMethods;

namespace NewUnitProject.PajeObject
{
    public class MainMenuPageObject 
    {
       private readonly By _signInButton = By.CssSelector("div[class^=auth-bar] div[class$=text]");
       private readonly By _profileButton = By.CssSelector("div[class^=b-top-profile__item] a[class^=b-top-profile__preview]");
       private readonly By _userButton = By.XPath("//div[contains(@class,'b-top-profile__dropdown b-top-profile__dropdown_user js-stop-propagation js-top-profile-dropdown')]/div/div/div/a");
        private readonly By _siterules = By.XPath("//div/a[contains(@href,'siterules')]"); 
        //private readonly By _userButton = By.CssSelector("div.b-top-profile__name a[class^=b-top-profile__link]");

        private Button button = new Button();

        public void openLoginMenu()
        {
            button.click(_signInButton);
        }

        public void clicProfileButton()
        {
            button.click(_profileButton);
        }

        public void clicUserButton()
        {
            
            button.click(_userButton);
        }

        public string waitMenu()
        {
           return button.WaitClicableElementDisplay(_siterules).Text;  
        }

        

    }
}
