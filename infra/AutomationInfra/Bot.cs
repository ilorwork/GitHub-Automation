using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;
using infra.Helpers;

public class ActionBot
{
    private ILogger logger;
    private void Log(string info) => logger.LogInfo(info);

    private const double DefaultTimeout = 30;
    private const string defaultDesc = "Unspecified element";
    private IWebDriver driver;
    private WebDriverWait wait;

    public ActionBot(IWebDriver driver, WebDriverWait wait, ILogger logger)
    {
        this.driver = driver;
        this.wait = wait;
        this.logger = logger;
    }


    public void Click(By by, string description = defaultDesc)
    {
        Click(WaitForElementToBeClickable(by), description);
    }

    public void Click(IWebElement element, string description = defaultDesc)
    {
        try
        {
            element = WaitForElementToBeClickable(element);
            element.Click();
            Log($"Click on {description}");
        }
        catch (Exception e)
        {
            Console.WriteLine("{0} Exception caught.", e);
            Log($"Click on {description} has failed: {e}");
            throw new Exception("Click element: " + element + " has failed! exception: ", e);
        }
    }

    public string GetText(By by, string description = defaultDesc)
    {
        IWebElement element = WaitForElementToBeVisible(by);
        string txt = element.Text;
        Log($"Get text from {description}");
        return txt;
    }

    public void SendKeys(By by, string text, string description = defaultDesc, bool clearFirst = true)
    {
        IWebElement? element = null;
        try
        {
            element = FindElement(by);
            Click(element, description);
            if (clearFirst) element.Clear();
            element.SendKeys(text);
            Log($"Send: {text} To: {description}");
        }
        catch (Exception e)
        {
            Console.WriteLine("{0} Exception caught.", e);
            Log($"Send-Keys to: {description} has failed: {e}");
            throw new Exception("Send keys to element: " + element + " has failed! exception: ", e);
        }
    }

    public IWebElement WaitForElementToBeVisible(By by, double timeoutInSeconds = DefaultTimeout)
    {
        return wait.Until(ExpectedConditions.ElementIsVisible(by));
    }

    public void WaitForTextToBePresentInElement(By by, string text, double timeoutInSeconds = DefaultTimeout)
    {
        string[] tests = { text };
        WaitForElementToContainAnyText(by, tests, timeoutInSeconds);
    }

    public void WaitForElementToContainAnyText(By by, string[] texts, double timeoutInSeconds = DefaultTimeout)
    {
        var element = WaitForElementToBeVisible(by);
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        var condition = new Func<IWebDriver, bool>((driver) =>
        {
            return texts.Any(text => ExpectedConditions.TextToBePresentInElement(element, text)(driver));
        });
        wait.Until(condition);
    }

    public IWebElement WaitForElementToBeClickable(IWebElement element, double timeoutInSeconds = DefaultTimeout)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        return wait.Until(ExpectedConditions.ElementToBeClickable(element));
    }

    public IWebElement WaitForElementToBeClickable(By by, double timeoutInSeconds = DefaultTimeout)
    {
        return WaitForElementToBeClickable(FindElement(by), timeoutInSeconds);
    }

    public bool IsElementVisible(By by, double timeoutInSeconds = DefaultTimeout)
    {
        try
        {
            WaitForElementToBeVisible(by, timeoutInSeconds);
            return true;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public IWebElement FindElement(By by)
    {
        //return wait.Until(drv => drv.FindElement(by));
        return WaitForElementToBeVisible(by);
    }

    public ReadOnlyCollection<IWebElement> FindElements(By by, double timeoutInSeconds = DefaultTimeout)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        return wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
    }

    public void ScrollToElement(By by)
    {
        IWebElement element = FindElement(by);

        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
    }

    public void ClickOnOptionUsingEnum(ReadOnlyCollection<IWebElement> listOfOptions, Enum option)
    {
        bool elementFound = default;
        var enumOptionDescription = HelpersMethods.GetEnumDescriptionFromValue(option);
        foreach (var webElement in listOfOptions)
        {
            if (!webElement.Text.Equals(enumOptionDescription)) continue;
            Click(webElement, enumOptionDescription);
            elementFound = true;
            break;
        }
        if (!elementFound)
        {
            throw new Exception("Could not find any element to click on!");
        }
    }
}