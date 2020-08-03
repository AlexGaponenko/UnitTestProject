using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using XUnitTestProject1.Core.Driver;
using XUnitTestProject1.Core.Reports;
using XUnitTestProject1.Core.SeleniumMethods;

namespace NUnitTestProject1.Test
{
    public class ExtentSetUpFixture
    {
        private Window window = new Window();
        private ExtentTest test;

        [OneTimeSetUp]
        public void setUp()
        {
            ExtentTestManager.CreateTest(GetType().Name);
        }

        [OneTimeTearDown]
        public void tearDown()
        {
            window.CloseBrowser();
            ExtentService.Instance.Flush();
        }

        [SetUp]
        public void beforeTest()
        {
            test = ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void AfterTest()
        {

            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                ? ""
                : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    var directory = TestContext.CurrentContext.TestDirectory;
                    var testname = TestContext.CurrentContext.Test.Name;
                    var path = directory + $"\\{testname}.png";

                    ((ITakesScreenshot)WebDriverSingleton.GetIWebDriver()).GetScreenshot().SaveAsFile(path);

                    test.Log(logstatus, "Snapshot below: " + test.AddScreenCaptureFromPath(path));
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;

                    break;
            }
            ExtentTestManager.GetTest().Log(logstatus, "Test ended with " + logstatus + stacktrace);
        }



    }
}
