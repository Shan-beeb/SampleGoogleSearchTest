using BoDi;
using Sample.PageObject;
using TechTalk.SpecFlow;

namespace Sample.Web.AT.AcceptanceTests
{
    [Binding]
    public class WebDriverSupport
    {
        private readonly IObjectContainer _objectContainer;

        public WebDriverSupport(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [AfterScenario()]
        public void AfterScenario()
        {
            var page = _objectContainer.Resolve<Page>();
            page.DisposeDriver();
        }
    }
}
