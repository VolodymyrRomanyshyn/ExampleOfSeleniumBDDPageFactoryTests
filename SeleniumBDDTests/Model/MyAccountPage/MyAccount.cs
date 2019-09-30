using Framework.Driver;
using Framework.PageDecorators.Attributes;
using Framework.Pages;
using Framework.WebElements;

namespace SeleniumBDDTests.Model.MyAccountPage
{
    public class MyAccount : BasePage, ILoad
    {
        [ClassName("header_user_info")] public Button Account;
        [ClassName("lnk_wishlist")] public Button MyWishList;

        public MyAccount(BaseDriver driver) : base(driver)
        {
        }

        public bool IsLoaded() =>
            Account.IsVisible &&
            MyWishList.IsVisible;
    }
}
