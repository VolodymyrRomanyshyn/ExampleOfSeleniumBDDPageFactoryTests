using Framework.Driver;
using Framework.PageDecorators.Attributes;
using Framework.Pages;
using Framework.WebElements;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace SeleniumBDDTests.Model.BaseElements.Table
{
    public class Row : SubPage, IRow
    {
        [XPath("td")] public IList<BaseElement> Cells;

        public Row(IWebElement Element, BaseDriver Driver, string Name) : base(Element, Driver, Name)
        {
        }

        public IBaseElement this[int Cell] => Cells[Cell];
    }
}
