using Sample.PageObject;
using TechTalk.SpecFlow;

namespace Sample.Web.AT.AcceptanceTests.Steps
{
    [Binding]
    public class BrowserUrlInitializer
    {
        private readonly Page _page;

        public BrowserUrlInitializer(Page page)
        {
            _page = page;
        }

        [Given(@"a user is on Google search page")]
        [When(@"a user is on Google search page")]
        public void GivenAUserIsOnGoogleSearchPage()
        {
            _page.NavigateTo("https://www.google.com");
        }

        [Given(@"a user is on Clover home page")]
        [When(@"a user is on Clover home page page")]
        public void GivenAUserIsOnGloverHomePage()
        {
            _page.NavigateTo("https://www.clover.com");
        }
    }
}