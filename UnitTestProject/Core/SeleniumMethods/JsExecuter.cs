using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UnitTestProject.Core.Driver;

namespace UnitTestProject.Core.SeleniumMethods
{
    class JsExecuter : Waiters
    {
        IJavaScriptExecutor js;

        public JsExecuter()
        {
            js = (IJavaScriptExecutor)driver;
        }
        public void CloseJsAlert()
        {
            if (js != null)
            {   
                js.ExecuteScript("window.alert = function(){}");
                js.ExecuteScript("window.confirm = function(){return true;}");
            }
        }
    }
}
