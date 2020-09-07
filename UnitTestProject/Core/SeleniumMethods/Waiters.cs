using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using UnitTestProject.Core.Driver;

namespace UnitTestProject.Core.SeleniumMethods
{
    internal class Waiters 
    {
        
        protected IWebDriver driver = WebDriverSingleton.instanse.GetIWebElement();
        [Obsolete]
        public IWebElement GetElement(Func<IWebDriver, IWebElement> expectedCondition)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(15),
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(InvalidSelectorException));
            return wait.Until(expectedCondition);
        }

        [Obsolete]
        public IWebElement WaitClicableElement(By locator)
        {
            return GetElement(ExpectedConditions.ElementToBeClickable(locator));
        }
        public IWebElement WaitClicableElementDisplay(By locator)
        {
            return GetElement(ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitForAjax()
        {
            var wait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(15),
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };
            wait.Until(d => (bool)((IJavaScriptExecutor)d).ExecuteScript("return jQuery.active == 0"));
        }
        public void Destroy()
        {
            if (driver == null) return;
            else
            {
                driver.Quit();
                driver = null;
            }
        }
    }


}
