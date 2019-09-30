using Framework.Driver;
using Framework.PageDecorators.Attributes;
using Framework.Pages;
using Framework.WebElements;
using OpenQA.Selenium;

namespace SeleniumBDDTests.Model.BaseElements
{
    public class RadioElement : SubPage
    {
        [XPath("label/div/span")] public BaseElement Checked;
        [Name("id_gender")] public Button RadioButton;

        public RadioElement(IWebElement Element, BaseDriver Driver, string Name) : base(Element, Driver, Name)
        {
        }

        public bool IsChecked => Checked.TagValue("class").Equals("checked");

        public void Check()
        {
            if(!IsChecked)
            {
                RadioButton.IWebElement.Click();
            }
        }
    }
}
