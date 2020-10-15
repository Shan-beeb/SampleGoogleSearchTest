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
                {"Firefox", new FireFoxBrowser()},
                {"InternetExplorer", new InternetExplorerBrowser()},
                {"MicrosoftEdge", new MicrosoftEdgeBrowser()}
            };
        }

        public IWebDriver GetWebDriver(string driverName)
        {
            return _browsers[driverName].WebDriver.Invoke();
        }
    }
}