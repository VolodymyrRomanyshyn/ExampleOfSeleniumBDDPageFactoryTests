using Framework;
using Framework.Driver;
using Framework.PageDecorators.Attributes;
using Framework.Pages;
using Framework.WebElements;
using SeleniumBDDTests.Model.BaseElements.Table;
using System.Collections.Generic;

namespace SeleniumBDDTests.Model.MyWishListPage
{
    public class MyWishList : BasePage, ILoad
    {
        [XPath("//a[@class = 'product-name']")] IList<Button> TopSellers;
        [XPath("//*[@class = 'table table-bordered']")] public TableTrTd WishTable;
        [XPath("//*[@class = 'product_infos']/*[@class ='product-name']")] public BaseElement Result;

        public MyWishList(BaseDriver driver) : base(driver)
        {
        }

        public bool IsLoaded() => TopSellers.Random().IsVisible;
    }
}
