using Framework.Driver;
using Framework.PageDecorators.Attributes;
using Framework.Pages;
using Framework.WebElements;
using SeleniumBDDTests.Model.BaseElements.Message;

namespace SeleniumBDDTests.Model.ProductCardPage
{
    public class ProductCard : BasePage, ILoad
    {
        [ClassName("header_user_info")] public Button Account;
        [Id("wishlist_button")] public Button AddToWishList;
        [XPath("//div[@class = 'fancybox-overlay fancybox-overlay-fixed']")] public Message AddedToYourWishlist;

        public ProductCard(BaseDriver driver) : base(driver)
        {
        }

        public bool IsLoaded() => AddToWishList.IsVisible;
        
    }
}
