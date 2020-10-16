using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Sample.Web.AT
{
    public interface IBrowser
    {
        Func<IWebDriver> WebDriver { get; }
    }

    public class ChromeBrowser : IBrowser
    {
        public Func<IWebDriver> WebDriver { get; } = () => new ChromeDriver();
    }

    public class ChromeHeadLessBrowser : IBrowser
    {
        public Func<IWebDriver> WebDriver
        {
            get
            {
                return () =>
                {
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("disable-infobars");
                    chromeOptions.AddArguments("headless");
                    return new ChromeDriver(chromeOptions);
                };
            }
        }
    }

    public class AndroidBrowser : IBrowser
    {
        public Func<IWebDriver> WebDriver
        {
            get
            {
                return () =>
                {
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("disable-infobars");
                    chromeOptions.EnableMobileEmulation("Pixel 2");
                    return new ChromeDriver(chromeOptions);
                };
            }
        }
    }

    public class IphoneBrowser : IBrowser
    {
        public Func<IWebDriver> WebDriver
        {
            get
            {
                return () =>
                {
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("disable-infobars");
                    chromeOptions.EnableMobileEmulation("iPhone 6");
                    return new ChromeDriver(chromeOptions);
                };
            }
        }
    }

    public class FireFoxBrowser : IBrowser
    {
        public Func<IWebDriver> WebDriver { get; } = () => new FirefoxDriver();
    }

    public class InternetExplorerBrowser : IBrowser
    {
        public Func<IWebDriver> WebDriver { get; } = () => new InternetExplorerDriver();
    }

    public class MicrosoftEdgeBrowser : IBrowser
    {
        public Func<IWebDriver> WebDriver { get; } = () => new EdgeDriver();
    }

    public class BrowserFactory
    {
        private readonly Dictionary<string, IBrowser> _browsers;

        public BrowserFactory()
        {
            _browsers = new Dictionary<string, IBrowser>
            {
                {"Chrome", new ChromeBrowser()},
                {"HeadLessChrome", new ChromeHeadLessBrowser()},
                {"Firefox", new FireFoxBrowser()},
                {"InternetExplorer", new InternetExplorerBrowser()},
                {"Android", new AndroidBrowser()},
                {"Ios", new IphoneBrowser()},
                {"MicrosoftEdge", new MicrosoftEdgeBrowser()}
            };
        }

        public IWebDriver GetWebDriver(string driverName)
        {
            return _browsers[driverName].WebDriver.Invoke();
        }
    }
}