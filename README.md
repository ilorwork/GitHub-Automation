# GitHub-Automation

## Summary

GitHub Automation is a C# automation project for GitHub.com. <br>
It simulates basic new-user operations such as creating a repository, creating a project, and more.

## Main technologies

This project leverage the following main technologies:

- C#/.Net 6
- NUnit 3
- Selenium WebDriver 4 & Selenium Grid
- POM design pattern
- Extent-Reports

## Modes of operation

- Local Browsers (Chrome & Firefox)
- Remote Selenium Grid (Chrome & Firefox)
- Filtering by categories
- Parallel execution

## ⚙️Setup

To set up the project, follow these steps:

- [Download .NET](https://dotnet.microsoft.com/en-us/download) and install it.
- Open terminal and run `dotnet --info` to ensure that the installation was successful.
- Clone the repository: `git clone https://github.com/ilorwork/GitHub-Automation.git`
- Download and install [Visual Studio](https://visualstudio.microsoft.com/downloads/).

## Configuration

The project's configuration is managed through the `AutomationSettings.RunSetting` file, <br>
which can be found inside the `infra` project.

### Parameters

The configuration file includes the following parameters:

- **Browser**
  - Allowed Values: [`"Chrome", "Firefox", "GridChrome", "GridFirefox"`].
  - Default value = `"Chrome"`
  - Description: Specifies the desired browser for the automation.
- **SiteUrl**
  - Value: [`"https://github.com"`].
  - Description: The URL for your site. For this project, it is set to GitHub's site.
- **GridUrl**
  - Value: [`"http://<remote_server_ip>:<port>/wd/hub"`].
  - Description: The URL of your Selenium Grid.
- **Logger**
  - Allowed Values: [`"LocalFile", "ExtentReports"`].
  - Default value = `"ExtentReports"`
  - Description: The logger you want to use. Supported loggers are `LocalFile` and `ExtentReports`.
- **width**
  - Allowed Values: [`int >= 0`].
  - Default value = `0`
  - Description: The width of the browser window. <br>
    Specify `0` or leave it unspecified for maximum size width.
- **height**
  - Allowed Values: [`int >= 0`].
  - Default value = `0`
  - Description: The height of the browser window. <br>
    Specify `0` or leave it unspecified for maximum size height.

## Test execution

- To execute the tests, use the following commands via the [dotnet CLI](https://docs.microsoft.com/en-us/dotnet/core/tools/):

```
cd GitHubAutomation

# run all tests
dotnet test

# run tests by categories
dotnet test --filter "Category=<Category_name>"
```

For more information about the `dotnet test` command and the `--filter` option, <br>
refer to the [dotnet CLI documentation](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test#filter-option-details).

## Additional Resources

- [Selenium WebDriver Documentation](https://www.selenium.dev/documentation/en/)
- [NUnit Documentation](https://docs.nunit.org/)
- [Page Object Model Pattern](https://www.selenium.dev/documentation/en/guidelines_and_recommendations/page_object_models/)
- [Extent Reports Documentation](https://extentreports.com/docs/)

Feel free to explore the provided resources to learn more about the technologies and patterns used in this project.
