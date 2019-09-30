using Framework.Driver;
using Framework.PageDecorators.Attributes;
using Framework.Pages;
using Framework.WebElements;
using OpenQA.Selenium;

namespace SeleniumBDDTests.Model.BaseElements.Table
{
    public class CellWithLink : SubPage
    {
        [XPath("a")] public Button Link;

        public CellWithLink(IWebElement Element, BaseDriver Driver, string Name) : base(Element, Driver, Name)
        {
        }
    }
}
