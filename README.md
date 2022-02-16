# GitHub-Automation

 ## Summary:
C# Automation project for GitHub.com:
tests basic new-user operations
such as - creating repository, creating project, and so on.

## Modes of operation
* Local (Visual Studio)
* Web
* Filter by categories
* Parallel execution
* retry on test failure

## Main technologies
This project leverage the following main technologies:
* C#/.Net Core 3.1
* NUnit 3
* Selenium WebDriver

## Configuration
The different modes of operation are controlled via [Nunit Test Parameters](https://docs.nunit.org/articles/nunit/writing-tests/TestContext.html#testparameters)

When running from Visual Studio, the most common way to configure these parameters are through a [.runsettings file](https://docs.microsoft.com/en-us/visualstudio/test/configure-unit-tests-by-using-a-dot-runsettings-file?view=vs-2019). For most of what you'll need, you can use *Local.RunSettings*. In order to use it, select from the top menu in Visual Studio: **Test->Configure Run Settings->Select Solution Wide runsettigns File** and browser for the *Local.Runsettings* file in the root folder of the solution, as described [here](https://docs.microsoft.com/en-us/visualstudio/test/configure-unit-tests-by-using-a-dot-runsettings-file?view=vs-2019#manually-select-the-run-settings-file).

### Parameters

* **local**
  * Values: [`true`, `false`]. Default = `true`
  * Description: true to create a local log, and false to avoid the local log.
* **retries**
  * Values: [String that contains a whole number starts from 1]. Default = `1`
  * Description: The times to retry test case on failure only.
