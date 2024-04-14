using Microsoft.Playwright;

namespace PlaywrightTests;
    public class SignUpPage
    {
        private readonly IPage _page;

        public SignUpPage(IPage page)
        {
            _page = page;
        }

        public async Task FillOutSignUpPage()
        {
            await SelectValueFromDropdown("Hungary");
            await SelectTargetCountry(4);
            await GetVATNumbers();
            await ClickNextStepButton();
        }

        private async Task SelectTargetCountry(int countryListNumber)
        {
            string attributeName = "data-unique-meta_country-code";
            var elementsWithAttribute = await _page.QuerySelectorAllAsync($"button[{attributeName}]");
            var attributeValues = new List<string>();

            foreach (var element in elementsWithAttribute)
            {
                var attributeValue = await element.GetAttributeAsync(attributeName);

                if (!string.IsNullOrEmpty(attributeValue))
                {
                    attributeValues.Add(attributeValue);
                    await _page.EvaluateAsync($"document.querySelector('[{attributeName}=\"{attributeValue}\"]').scrollIntoView();");
                    await _page.WaitForTimeoutAsync(1000);
                    await _page.ClickAsync($"button[{attributeName}='{attributeValue}']");
                }

                if (attributeValues.Count == countryListNumber ||  attributeValues.Count == 10)
                {
                    break;
                }
            }
        }

        private async Task GetVATNumbers()
        {
            string buttonText = "Help me get a VAT number";
            var buttons = await _page.QuerySelectorAllAsync($"button:has-text(\"{buttonText}\")");

            foreach (var button in buttons)
            {
                await button.ClickAsync();
                await _page.WaitForTimeoutAsync(1000);
            }
        }

        private  async Task SelectValueFromDropdown(string selectedValue)
        {
            await _page.FillAsync($"//ng-select[@data-unique-id='payment-service-subscriptions_select-country-establishment']//input", selectedValue);
            await _page.Keyboard.PressAsync("Tab");
        }

        private async Task ClickNextStepButton()
        {
            string dataUniqueId = "payment-service-subscriptions_button-next-step";
            await _page.ClickAsync($"[data-unique-id='{dataUniqueId}']");
        }
    }
