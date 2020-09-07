using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using UnitTestProject.Core.SeleniumMethods;

namespace UnitTestProject.Core.Driver
{
    public class EvenWaiterListners
    {
        private IWebDriver driver => WebDriverSingleton.instanse.WrapperEventDriver;
        private readonly Stopwatch Watch = new Stopwatch();
        
        public void StartListen(EventFiringWebDriver eventFiringWebDriver)
        {
            eventFiringWebDriver.ElementClicked += ElementClicking;
            eventFiringWebDriver.ElementClicking += ElementClicked;
            eventFiringWebDriver.ElementValueChanged += ElementValueChanged;
            eventFiringWebDriver.ElementValueChanging += ElementValueChanging;
            eventFiringWebDriver.Navigated += Navigated;
            eventFiringWebDriver.Navigating += Navigatin;
            eventFiringWebDriver.FindingElement += FindElement;
        }

        private void FindElement(object sender, FindElementEventArgs e)
        {
            CloseJS();
            WaitForAjax();
            Console.WriteLine("FindElement"); 
        }

        private void Navigatin(object sender, WebDriverNavigationEventArgs e)
        {
            Console.WriteLine("Navigatin" + " " + e.Url);
        }

        private void Navigated(object sender, WebDriverNavigationEventArgs e)
        {
            Console.WriteLine("Navigated" + " " + e.Url);
            Watch.Stop();
        }

        private void ElementValueChanging(object sender, WebElementValueEventArgs e)
        {
            Console.WriteLine("ElementValueChanging");
        }

        private void ElementValueChanged(object sender, WebElementValueEventArgs e)
        {
            Console.WriteLine("ElementValueChanged");
        }

        private void ElementClicked(object sender, WebElementEventArgs e)
        {
            CloseJS();
            WaitForAjax();
            Console.WriteLine("ElementClicked " + e.Element.Text);
        }

        private void ElementClicking(object sender, WebElementEventArgs e)
        {
            CloseJS();
            WaitForAjax();
            Console.WriteLine("ElementClicking");
        }

        public void WaitForAjax()
        {
            var wait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(15),
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };
            wait.Until(d => (bool)((IJavaScriptExecutor)d).ExecuteScript("return jQuery.active == 0"));
        }

        public void CloseJS()
        {
            JsExecuter js = new JsExecuter();
            js.CloseJsAlert();
        }


    }
}
