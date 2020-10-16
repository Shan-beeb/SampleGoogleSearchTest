using BoDi;
using Sample.PageObject;
using TechTalk.SpecFlow;

namespace Sample.Web.AT.AcceptanceTests.Steps
{
    [Binding]
    public class BrowserTypeInitializer
    {
        private readonly IObjectContainer _objectContainer;
        private readonly BrowserFactory _browserFactory;

        public BrowserTypeInitializer(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _browserFactory = new BrowserFactory();
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