using BoDi;
using Sample.PageObject;
using TechTalk.SpecFlow;

namespace Sample.Web.AT.AcceptanceTests
{
    [Binding]
    public class BrowserTypeInitializer
    {
        private readonly IObjectContainer _objectContainer;
        private readonly BrowserFactory _browserFactory;

        public BrowserTypeInitializer(IObjectContainer objectContainer,BrowserFactory browserFactory)
        {
            _objectContainer = objectContainer;
            _browserFactory = browserFactory;
        }


        [Given(@"a user is using (.*) browser")]
        public void GivenAUserIsUsingChromeBrowser(string browserType)
        {
            var driver = _browserFactory.GetWebDriver(browserType);
            var page = new Page(driver);
            _objectContainer.RegisterInstanceAs(page);
        }
    }
}