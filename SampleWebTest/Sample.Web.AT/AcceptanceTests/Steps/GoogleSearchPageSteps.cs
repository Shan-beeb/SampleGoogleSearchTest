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

        // Givens
        [Given(@"a user searches for '(.*)' on Google Search")]
        public void GivenAUserSearchesForOnGoogleSearch(string search)
        {
            _googleSearchPage.
                NavigateToGoogleSearchPage().
                Set(search).
                ClickSearch();
        }


        // Whens
        [When(@"a user clicks on '(.*)' official page on Google results")]
        public void WhenAUserClicksOnOfficialPageOnGoogleResults(string result)
        {
            //const string clover = "Clover®";
            _googleSearchPage.ClickResult(result);
        }


        // Thens
        [Then(@"'(.*)' official page should be displayed on Google results")]
        public void ThenCloverSOfficialPageShouldBeDisplayedOnGoogleResults(string result)
        {
            Assert.IsTrue(_googleSearchPage.IsExpectedResultDisplayed(result),"_googleSearchPage.IsExpectedResultDisplayed(clover)");
        }

    }
}
