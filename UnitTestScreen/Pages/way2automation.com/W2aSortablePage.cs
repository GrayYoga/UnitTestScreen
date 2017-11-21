using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;

namespace UnitTestScreen
{
    public class W2aSortablePage : BasePage, IGoToAuthenticate
    {
        private By DroppableFrame = By.CssSelector("iframe[src = 'sortable/default.html']");
        private By SortableList = By.Id("sortable");
        private By ItemsSelector = By.CssSelector("li");

        public W2aSortablePage(RemoteWebDriver driver) : base(driver)
        {
        }

        public W2aSortablePage() : base()
        {
        }

        public W2aSortablePage SwitchToSortableFrame()
        {
            Driver.SwitchTo().Frame(Driver.FindElement(DroppableFrame));
            return this;
        }

        public W2aSortablePage RevertSortElements()
        {
            var items = Driver.FindElements(ItemsSelector);

            if (items.Count == 0)
                throw new NoSuchElementException("Элементы для сортировки не найдены.");

            var elementSize = Driver.FindElementByXPath($"//li[text()='Item 1']").Size;
            for (int index = 1; index < items.Count; index++)
            {
                var actions = new Actions(Driver);
                actions
                    .ClickAndHold(Driver.FindElementByXPath($"//li[text()='Item {index}']"))
                    .MoveToElement(
                        Driver.FindElementByXPath($"//li[text()='Item {items.Count}']"),
                        0, elementSize.Height)
                    .Release()
                    .Build()
                    .Perform();
            }

            return this;
        }

        public IReadOnlyList<IWebElement> GetSortableList()
        {
            return (Driver.FindElements(ItemsSelector));
        }

        public IBaseLoginPage GoToLoginPage()
        {
            return new W2aLoginPage(Driver).GoToLoginPage();
        }

        /// <summary>
        /// Получает на входе строку вида "Item 1", возвращает число из этой строки
        /// </summary>
        /// <param name="itemText"></param>
        /// <returns></returns>
        private int GetItemValue(string itemText)
        {
            return int.Parse(
                itemText.Substring(
                    itemText.LastIndexOf(" ")));
        }

        public bool IsNormalSort()
        {
            var result = true;
            var itemsList = Driver.FindElements(ItemsSelector);
            for (int index = 1; index < itemsList.Count; index++)
            {
                if (GetItemValue(itemsList[index].Text) < GetItemValue(itemsList[index - 1].Text))
                    result = false;
            }
            return result;
        }

        public bool IsRevertSort()
        {
            var result = true;
            var itemsList = Driver.FindElements(ItemsSelector);
            for (int index = 1; index < itemsList.Count; index++)
            {
                if (GetItemValue(itemsList[index].Text) > GetItemValue(itemsList[index - 1].Text))
                    result = false;
            }
            return result;
        }
    }
}
