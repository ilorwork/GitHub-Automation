using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;
using infra.Helpers;

public class ActionBot
{
    private ILogger logger;
    private const double DefaultTimeout = 30;
    private const string defaultDesc = "Unspecified element";
    private IWebDriver driver;

    public ActionBot(IWebDriver driver, ILogger logger)
    {
        this.driver = driver;
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
            var clickableElement = WaitForElementToBeClickable(element);
            clickableElement.Click();
            logger.LogInfo($"Click on {description}");
        }
        catch (Exception ex)
        {
            logger.LogFail($"Failed to click on element: {description}: {ex}");
            throw new InvalidOperationException($"Failed to click on element: {description}", ex);
        }
    }

    public string GetText(By by, string description = defaultDesc)
    {
        try
        {
            var element = WaitForElementToBeVisible(by);
            var txt = element.Text;
            logger.LogInfo($"Get text from {description}");
            return txt;
        }
        catch (Exception ex)
        {
            logger.LogFail($"Failed to get text from: '{description}': {ex}");
            throw new InvalidOperationException($"Failed to get text from: '{description}'", ex);
        }
    }

    public void SendKeys(By by, string text, string description = defaultDesc, bool clearFirst = true)
    {
        try
        {
            var element = FindElement(by);
            Click(element, description);
            if (clearFirst) element.Clear();
            element.SendKeys(text);
            logger.LogInfo($"Send: {text} To: {description}");
        }
        catch (InvalidElementStateException ex)
        {
            logger.LogFail($"Failed to send keys '{text}' to: {description}: {ex}");
            throw;
        }
        catch (Exception ex)
        {
            logger.LogFail($"Send-Keys '{text}' to: {description} has failed: {ex}");
            throw new InvalidOperationException($"Failed to send keys to: {description}", ex);
        }
    }
    
    public string GetCssValue(By by, string cssValueToGet, string description = defaultDesc)
    {
        try
        {
            var element = FindElement(by);
            Click(element, description);
            var cssValue = element.GetCssValue(cssValueToGet);
            if (string.IsNullOrEmpty(cssValue))
            {
                throw new NotFoundException($"CSS value: '{cssValueToGet}' does not exist or is not set for element: {description}");
            }
            logger.LogInfo($"Got CSS value: '{cssValueToGet}' From: {description}");
            return cssValue;
        }
        catch (NotFoundException ex)
        {
            logger.LogFail($"Failed to get CSS value: '{cssValueToGet}' of: {description}. {ex}");
            throw;
        }
    }

    public IWebElement WaitForElementToBeVisible(By by, double timeoutInSeconds = DefaultTimeout)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
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
        var element = FindElement(by);

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
            throw new NotFoundException("Unable to click on element, element not found");
        }
    }
}