﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Sample.Web.AT.UnitTests
{
    [TestClass]
    public abstract class SeleniumBaseTest
    {

        protected IWebDriver Driver;
        protected BrowserFactory BrowserFactory;

        [TestInitialize]
        public void TestInitialize()
        {
            BrowserFactory = new BrowserFactory();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
