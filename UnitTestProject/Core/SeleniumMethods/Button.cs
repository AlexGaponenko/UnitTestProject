using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Core.SeleniumMethods
{
     class Button : Waiters
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
