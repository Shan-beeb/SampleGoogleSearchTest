using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
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
        [DataRow("Firefox")]
        [DataRow("InternetExplorer")]
        public void ChromeTest(string browserType)
        {
            Driver = BrowserFactory.GetWebDriver(browserType);
            var page = new Page(Driver);
            page.NavigateTo(GoogleUrl);
            var googlePage = new GoogleSearchPage(page);
            var cloverPage = new CloverHomePage(page);

            googlePage.
                Set("Clover").
                ClickSearch().
                ClickResult("Clover");

            cloverPage.
                WaitForCloverPage();

            const string title = "Credit Card Processing for Small Businesses";

            Assert.AreEqual(title,cloverPage.GetTitle(),"Title not matched");
        }
       
    }
}
