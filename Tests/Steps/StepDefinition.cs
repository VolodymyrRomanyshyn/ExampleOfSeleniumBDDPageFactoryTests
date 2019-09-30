using Framework;
using Framework.Pages;
using Framework.WebElements;
using NUnit.Framework;
using SeleniumBDDTests.Model.BaseElements;
using SeleniumBDDTests.Model.BaseElements.Message;
using SeleniumBDDTests.Model.BaseElements.Table;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Tests.PageAssist;
using Tests.Site;
using Tests.Tables;
using Table = TechTalk.SpecFlow.Table;

namespace Tests.Steps
{
    [Binding]
    public sealed class StepDefinition : PageContatiner
    {
        private readonly ScenarioContext context;
        private string email;

        public StepDefinition(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"User opens web application on (.*) page")]
        public void GivenUserOpensWebApplicationOnPage(string page) => NavigateTo(page);

        [Then(@"User sees loaded (.*) page")]
        public void ThenUserSeesLoadedPage(string page)
        {
            if (!CurrentPage.GetType().Name.Equals(page))
            {
                SetCurrentPage(page);
            }
            var IsLoaded = Instance<ILoad>().IsLoaded();
            Assert.That(IsLoaded, Is.True, $"Page: {CurrentPage.GetType().Name} is loaded: {IsLoaded}");
        }

        [When(@"User clicks on (.*) (?:button|field|element)")]
        public void WhenUserClicksButton(string element) => Element<IButton>(element).Click();

        [Given(@"User provides (.*) in (.*) field")]
        public void GivenUserProvidesXxxInXxxField(string value, string field) => Element<ITextInputField>(field).Clear().SendString(value);

        [When(@"User gets random email and provides in (.*) field")]
        public void GivenUserGetsRandomEmailAndProvidesInXxxField(string field)
        {
            email = $"{RandomString.StringSize(8)}@gmail.com";
            Element<ITextInputField>(field).Clear().SendString(email);
        }

        [When(@"User provides values on fields")]
        public void WhenUserProvidesValuesOnFields(Table table)
        {
            var fields = table.CreateSet<Fields>();
            fields.ForEach(row => Element<ITextInputField>(row.Field).SendString(row.Value));
        }

        [When(@"User chooses (.*) value on (.*) radio buttons")]
        public void WhenUserChoosesAnyValueOnXxxRadioButton(string value, string field) => Element<IRadioButtons>(field).CheckByText(value);

        [When(@"User selects value (.*) on (.*) dropdown")]
        public void WhenUserSelectsValueXxxOnXxxDropdown(string value, string dropDown)
        {
        }

        [When(@"user selects dropdowns with vaues")]
        public void WhenUserSelectsDropdownsWithVaues(Table table)
        {
            var fields = table.CreateSet<Fields>();
            fields.ForEach(row => Element<IDropDown>(row.Field).ClickByText(row.Value));
        }

        [Then(@"User sees on lable (.*) value (.*)")]
        public void ThenUserSeesOnLableXxxValueXxx(string label, string value) => Assert.True(Element<IBaseElement>(label).VisibleText.Contains(value));

        [When(@"User clicks on (.*) element on (.*) list")]
        public void WhenUserClicksOnElementOnXxxList(int element, string elementList) => ElementList<IButton>(elementList)[element].Click();

        [Then(@"List of (.*) (?:buttons|fields|elements) is visible")]
        public void ThenVerifyVisibilytyOfListElements(string name)
        {
            var ElementList = ElementList<IBaseElement>(name);
            Logger.Info($"Verify if list {name} contains more than 0 elements. Count is {ElementList.Count}");
            Assert.That(ElementList.Count > 0, Is.True, $"Verify if list {name} contains more than 0 elements.");
            Logger.Info($"Verify visibilyty of list {name} of {ElementList.Count} elements.");
            foreach (BaseElement element in ElementList)
            {
                Assert.That(element.IsVisible, Is.True, $"Element {element.Name} is visible on page: {CurrentPage.Name}");
            }
        }

        [Given(@"User remembers (.*) element from list (.*) as a result")]
        public void GivenUserRemembersXxxElementFromListXxxAsAResult(int id, string list) => Result = ElementList<IBaseElement>(list)[id].VisibleText;

        [Then(@"Message (.*) appears on page")]
        public void ThenMessageXxxAppearsOnPage(string message) => Assert.True(Element<IMessage>(message).IsVisible);


        [When(@"User closes (.*) message")]
        public void WhenUserClosesXxxMessage(string message) => Element<IMessage>(message).Close();

        [When(@"User clicks on (.*) table (.*) row (.*) cell")]
        public void WhenUserClicksOnXxxTableXxxRowXxxCell(string table, int row, int cell) => Element<ITable>(table)[row - 1][cell - 1].CastTo<Button>().CastTo<CellWithLink>().Link.Click();

        [Then(@"User compares field (.*) with result")]
        public void ThenUserComparesFieldXxxWithResult(string field)
        {
            var result = Result.Trim();
            var expectedResult = Element<IBaseElement>(field).VisibleText.Trim();
            Assert.True(expectedResult.StartsWith(result), $"compating result: {result}, expected result: {expectedResult}");
        }

        [BeforeScenario]
        public void SiteInit() => Site = new Automationpractice();

        [AfterScenario]
        public void Close() => CloseDriver();

    }
}
