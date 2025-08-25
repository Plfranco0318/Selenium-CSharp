# Selenium C# Automation Project

## Overview 
This is a simple automation testing project built with **Selenium WebDriver (C#)**, integrated with:
- **ExtentReports** for Reporting
- **Data-Driven Testing** (CSV/Excel)
- **Accessibility Testing** using **Axe for .NET**


## Tech Stack
- **C# .NET**
- **Selenium WebDriver**
- **NUnit / MSTest**
- **ExtentReports**
- **Data-Driven Testing**
- **Axe Accessibility Testing**

## Project Structure

ProjectRoot
- Data/ # Test data for data-driven tests
- Helpers/ # Utility classes (Reports)
- Pages/ # Page Object Models (POM)
- drivers/ # Browser drivers
- AxeTest_chrome.cs # Accessibility tests
- BookingTest_chrome.cs # Booking-related tests
- GolfTest_chrome.cs # Golf module tests
- LoginTest.cs # Login tests
- TestProject.csproj # Project configuration file
- .runsettings # Test run configuration
- README.md


## How to use:
1. Clone the repository.
2. Restore dependencies:

     ```bash
   dotnet restore
3. Run Tests:

     ```bash
   dotnet test
4. Open the HTML Report inside the Reports Folder.

