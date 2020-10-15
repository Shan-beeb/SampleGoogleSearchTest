using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Sample.PageObject
{
    public class Page
    {
        private readonly IWebDriver _driver;
        private readonly int _waitTime;
        private readonly WebDriverWait _wait;

        public IWebElement FindElement(By by) => _driver.FindElement(by);

        public Page(IWebDriver driver, int waitTime = 10)
        {
            _driver = driver;
            _waitTime = waitTime;
            _wait = new WebDriverWait(_driver,TimeSpan.FromSeconds(waitTime));
        }

        public string GetTitle()
        {
            return _driver.Title;
        }

        public void NavigateTo(string url)
        {
            var uri = new Uri(url);
            _driver.Navigate().GoToUrl(uri);
        }

        public void WaitForElement(Func<IWebElement> elementFunc)
        {
            try
            {
                _wait.Until(_ =>
                {
                    var element = elementFunc.Invoke();
                    return element.Enabled && element.Displayed;
                });
            }

            catch (WebDriverTimeoutException)
            {
                Console.WriteLine($"Maximum waiting time has been reached. Element is not found in {_waitTime}");
                Environment.Exit(0);
            }
          
        }

        


    }
}
