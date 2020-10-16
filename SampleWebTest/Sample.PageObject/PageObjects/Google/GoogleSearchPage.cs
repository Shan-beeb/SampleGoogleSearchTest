using System;
using OpenQA.Selenium;

namespace Sample.PageObject.PageObjects.Google
{
    public class GoogleSearchPage
    {
        private readonly Page _page;
        private const string Url = "https://www.google.com";

        private const string SearchInputXpath = "//input[@name='q']";


        private IWebElement SearchInput => _page.FindElement(By.XPath(SearchInputXpath));

        public GoogleSearchPage(Page page)
        {
            _page = page;
        }

        public GoogleSearchPage NavigateToGoogleSearchPage()
        {
            _page.NavigateTo(Url);
            return this;
        }

        public GoogleSearchPage Set(string value)
        {
            WaitForGoogleSearchPage();
            SearchInput.SendKeys(value);
            return this;
        }

        public GoogleSearchPage ClickSearch()
        {
            SearchInput.SendKeys(Keys.Enter);
            return this;
        }

        public bool IsExpectedResultDisplayed(string match)
        {
            try
            {
                IWebElement Element() => _page.FindElement(By.XPath($"//*[contains(text(),'{match}')]"));
                _page.WaitForElement(Element);
                return true;
            }

            catch (NoSuchElementException)
            {
                Console.WriteLine("Search result is not found");
                return false;
            }
        }

        public void  ClickResult(string match)
        {
            IsExpectedResultDisplayed(match);
            var element = _page.FindElement(By.XPath($"//*[contains(text(),'{match}')]"));
            element.Click();
        }


        public void WaitForGoogleSearchPage()
        {
            _page.WaitForElement(() => SearchInput);
        }

    }
}