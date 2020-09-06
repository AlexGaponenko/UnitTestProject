using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using System;
using System.Diagnostics;

namespace UnitTestProject.Core.Driver
{
    public class EvenWaiterListners
    {
        private IWebDriver _driver => WebDriverSingleton.instanse.WrapperEventDriver;
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
            Console.WriteLine("FindElement");
        }

        private void Navigatin(object sender, WebDriverNavigationEventArgs e)
        {
            Console.WriteLine("Navigatin");
        }

        private void Navigated(object sender, WebDriverNavigationEventArgs e)
        {
            Console.WriteLine("Navigated");
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
            Console.WriteLine("ElementClicked");
        }

        private void ElementClicking(object sender, WebElementEventArgs e)
        {
            Console.WriteLine("ElementClicking");
        }
    }
}
