using Microsoft.Playwright;

namespace PlaywrightTests;
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        public  async Task FillEmailAddress(string emailAddress)
        {
            await _page.FillAsync("#email", emailAddress);
        }

        public async Task FillPassword(string password)
        {
            await _page.FillAsync("#password", password);
        }

        public async Task ClickSignInButton()
        {
            await _page.ClickAsync("#next");
        }

        public async Task PerformSignIn(string emailAddress, string password)
        {
            await FillEmailAddress(emailAddress);
            await FillPassword(password);
            await ClickSignInButton(); 
        }
    }
