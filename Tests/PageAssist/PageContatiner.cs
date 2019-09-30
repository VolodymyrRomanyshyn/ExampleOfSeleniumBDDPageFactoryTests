using Framework.Pages;
using Framework.WebElements;
using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Tests.Site;

namespace Tests.PageAssist
{
    public class PageContatiner
    {
        private static IAbstractPage AbstractPage;
        public static Logger Logger => AbstractPage.BaseDriver.Logger;
        public static Automationpractice Site;
        public static string Result;

        public IAbstractPage CurrentPage => AbstractPage;

        public static void NavigateTo(string stringField)
        {
            AbstractPage = PageByField(stringField);
            var start = AbstractPage as BaseStartPage;
            start.OpenUrl();
        }

        public static TPage Instance<TPage>() where TPage : IAbstractPage => (TPage)AbstractPage;



        public static TElement Element<TElement>(string elementName) where TElement : IElement
        {
            var fieldInfo = AbstractPage.GetType().GetField(elementName,
                BindingFlags.Instance | BindingFlags.Static |
                BindingFlags.Public | BindingFlags.NonPublic);
            if (fieldInfo is null)
            {
                throw new NullReferenceException($"Element {elementName} do not exist on page: {AbstractPage.Name}");
            }
            return (TElement)fieldInfo.GetValue(AbstractPage);
        }

        public static IList<TElement> ElementList<TElement>(string elementListName) where TElement : IElement
        {
            var fieldInfo = AbstractPage.GetType().GetField(elementListName,
                BindingFlags.Instance | BindingFlags.Static |
                BindingFlags.Public | BindingFlags.NonPublic);
            if (fieldInfo == null)
            {
                throw new NullReferenceException($"Element {elementListName} do not exist on page: {AbstractPage.Name}");
            }
            var proxy = fieldInfo.GetValue(AbstractPage);
            var list = proxy as IEnumerable;
            return list.Cast<TElement>().ToList();
        }

        internal static void SetCurrentPage(string stringType) => AbstractPage = PageByField(stringType);

        private static IAbstractPage PageByField(string stringType)
        {
            var fieldInfo = Site.GetType().GetField(stringType,
                BindingFlags.Instance | BindingFlags.Static |
                BindingFlags.Public | BindingFlags.NonPublic);
            if (fieldInfo is null)
            {
                throw new NullReferenceException($"Page {stringType} do not exist on Site: {Site.GetType().Name}");
            }
            return (IAbstractPage)fieldInfo.GetValue(Site);
        }

        public static void CloseDriver()
        {
            if (AbstractPage != null)
            {
                AbstractPage.BaseDriver?.Close();
                AbstractPage.BaseDriver?.Quit();
            }
        }

    }
}
