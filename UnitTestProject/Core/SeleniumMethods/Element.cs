using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.Core.SeleniumMethods
{
    class Element : Waiters
    {
        public string getText(By locator)
        {
            return WaitClicableElement(locator).Text;
        }
    }
}
