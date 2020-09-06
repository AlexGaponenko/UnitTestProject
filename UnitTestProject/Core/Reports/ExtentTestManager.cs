using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace UnitTestProject.Core.Reports
{
    class ExtentTestManager
    {
        private static ThreadLocal<ExtentTest> _test;
        private static ExtentReports _extent = ExtentService.Instance;

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest GetTest()
        {
            return _test.Value;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateTest(string name)
        {
            if (_test == null)
                _test = new ThreadLocal<ExtentTest>();

            var t = _extent.CreateTest(name);
            _test.Value = t;

            return t;
        }

    }
}

