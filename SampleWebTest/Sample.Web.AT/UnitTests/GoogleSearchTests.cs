using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sample.PageObject;
using Sample.PageObject.PageObjects.Amazon;
using Sample.PageObject.PageObjects.Clover;
using Sample.PageObject.PageObjects.Google;

namespace Sample.Web.AT.UnitTests
{
    [TestClass]
    public class GoogleSearchTests : SeleniumBaseTest
    {

        [TestMethod]
        [DataRow("Chrome")]
        [DataRow("HeadLessChrome")]
        [DataRow("Firefox")]
        [DataRow("InternetExplorer")]
        [DataRow("Android")]
        [DataRow("Ios")]
        public void CloverMultiBrowserTest(string browserType)
        {
            Driver = BrowserFactory.GetWebDriver(browserType);
            var page = new Page(Driver);
            var googlePage = new GoogleSearchPage(page);
            var cloverPage = new CloverHomePage(page);

            googlePage.
                NavigateToGoogleSearchPage().
                Set("Clover").
                ClickSearch().
                ClickResult("Clover");

            cloverPage.
                WaitForCloverPage();

            Assert.IsTrue(cloverPage.IsPageTitleMatch(), "Title not matched");
        }

        [TestMethod]
        [DataRow("Chrome")]
        [DataRow("HeadLessChrome")]
        [DataRow("Firefox")]
        [DataRow("InternetExplorer")]
        [DataRow("Android")]
        [DataRow("Ios")]
        public void AmazonMultiBrowserTest(string browserType)
        {
            Driver = BrowserFactory.GetWebDriver(browserType);
            var page = new Page(Driver);
            var googlePage = new GoogleSearchPage(page);
            var amazonHomePage = new AmazonHomePage(page);

            googlePage.
                NavigateToGoogleSearchPage().
                Set("amazon").
                ClickSearch().
                ClickResult("amazon");

            amazonHomePage.
                WaitForAmazonHomePage();

            Assert.IsTrue(amazonHomePage.IsAmazonHomePageTitleMatch(), "Title not matched");
        }
    }
}