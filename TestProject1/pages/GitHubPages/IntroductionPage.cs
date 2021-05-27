using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubProject
{
    class IntroductionPage : BasePage
    {
        private By signInBtn;
        public IntroductionPage ()
        {
            this.signInBtn = By.CssSelector("[href = '/login']");
        }

        public By SignInBtn { get => signInBtn; set => signInBtn = value; }
    }
}
