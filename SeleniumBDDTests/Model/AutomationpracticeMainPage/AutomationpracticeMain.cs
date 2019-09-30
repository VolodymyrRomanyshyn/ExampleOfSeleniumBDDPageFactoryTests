using Framework.Driver;
using Framework.PageDecorators.Attributes;
using Framework.Pages;
using Framework.WebElements;

namespace SeleniumBDDTests.Model.AutomationpracticeMainPage
{
    public class AutomationpracticeMain : BaseStartPage, ILoad
    {
        [ClassName("login")] public Button SignIn;

        public AutomationpracticeMain(BaseDriver Driver) : base(Driver)
        {
        }

        public AutomationpracticeMain(BaseDriver baseDriver, string link) : base(baseDriver, link)
        {
        }

        public bool IsLoaded() => SignIn.IsVisible;
    }
}
