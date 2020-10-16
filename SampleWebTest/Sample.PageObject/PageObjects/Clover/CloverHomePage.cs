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

        public string Title => _page.GetTitle();


        public void WaitForCloverPage()
        {
            _page.WaitForElement(() => CloverPageRootElement);
        }

        public bool IsPageTitleMatch()
        {
            const string title1 = "Shop for a Clover Point of Sale (POS) System | Clover";
            const string title2 = "POS System & Credit Card Readers | Clover";

            return title1.Equals(Title) || title2.Equals(Title);
        }
    }
}