using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using UnitTestProject.Core.SeleniumMethods;

namespace NUnitTestProject1.PageObject
{
    class HomePage : Window
    {
        private readonly string url = "https://www.onliner.by/";

        private readonly Window window = new Window();
        public void openSite()
        {
            window.GoTo(url);
        }

        //public void ClearCookies()
        //{
        //    driver.Manage().Cookies.DeleteAllCookies();
        //}

    }
}
