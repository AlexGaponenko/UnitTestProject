using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestProject1.Core.SeleniumMethods
{
    internal class Window : Waiters

    {
//        private readonly string url = "https://www.onliner.by/";
        public void GoTo(string url)
        {

            driver.Navigate().GoToUrl(url);
 //           driver.Manage().Window.Maximize();
        }

        public void WindowMaximize()
        {
            driver.Manage().Window.Maximize();
        }

        //public void ClearCookies()
        //{
        //    driver.Manage().Cookies.DeleteAllCookies();
        //}
    }
}
