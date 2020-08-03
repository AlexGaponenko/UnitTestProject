using System;
using OpenQA.Selenium;


namespace XUnitTestProject1.Core.SeleniumMethods
{
    internal class Button : Waiters
    {
        public void click(By locator)
        {
            WaitClicableElement(locator).Click();
        }


    }
}
