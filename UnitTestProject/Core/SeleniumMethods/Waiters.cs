﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using XUnitTestProject1.Core.Driver;



namespace XUnitTestProject1.Core.SeleniumMethods
{
    internal class Waiters : WebDriverSingleton
    {
        
        protected IWebDriver driver = instanse.GetIWebElement();
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
        public IList<IWebElement> GetWebElements(By selector)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(30),
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.Until(ExpectedConditions.ElementExists(selector));
            return driver.FindElements(selector);
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
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(InvalidSelectorException));
            wait.Until(d => (bool)((IJavaScriptExecutor)d).ExecuteScript("return jQuery.active == 0"));
        }
    }


}
