using Microsoft.Playwright;

namespace PlaywrightTests;
    public class BusinessDetailsPage
    {
        private readonly IPage _page;

        public BusinessDetailsPage(IPage page)
        {
            _page = page;
        }

        public async Task FillOutBusinessDetailsForm()
        {
            await SelectValueFromLegalStatusDropdown("Company");

            await FillFullLegalNameOfBusinessInputField($"Denes Jako Test Company {DateTime.Now.ToString("dddd, dd MMMM, yyyy")}");

            await FillIncorporationNumberInputField(Tools.GenerateRandomNumberUpToHundred());

            await SetIncorporationDateForToday();

            await FillStateInputField("Random");

            await FillZipInputField(Tools.GenerateRandomNumberWithLength(4));

            await FillCityInputField("Random City");

            await FillStreetInputField("Random Street 1");

            await FillHouseNumberInputField(Tools.GenerateRandomNumberWithLength(3));

            await ClickNextStepButton();
        }

        private  async Task SelectValueFromLegalStatusDropdown(string selectedValue)
        {
            await _page.ClickAsync("#companyLegalStatus");
            await _page.FillAsync($"//ng-select[@data-unique-id='registration-flow-company-info_input-legal-status']//input", selectedValue);
            await _page.Keyboard.PressAsync("Enter");
        }

        private  async Task FillFullLegalNameOfBusinessInputField(string legalName)
        {
            await _page.FillAsync("#companyLegalNameOfBusiness", legalName);
        }

        private  async Task FillIncorporationNumberInputField(string incorporationNumber)
        {
            await _page.FillAsync("#companyRegistrationNumber", incorporationNumber);
        }

        private  async Task SetIncorporationDateForToday()
        {
            await _page.ClickAsync("[data-unique-id='registration-flow-company-info_button-toggle-datepicker']");
            await _page.ClickAsync($"//div[@aria-label='{DateTime.Now.ToString("dddd, MMMM dd, yyyy")}']");
        }

        private  async Task FillStateInputField(string state)
        {
            await _page.FillAsync("#companyState", state);
        }

        private  async Task FillZipInputField(string zip)
        {
            await _page.FillAsync("#companyZipCode", zip);
        }

        private  async Task FillCityInputField(string city)
        {
            await _page.FillAsync("#companyCity", city);
        }

        private  async Task FillStreetInputField(string street)
        {
            await _page.FillAsync("#companyStreet", street);
        }

        private  async Task FillHouseNumberInputField(string houseNumber)
        {
            await _page.FillAsync("#companyHouseNumber", houseNumber);
        }

        private async Task ClickNextStepButton()
        {
            string dataUniqueId = "registration-flow-company-info_button-next-step";

            await _page.ClickAsync($"[data-unique-id='{dataUniqueId}']");
        }
    }
