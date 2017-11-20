using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

namespace UnitTestScreen
{
    public class W2aDroppablePage : BasePage, IGoToAuthenticate
    {
        private By DroppableFrame = By.CssSelector("iframe[src = 'droppable/default.html']");
        private By Draggable = By.Id("draggable");
        private By Droppable = By.Id("droppable");

        public W2aDroppablePage(RemoteWebDriver driver) : base(driver)
        {
        }

        public W2aDroppablePage() : base()
        {
        }

        public W2aDroppablePage SwitchToDroppableFrame()
        {
            Driver.SwitchTo().Frame(Driver.FindElement(DroppableFrame));
            return this;
        }

        public W2aDroppablePage DragAndDrop()
        {
            var actions = new Actions(Driver);
            actions
                .DragAndDrop(Driver.FindElement(Draggable), Driver.FindElement(Droppable))
                .Build()
                .Perform();

            return this;
        }

        public string GetDroppableText()
        {
            return (Driver.FindElement(Droppable).Text);
        }

        public IBaseLoginPage GoToLoginPage()
        {
            return new W2aDroppablePage(Driver).GoToLoginPage();
        }
    }
}
