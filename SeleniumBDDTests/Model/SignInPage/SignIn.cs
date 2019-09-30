using Framework.Driver;
using Framework.PageDecorators.Attributes;
using Framework.Pages;
using Framework.WebElements;

namespace SeleniumBDDTests.Model.SignInPage
{
    public class SignIn : BasePage, ILoad
    {
        [Id("email_create")] public TextInputField EmailAddress;
        [Id("SubmitCreate")] public Button CreateAnAccount;

        public SignIn(BaseDriver driver) : base(driver)
        {
        }

        public bool IsLoaded() => 
            EmailAddress.IsVisible && 
            CreateAnAccount.IsVisible;
    }
}
