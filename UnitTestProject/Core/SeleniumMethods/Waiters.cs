using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using XUnitTestProject1.Core.Driver;



namespace XUnitTestProject1.Core.SeleniumMethods
{
    internal class Waiters : WebDriverSingleton
    {
        public IWebDriver driver = GetIWebDriver();
        public IWebElement GetElement(By locator)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(15),
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return wait.Until<IWebElement>(driver => driver.FindElement(locator));
        }

        public IWebElement WaitClicableElement(By locator)
        {
            var wait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(15),
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }
        public bool WaitClicableElementDisplay(By locator)
        {
            var wait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(15),
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Displayed;
        }

        public void WaitForAjax()
        {
            var wait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(15),
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until(d => (bool)((IJavaScriptExecutor)d).ExecuteScript("return jQuery.active == 0"));
        }
    }


}
