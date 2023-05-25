# GitHub-Automation

## Summary

C# Automation project for GitHub.com:
Simulates basic new-user operations such as - creating a repository, creating a project, etc.

## Main technologies

This project leverage the following main technologies:

- C#/.Net 6
- NUnit 3
- Selenium WebDriver 4 & Selenium Grid
- POM design pattern
- Extent-Reports

## Modes of operation

- Local browsers (Chrome & FF)
- Remote - Selenium Grid (Chrome & FF)
- Filter by categories
- Parallel execution

## ⚙️Setup

- [Download .NET](https://dotnet.microsoft.com/en-us/download)
- Open terminal and run dotnet --info to ensure installation.
- git clone https://github.com/ilorwork/GitHub-Automation.git
- Download and install [Visual Studio](https://visualstudio.microsoft.com/downloads/)

## Configuration

The different modes of operation are controlled via [Nunit Test Parameters](https://docs.nunit.org/articles/nunit/writing-tests/TestContext.html#testparameters)

The configuration is being set using
the AutomationSettings.RunSetting file which can be found inside "infra" project.

### Parameters

- **Browser**
  - Values: [`"Chrome", "Firefox", "GridChrome", "GridFirefox"`].
  - Default value = `"Chrome"`
  - Description: Specify the wanted browser.
- **SiteUrl**
  - Value: [`"https://github.com"`].
  - Description: The url for your site, for this project it's set to github site.
  - **GridUrl**
  - Value: [`"http://<remote_server_ip>:<port>/wd/hub"`].
  - Description: The url of your selenium grid.
  - **Logger**
  - Values: [`"LocalFile", "ExtentReports"`].
  - Default value = `"ExtentReports"`
  - Description: The logger you want to use, there are two supported loggers LocalFile, and ExtentReports.
  - **width**
  - Value: [`int >= 0`].
  - Default value = `0`
  - Description: The width of the browser window.(for max size width enter 0 or don't specify)
  - **height**
  - Value: [`int >= 0`].
  - Default value = `0`
  - Description: The height of the browser window.(for max size width enter 0 or don't specify)

## Test execution

- Execute GitHub.csproj tests via [dotnet CLI](https://docs.microsoft.com/en-us/dotnet/core/tools/)

```
cd GitHub-Automation\GitHubProjectFolder\
# run all tests
dotnet test
# run tests by categories
dotnet test --filter "Category=<Category_name>"
```

For more info about [dotnet filter command](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test#filter-option-details)
