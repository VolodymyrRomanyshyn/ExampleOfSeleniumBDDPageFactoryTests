using Framework.Driver;
using Framework.PageDecorators.Attributes;
using Framework.Pages;
using Framework.WebElements;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace SeleniumBDDTests.Model.BaseElements.Table
{
    public class TableTrTd : SubPage, ITable
    {
        [XPath("tbody/tr")] public IList<Row> Rows;

        public TableTrTd(IWebElement Element, BaseDriver Driver, string Name) : base(Element, Driver, Name)
        {
        }

        public IRow this[int Row] => Rows[Row];
    }
}
