using OpenQA.Selenium;

namespace Sample.PageObject.PageObjects.Amazon
{
    public class AmazonHomePage
    {
        private readonly Page _page;

        private const string NavLogoId = "nav-logo";

        private IWebElement NavLogo => _page.FindElement(By.Id(NavLogoId));

        public AmazonHomePage(Page page)
        {
            _page = page;
        }

        public string Title => _page.GetTitle();

        public bool IsAmazonHomePageTitleMatch()
        {
            const string expectedTitle =
                "Amazon.com: Online Shopping for Electronics, Apparel, Computers, Books, DVDs & more";

            return expectedTitle.Equals(Title);
        }




        public void WaitForAmazonHomePage()
        {
            _page.WaitForElement(()=>NavLogo);
        }
    }
}
