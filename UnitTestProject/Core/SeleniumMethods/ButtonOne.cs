using System;
using System.Linq;
using OpenQA.Selenium;


namespace XUnitTestProject1.Core.SeleniumMethods
{
    internal class ButtonOne : Waiters
    {
        public void click(By locator)
        {
            WaitClicableElement(locator).Click();
        }

        public void countElements(By locator)
        {
            GetWebElements(locator).Count();

        }


    }
}
