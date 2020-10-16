using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sample.PageObject.PageObjects.Amazon;
using TechTalk.SpecFlow;

namespace Sample.Web.AT.AcceptanceTests.Steps
{

    [Binding]
    public class AmazonHomePageSteps
    {
        private readonly AmazonHomePage _amazonHomePage;

        public AmazonHomePageSteps(AmazonHomePage amazonHomePage)
        {
            _amazonHomePage = amazonHomePage;
        }

        [Then(@"a user should be able to navigate to amazon\.com")]
        public void ThenAUserShouldBeAbleToNavigateToAmazon_Com()
        {
           _amazonHomePage.WaitForAmazonHomePage();
           Assert.IsTrue(_amazonHomePage.IsAmazonHomePageTitleMatch(),"_amazonHomePage.IsAmazonHomePageTitleMatch()");
        }

    }
}
