using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace XUnitTestProject1.Core.Driver
{
    internal class WebDriverSingleton
    {
        private static readonly Lazy<WebDriverSingleton> lazy = new Lazy<WebDriverSingleton>(() => new WebDriverSingleton());
        public static WebDriverSingleton instanse => lazy.Value;
        private static IWebDriver driver;
        public IWebDriver CurrentDriver => GetIWebDriver();

        public string GetPathDriver()
        {
            var currentDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string projectDirectory = (currentDirectory.Parent.Parent.Parent.FullName + @"\\ChromeDriver");
            return projectDirectory;
        }

        public IWebDriver GetIWebDriver()
        {
            if (driver == null) { driver = new ChromeDriver(GetPathDriver(), ChromeStart.OptionsChrome(), TimeSpan.FromSeconds(15)); }
            return driver;
        }

        public void CloseBrowser()
        {
            driver.Quit();
            driver = null;
        }


        //public static IWebDriver driver;

        //public static IWebDriver GetIWebDriver() 
        //{
        //    {
        //        if (driver == null)
        //            driver = new ChromeDriver(ChromeStart.OptionsChrome());


        //        return driver;
        //    }
        //}
    }
}