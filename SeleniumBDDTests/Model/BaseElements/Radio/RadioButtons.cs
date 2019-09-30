using Framework;
using Framework.Driver;
using Framework.PageDecorators.Attributes;
using Framework.Pages;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumBDDTests.Model.BaseElements
{
    public class RadioButtons : SubPage, IRadioButtons
    {
        [ClassName("radio-inline")]public IList<RadioElement> radioElements;

        public RadioButtons(IWebElement Element, BaseDriver Driver, string Name) : base(Element, Driver, Name)
        {
        }

        public void CheckByText(string text) => radioElements.FirstOrDefault(el => el.VisibleText.Contains(text)).Check();
    }
}
