using Framework.SiteDecorators.Attributes;
using Framework.Sites;
using SeleniumBDDTests.Model.AutomationpracticeMainPage;
using SeleniumBDDTests.Model.MyAccountPage;
using SeleniumBDDTests.Model.MyWishListPage;
using SeleniumBDDTests.Model.ProductCardPage;
using SeleniumBDDTests.Model.RegistrationPage;
using SeleniumBDDTests.Model.SignInPage;

namespace Tests.Site
{
    public class Automationpractice : BaseSite
    {
        [Link("http://automationpractice.com")]
        public AutomationpracticeMain AutomationpracticeMain;
        public SignIn SignIn;
        public Registration Registration;
        public MyAccount MyAccount;
        public MyWishList MyWishList;
        public ProductCard ProductCard;
    }
}
