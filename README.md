# GitHub-Automation

 ## Summary:
C# Automation project for GitHub.com: 
Simulates basic new-user operations such as - creating a repository, creating a project, etc.

## Main technologies
This project leverage the following main technologies:
* C#/.Net Core 3.1
* NUnit 3
* Selenium WebDriver
* POM design pattern

## Modes of operation
* Local (Visual Studio) - details in the configuration section below.
* Web (Desktop)
* Filter by categories
* Parallel execution
* retry on test failure - details in the configuration section below.

## Configuration
The different modes of operation are controlled via [Nunit Test Parameters](https://docs.nunit.org/articles/nunit/writing-tests/TestContext.html#testparameters)

When running from Visual Studio, the most common way to configure these parameters are through a [.runsettings file](https://docs.microsoft.com/en-us/visualstudio/test/configure-unit-tests-by-using-a-dot-runsettings-file?view=vs-2019). For most of what you'll need, you can use *Local.RunSettings*. In order to use it, select from the top menu in Visual Studio: **Test->Configure Run Settings->Select Solution Wide runsettigns File** and browser for the *Local.Runsettings* file in the root folder of the solution, as described [here](https://docs.microsoft.com/en-us/visualstudio/test/configure-unit-tests-by-using-a-dot-runsettings-file?view=vs-2019#manually-select-the-run-settings-file).

### Parameters

* **local**
  * Values: [`"true"`, `"false"`]. Default = `"true"`
  * Description: true to create a local log, and false to avoid the local log.
* **retries**
  * Values: [whole number starts from `"1"`]. Default = `"1"`
  * Description: The times to retry test case on failure only.

## ⚙️Setup
* Download .NET (not .NET Core)
* Open terminal and run dotnet --info to ensure installation.
* git clone https://github.com/ilorwork/GitHub-Automation.git
* Download an IDE of your choice. Probably VS for Mac, or VS Code.

## Running tests
* Run tests of GitHub.csproj using [dotnet CLI](https://docs.microsoft.com/en-us/dotnet/core/tools/)
```
cd GitHub-Automation\GitHubProjectFolder\
# run all tests
dotnet test
# run tests by categories
dotnet test --filter "Category=<Category_name>"
```
For more info about [dotnet filter command](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test#filter-option-details)
