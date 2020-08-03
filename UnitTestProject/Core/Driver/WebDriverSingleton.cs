using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestProject1.Core.Driver
{
    internal class WebDriverSingleton
    {

        
        public static IWebDriver driver;
        
        public static IWebDriver GetIWebDriver() 
        {
            {
                if (driver == null)
                    driver = new ChromeDriver(ChromeStart.OptionsChrome());
                

                return driver;
            }
        }
        //private static readonly Lazy<WebDriverSingleton> lazy = new Lazy<WebDriverSingleton>(() => new WebDriverSingleton());
        //public static WebDriverSingleton instanse => lazy.Value;

        //private IWebDriver driver;

        //public IWebDriver GetIWebDriver()
        //{
        //    if (driver == null)
        //    {
        //        driver = new ChromeDriver(ChromeStart.OptionsChrome());
        //    }
        //        return driver;

        //}
        public void CloseBrowser()
        {

            driver.Quit();
            driver = null;
        }
    }
}