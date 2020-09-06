using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.Core.SeleniumMethods
{
    internal class Elements : Waiters
    {
        public void type(By locator, string text)
        {
            WaitClicableElement(locator).SendKeys(text);
        }

        public void clear(By locator)
        {
            WaitClicableElement(locator).Clear();
        }
    }
}

