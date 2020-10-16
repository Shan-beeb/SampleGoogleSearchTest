using System;
using System.Collections.Generic;
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

        public IEnumerable<IWebElement> FindElements(By by) => _driver.FindElements(by);

        public Page(IWebDriver driver, int waitTime = 10)
        {
            _driver = driver;
            _waitTime = waitTime;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitTime));
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

        public void DisposeDriver()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        public void WaitForElement(Func<IWebElement> elementFunc)
        {
            _wait.Until(_ =>
            {
                try
                {
                    var element = elementFunc.Invoke();
                    return element.Enabled && element.Displayed;
                }
                catch (WebDriverTimeoutException)
                {
                    Console.WriteLine($"Maximum waiting time has been reached. Element is not found in {_waitTime}");
                    return false;

                }
                catch (ElementNotInteractableException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                catch (StaleElementReferenceException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            });
        }

    }
}