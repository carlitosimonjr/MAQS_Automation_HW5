using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.Utilities.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModel;

namespace Tests
{
    /// <summary>
    /// SeleniumTest test class with VS unit
    /// </summary>
    [TestClass]
    public class SeleniumTestsVSUnit : BaseSeleniumTest
    {

        /// <summary>
        /// Enter credentials test
        /// </summary>
        [TestMethod]
        public void VerifyAboutPageTest()
        {
            string username = Config.GetGeneralValue("Username");
            string password = Config.GetGeneralValue("Password");

            this.ManagerStore.AddOrOverride(new SeleniumDriverManager(() =>
                 WebDriverFactory.GetBrowserWithDefaultConfiguration(SeleniumConfig.GetBrowserType("Edge")), this.TestObject));

            LoginPageModel page = new LoginPageModel(this.TestObject);

            page.OpenLoginPage();
            HomePageModel homepage = page.LoginWithValidCredentials(username, password);
            Assert.IsTrue(homepage.IsPageLoaded());

            AboutPageModel aboutPage = homepage.ClickAboutNavigationButton();
            Assert.IsTrue(aboutPage.IsPageLoaded());
        }
    }
}
