using OpenQA.Selenium;

namespace Sample.PageObject.PageObjects.Clover
{
    public class CloverHomePage
    {
        private readonly Page _page;

        private const string CloverPageRootId = "root";
        private IWebElement CloverPageRootElement => _page.FindElement(By.Id(CloverPageRootId));

        public CloverHomePage(Page page)
        {
            _page = page;
        }

        public string GetTitle()
        {
            return _page.GetTitle();
        }

        public void WaitForCloverPage()
        {
            _page.WaitForElement(() => CloverPageRootElement);
        }
    }
}