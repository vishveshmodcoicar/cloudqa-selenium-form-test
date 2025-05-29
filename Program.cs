// Description: This C# code automates filling out a form on the CloudQA practice page using Selenium WebDriver.
//Author: Vishvesh Paresh Modcoicar
// Date: 2025-05-29

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

class CloudQATest
{
    static void Main()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");

        IWebDriver driver = new ChromeDriver(options);
        driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

        try
        {
            // 1First Name Field
            var firstNameXPath = "//input[@placeholder='First Name']";
            IWebElement firstName = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(firstNameXPath)));
            firstName.SendKeys("Vishvesh");

            // Gender Radio Button - Male
            var genderXPath = "//label[text()='Male']/preceding-sibling::input";
            IWebElement maleRadio = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(genderXPath)));
            if (!maleRadio.Selected)
                maleRadio.Click();

            // Checkbox - Terms & Conditions
            var checkboxXPath = "//input[@type='checkbox' and following-sibling::text()[contains(., 'terms')]]";
            IWebElement agreeCheckbox = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(checkboxXPath)));
            if (!agreeCheckbox.Selected)
                agreeCheckbox.Click();

            // Submit Button
            var submitXPath = "//button[contains(text(),'Submit')]";
            IWebElement submitButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(submitXPath)));
            submitButton.Click();

            Console.WriteLine("Form filled and submitted successfully.");
        }
        catch (WebDriverTimeoutException ex)
        {
            Console.WriteLine("Timeout while waiting for an element: " + ex.Message);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine("Element not found: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
        finally
        {
            System.Threading.Thread.Sleep(3000); 
            driver.Quit();
        }
    }
}
