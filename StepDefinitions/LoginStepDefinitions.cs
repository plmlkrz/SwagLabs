using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Linq;


namespace SwagLabsTest.StepDefinitions
{
    [Binding]
    public class SwagLabsLoginSteps : IDisposable
    {
        //Setting up Chrome
        private ChromeDriver chromeDriver;

        public SwagLabsLoginSteps() => chromeDriver = new ChromeDriver();

           

        [Given(@"I am on the Sauce Demo Login Page")]
        public void GivenIAmOnTheSauceDemoLoginPage()
        {
            chromeDriver.Navigate().GoToUrl("https://www.saucedemo.com/");
            //Verifying that we are on the correct page before continuing
            Assert.IsTrue(chromeDriver.FindElement(By.ClassName("login_logo")).Displayed);
        }


        [When(@"I fill out ""([^""]*)"" into the Username field and the ""([^""]*)"" field")]
        public void WhenIFillOutIntoTheUsernameFieldAndTheField(string p0, string p1)
        {
            //Finding the element for Username and Password
            var UsernameInputBox = chromeDriver.FindElement(By.Id("user-name"));
            var PasswordInputBox = chromeDriver.FindElement(By.Id("password"));
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(2));
            
            //Sending the Username and Password to the page
            UsernameInputBox.SendKeys(p0);
            PasswordInputBox.SendKeys(p1);
        }


        [When(@"I click the Login Button")]
        public void WhenIClickTheLoginButton()
        {
            var LoginButton = chromeDriver.FindElement(By.Id("login-button"));
            //Clicking the Login button on the page
            LoginButton.Click();
        }

        [Then(@"I am redirected to the Sauce Demo Main Page")]
        public void ThenIAmRedirectedToTheSauceDemoMainPage()
        {
            //Waiting for the page to load
            System.Threading.Thread.Sleep(100);
            //Verifying the shopping cart Icon is present and we are on the purchase page
            Assert.IsTrue(chromeDriver.FindElement(By.Id("shopping_cart_container")).Displayed);


        }

        [Then(@"I verify the App Logo exists")]
        public void ThenIVerifyTheAppLogoExists()
        {
            //Verifying the App Logo is displayed on the page
            Assert.IsTrue(chromeDriver.FindElement(By.ClassName("app_logo")).Displayed);
        }

        [Then(@"I verify the Error Message contains the text ""([^""]*)""")]
        public void ThenIVerifyTheErrorMessageContainsTheText(string message)
        {
            try
            {
                Assert.IsTrue(chromeDriver.FindElement(By.XPath("//*[text() = 'Sorry, this user has been banned.']")).Displayed);
                
            }
            catch (Exception ex)
            {
                Assert.Fail("Sorry but the error message is not correct " + ex.Message);
            }


        }


        public void Dispose()
        {
            if (chromeDriver != null)
            {
                chromeDriver.Dispose();
                chromeDriver = null;
            }
        }
    }
}