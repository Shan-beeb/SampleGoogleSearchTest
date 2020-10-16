using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sample.PageObject.PageObjects.Google;
using TechTalk.SpecFlow;

namespace Sample.Web.AT.AcceptanceTests.Steps
{
    [Binding]
    public class GoogleSearchPageSteps
    {
        private readonly GoogleSearchPage _googleSearchPage;

        public GoogleSearchPageSteps(GoogleSearchPage googleSearchPage)
        {
            _googleSearchPage = googleSearchPage;
        }

        [Given(@"a user searches for '(.*)' on Google Search")]
        public void GivenAUserSearchesForOnGoogleSearch(string search)
        {
            _googleSearchPage.
                NavigateToGoogleSearchPage().
                Set(search).
                ClickSearch();
        }

        [When(@"a user clicks on Clover's official page on Google results")]
        public void WhenAUserClicksOnCloverSOfficialPageOnGoogleResults()
        {
            const string clover = "Clover®";
            _googleSearchPage.ClickResult(clover);
        }

        [Then(@"Clover's official page should be displayed on Google results")]
        public void ThenCloverSOfficialPageShouldBeDisplayedOnGoogleResults()
        {
            const string clover = "Clover®";
            Assert.IsTrue(_googleSearchPage.IsExpectedResultDisplayed(clover),"_googleSearchPage.IsExpectedResultDisplayed(clover)");
        }



    }
}
