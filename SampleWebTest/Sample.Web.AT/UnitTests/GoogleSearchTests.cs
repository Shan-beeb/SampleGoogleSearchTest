using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sample.PageObject;
using Sample.PageObject.PageObjects.Clover;
using Sample.PageObject.PageObjects.Google;

namespace Sample.Web.AT.UnitTests
{
    [TestClass]
    public class GoogleSearchTests : SeleniumBaseTest
    {
        private const string GoogleUrl = "https://www.google.com";


        [TestMethod]
        [DataRow("Chrome")]
        [DataRow("HeadLessChrome")]
        [DataRow("Firefox")]
        [DataRow("InternetExplorer")]
        [DataRow("Android")]
        [DataRow("Ios")]
        public void DesktopBrowsers(string browserType)
        {
            Driver = BrowserFactory.GetWebDriver(browserType);
            var page = new Page(Driver);
            page.NavigateTo(GoogleUrl);
            var googlePage = new GoogleSearchPage(page);
            var cloverPage = new CloverHomePage(page);

            googlePage.
                Set("Clover").
                ClickSearch().
                ClickResult("Clover®");

            cloverPage.
                WaitForCloverPage();

            Assert.IsTrue(cloverPage.IsPageTitleMatch(), "Title not matched");
        }
    }
}