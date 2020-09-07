using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using System;
using System.IO;

namespace UnitTestProject.Core.Driver
{
    internal class WebDriverSingleton
    {
        private static readonly Lazy<WebDriverSingleton> lazy = new Lazy<WebDriverSingleton>(() => new WebDriverSingleton());
        public static WebDriverSingleton instanse => lazy.Value;
        public IWebDriver WrapperEventDriver => GetIWebElement();
        private static IWebDriver driver;


        public string GetPathDriver()
        {
            var currentDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string projectDirectory = (currentDirectory.Parent.Parent.Parent.FullName + @"\\ChromeDriver");
            return projectDirectory;
        }
        public ChromeDriverService DriverService()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(GetPathDriver(), "chromedriver.exe");
            return service;
        }

        public IWebDriver GetIWebElement()
        {
            if (driver == null) { driver = new ChromeDriver(DriverService(), ChromeStart.OptionsChrome(), TimeSpan.FromSeconds(15)); }
            EventFiringWebDriver eventFiringWebDriver = new EventFiringWebDriver(driver);
            EvenWaiterListners evenWaiterListners = new EvenWaiterListners();
            evenWaiterListners.StartListen(eventFiringWebDriver);
            return eventFiringWebDriver;
        }

        public void CloseBrowser()
        {
            WrapperEventDriver.Quit();
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