using Framework.Driver;
using Framework.PageDecorators.Attributes;
using Framework.Pages;
using Framework.WebElements;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace SeleniumBDDTests.Model.BaseElements.Message
{
    public class Message : SubPage, IMessage
    {
        [XPath("div//p")] public BaseElement TextMessage;
        [XPath("//a[@title = 'Close']")] public Button CloseBtn;
        [XPath("//*[@class ='fancybox-overlay fancybox-overlay-fixed']")] private IList<BaseElement> OverlayList;
        public Message(IWebElement Element, BaseDriver Driver, string Name) : base(Element, Driver, Name)
        {
        }

        public override string VisibleText => TextMessage.VisibleText;

        public void Close()
        {
            WebWaiter.UntilElementAppearOnPage(By.XPath("//a[@title = 'Close']"));
            CloseBtn.Click();
            try
            {
                var el = BaseDriver.IWebDriver.FindElement(By.XPath("//*[@class ='fancybox-overlay fancybox-overlay-fixed']"));
                WebWaiter.Until(_ => !el.Displayed);
            }
            catch (StaleElementReferenceException) { }
            catch (NoSuchElementException) { }
        }
    }
}
