using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestProject1.Core.SeleniumMethods
{
    class Element : Waiters
    {
        public string getText(By locator)
        {
            return GetElement(locator).Text;
        }
    }
}
