﻿using System;
using System.ComponentModel;
using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    public class UserHomePage : GitHubPage
    {
        private readonly By newMenuBtn;
        private readonly By newDropDownOptions;

        public UserHomePage ()
        {
            this.newMenuBtn = By.CssSelector("summary[aria-label = 'Create new…']");
            this.newDropDownOptions = By.XPath("//*[@href='/new']/parent::details-menu/a");
        }

        public UserHomePage OpenNewMenu()
        {
            Click(newMenuBtn, nameof(newMenuBtn));
            return this;
        }
        private GitHubPage ChooseOptionFromNewMenu(NewMenuOptions newMenuOptions)
        {
            // TODO: return corresponding pages
            ClickOnOptionUsingEnum(FindElements(newDropDownOptions), newMenuOptions);

            switch (newMenuOptions)
            {
                case NewMenuOptions.NewRepository:
                    return new NewRepPage();
                default:
                    throw new Exception($"could not return any page for this option: {newMenuOptions}");
            }
            //TODO: check maybe using ByAll method for the return type here
        }
        public NewRepPage ChooseNewRepOption()
        {
            return (NewRepPage)ChooseOptionFromNewMenu(NewMenuOptions.NewRepository);
        }
        
        public enum NewMenuOptions
        {
            [Description("New repository")]
            NewRepository,
        }
    }
}
