using System;
using GitHub.config;

namespace GitHub.pages.GitHubPages
{
    public abstract class AbstractPage : BasePage
    {
        // protected AbstractPage()
        // {
            // try
            // {
            //     //AssertInPage();
            //     Log($"Page {GetPageName()} is displayed");
            // }
            // catch (Exception ex)
            // {
            //     var pageLoadException = new Exception($"Page '{GetPageName()}' is not displayed", ex);
            //     Log(pageLoadException.ToString());
            //     throw pageLoadException;
            // }
        // }

        //protected abstract void AssertInPage();

        protected abstract string GetPageName();
    }
}
