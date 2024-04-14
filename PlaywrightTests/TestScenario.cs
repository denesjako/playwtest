using System.Text.RegularExpressions;
using Microsoft.Playwright;

namespace PlaywrightTests;

    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class TestScenario
    {
        protected LoginPage _loginPage; 
        protected SignUpPage _signUpPage;
        protected BusinessDetailsPage _businessDetailsPage;        
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IPage _page;

        private string _email = Tools.GetEmail();

        private string _pass = Tools.GetPassword();

        [SetUp]
        public async Task SetupAsync()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            _page = await _browser.NewPageAsync();
            await _page.SetViewportSizeAsync(1920, 1080);
        }

        [Test]
        public async Task EndToEndTest()
        {
            await _page.GotoAsync("https://app.taxually.com/");

            await Assertions.Expect(_page).ToHaveTitleAsync(new Regex("Taxually - Sign in"));

            _loginPage = new LoginPage(_page);

            await _loginPage.PerformSignIn(_email, _pass);

            await _page.WaitForNavigationAsync();

            await Assertions.Expect(_page.GetByText("Getting started with Taxually")).ToBeVisibleAsync();

            _signUpPage = new SignUpPage(_page);

            await _signUpPage.FillOutSignUpPage();

            _businessDetailsPage = new BusinessDetailsPage(_page);

            await _businessDetailsPage.FillOutBusinessDetailsForm();

            await Assertions.Expect(_page.GetByText("Passport or ID")).ToBeVisibleAsync();
        }

        [TearDown]
        public async Task TeardownAsync()
        {
            await _browser.CloseAsync();
            _playwright.Dispose();
        }
    }

