using Framework.Driver;
using Framework.PageDecorators.Attributes;
using Framework.Pages;
using Framework.WebElements;
using SeleniumBDDTests.Model.BaseElements;

namespace SeleniumBDDTests.Model.RegistrationPage
{
    public class Registration : BasePage, ILoad
    {
        [XPath("//div[@class = 'clearfix']/label/..")] public RadioButtons Title;
        [Id("customer_firstname")] public TextInputField FirstName;
        [Id("customer_lastname")] public TextInputField LastName;
        [Id("passwd")] public TextInputField Password;
        [Id("company")] public TextInputField Company;
        [Id("address1")] public TextInputField Address;
        [Id("city")] public TextInputField City;
        [Id("postcode")] public TextInputField ZipCode;
        [Id("phone")] public TextInputField HomePhone;
        [Id("phone_mobile")] public TextInputField MobilePhone;
        [Id("alias")] public TextInputField AssignAnAddressAliasForFutureReference;
        [Id("uniform-days")] public ScrollableDropDown Dd;
        [Id("uniform-months")] public ScrollableDropDown Mm;
        [Id("uniform-years")] public ScrollableDropDown Yy;
        [Id("uniform-id_state")] public ScrollableDropDown State;
        [Id("uniform-id_country")] public ScrollableDropDown Country;
        [Id("submitAccount")] public Button Register;

        public Registration(BaseDriver driver) : base(driver)
        {
        }

        public bool IsLoaded() =>
            Title.IsVisible &&
            FirstName.IsVisible &&
            LastName.IsVisible &&
            Password.IsVisible &&
            Company.IsVisible &&
            Address.IsVisible &&
            City.IsVisible &&
            ZipCode.IsVisible &&
            HomePhone.IsVisible &&
            MobilePhone.IsVisible &&
            AssignAnAddressAliasForFutureReference.IsVisible &&
            Dd.IsVisible &&
            Mm.IsVisible &&
            Yy.IsVisible &&
            State.IsVisible &&
            Country.IsVisible &&
            Register.IsVisible;
    }
}
