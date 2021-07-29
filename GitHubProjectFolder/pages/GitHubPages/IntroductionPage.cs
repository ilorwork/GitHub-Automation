﻿using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    public class IntroductionPage : GitHubPage
    {
        private readonly By signInBtn;
        public IntroductionPage ()
        {
            this.signInBtn = By.CssSelector("[href = '/login']");
        }

        public LoginPage ClickLogin()
        {
            Click(signInBtn, nameof(signInBtn));
            return new LoginPage();
        }
    }
}
