using System;
using OpenQA.Selenium;

namespace Sample.PageObject.PageObjects.Google
{
    public class GoogleSearchPage
    {
        private readonly Page _page;

        private const string SearchInputXpath = "//input[@name='q']";
        private const string SearchButtonXpath = "//input[@value='Google Search']";
        private const string SearchResultDivId = "search";

        private IWebElement SearchInput => _page.FindElement(By.XPath(SearchInputXpath));
        private IWebElement SearchButton => _page.FindElement(By.XPath(SearchButtonXpath));
        private IWebElement SearchResultsDiv => _page.FindElement(By.Id(SearchResultDivId));

        public GoogleSearchPage(Page page)
        {
            _page = page;
        }

        public GoogleSearchPage Set(string value)
        {
            WaitForGoogleSearchPage();
            SearchInput.SendKeys(value);
            return this;
        }

        public GoogleSearchPage ClickSearch()
        {
            WaitForSearchButton();
            SearchButton.Click();
            return this;
        }

        public void  ClickResult(string match)
        {
            try
            {
                WaitForSearchResults();
                var element = _page.FindElement(By.XPath($"//div[@class='g']//span[text()='{match}']"));
                element.Click();
            }

            catch (NoSuchElementException)
            {
               Console.WriteLine("Search result is not found");
            }
            
        }


        public void WaitForGoogleSearchPage()
        {
            _page.WaitForElement(() => SearchInput);
        }

        public void WaitForSearchResults()
        {
            _page.WaitForElement(() => SearchResultsDiv);
        }

        public void WaitForSearchButton()
        {
            _page.WaitForElement(() => SearchButton);
        }

    }
}