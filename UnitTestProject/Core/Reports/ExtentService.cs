using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace XUnitTestProject1.Core.Reports
{
    public class ExtentService
    {
        private static readonly Lazy<ExtentReports> _lazy = new Lazy<ExtentReports>(() => new ExtentReports());


        public static ExtentReports Instance { get { return _lazy.Value; } }


            static  ExtentService()
            {
            var currentDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string projectDirectory = currentDirectory.Parent.Parent.Parent.FullName;

            var reporter = new ExtentV3HtmlReporter(projectDirectory + "\\3Extent.html");
                reporter.Config.Theme = Theme.Dark;
                reporter.Config.DocumentTitle = "Extent/nUnit Samples";
                reporter.Config.ReportName = "Extent/nUnit Samples";
            
                Instance.AttachReporter(reporter);
            }

            private ExtentService()
            {

            }




        //static ExtentService()
        //{
        //    var htmlReporter = new ExtentHtmlReporter(@"C:\Users\37529\source\repos\NewUnitProject\NUnitTestProject1\Extent222.html");
        //    htmlReporter.Configuration().ChartLocation = ChartLocation.Top;
        //    htmlReporter.Configuration().ChartVisibilityOnOpen = true;
        //    htmlReporter.Configuration().DocumentTitle = "Extent/xUnit Samples";
        //    htmlReporter.Configuration().ReportName = "Extent/xUnit Samples";
        //    htmlReporter.Configuration().Theme = Theme.Dark;
        //    Instance.AttachReporter(htmlReporter);
        //}

        //private ExtentService()
        //{
        //}


        //}

    }
}



