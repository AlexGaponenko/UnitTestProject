using OpenQA.Selenium.Chrome;
namespace UnitTestProject.Core.Driver
{
    internal class ChromeStart
    {
        public static ChromeOptions OptionsChrome()
        {
            var optionsCh = new ChromeOptions();
            optionsCh.AddArgument("start-maximized");
            optionsCh.AddArguments("--lang=en-GB");
            return optionsCh;
        }

        public static ChromeOptions OptionsChromeHedless()
        {
            ChromeOptions options = new ChromeOptions();

            options.AddArguments("--headless");
            options.AddArguments("window-size=1800x900");
            return options;
        }



    }
}
