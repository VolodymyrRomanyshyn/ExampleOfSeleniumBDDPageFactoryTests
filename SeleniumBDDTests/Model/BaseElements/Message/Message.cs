using Framework.Driver;
using Framework.PageDecorators.Attributes;
using Framework.Pages;
using Framework.WebElements;
using OpenQA.Selenium;

namespace SeleniumBDDTests.Model.BaseElements.Message
{
    public class Message : SubPage, IMessage
    {
        [XPath("div//p")] public BaseElement TextMessage;
        [XPath("div//a")] public Button CloseBtn;
        public Message(IWebElement Element, BaseDriver Driver, string Name) : base(Element, Driver, Name)
        {
        }

        public override string VisibleText => TextMessage.VisibleText;

        public void Close()
        {
            WebWaiter.UntilElementAppearOnPage(By.XPath("//a[@title = 'Close']"));
            CloseBtn.Click();
            WebWaiter.UntilElementDissapearOnPage(By.XPath("//*[@class ='fancybox-overlay fancybox-overlay-fixed']"));
        }
    }
}
