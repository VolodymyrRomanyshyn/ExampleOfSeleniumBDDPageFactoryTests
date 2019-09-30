using Framework;
using Framework.Driver;
using Framework.PageDecorators.Attributes;
using Framework.Pages;
using Framework.WebElements;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumBDDTests.Model.BaseElements
{
    public class ScrollableDropDown : SubPage, IDropDown
    {
        [XPath("span")] public BaseElement SelectedOption;
        [XPath("select")] public Button Selector;
        [XPath("select/option")] public IList<Button> options;

        public ScrollableDropDown(IWebElement Element, BaseDriver Driver, string Name) : base(Element, Driver, Name)
        {
        }

        public void ClickByText(string text)
        {
            if (!IsValueSelected(text))
            {
                Selector.IWebElement.Click();
                var option = options.FirstOrDefault(opt => opt.VisibleText.StartsWith(text));
                option.JavaScriptExecutor.ScrollIntoView();
                option.Click();
            }
        }

        public bool IsValueSelected(string value) => SelectedOption.VisibleText.Equals(value);


        public void SelectAnyOption()
        {
            Selector.IWebElement.Click();
            var option = options.Random();
            option.JavaScriptExecutor.ScrollIntoView();
            option.Click();
        }
    }
}
