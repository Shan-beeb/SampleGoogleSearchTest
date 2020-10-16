using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sample.PageObject.PageObjects.Clover;
using TechTalk.SpecFlow;

namespace Sample.Web.AT.AcceptanceTests.Steps
{
    [Binding]
    public class CloverPageSteps
    {
        private readonly CloverHomePage _cloverHomePage;

        public CloverPageSteps(CloverHomePage cloverHomePage)
        {
            _cloverHomePage = cloverHomePage;
        }

        [Then(@"a user should be able to navigate to Clovers\.com")]
        public void ThenAUserShouldBeAbleToNavigateToCloversCom()
        {
            _cloverHomePage.WaitForCloverPage();
            Assert.IsTrue(_cloverHomePage.IsPageTitleMatch(),"_cloverHomePage.IsPageTitleMatch()");
        }

    }
}
