
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using UITest.Specs.Pages;

namespace UITest.Specs
{
    [Binding]
    public class DonateSteps
    {
        public static IWebDriver driver;

        Pages.HomePage HomePage = new Pages.HomePage(driver);
        Pages.LoginPage LoginPage = new Pages.LoginPage(driver);
        Pages.PaymentPage PaymentPage = new Pages.PaymentPage(driver);

        [Given(@"I am Justgiving homepage")]
        public void GivenIAmJustgivingHomepage()
        {
            driver = new FirefoxDriver();
            driver.Url = "https://www.justgiving.com";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,400)");
            Thread.Sleep(1500);
            
        }

        [Given(@"I look for first card")]
        public void GivenILookForFirstCard()
        {
        PageFactory.InitElements(driver,HomePage);
            string innerHtml = HomePage.UserDetail[0].GetAttribute("innerHTML");
            Console.Write("innerHtml"+innerHtml);
            HomePage.cards[0].Click();
            Thread.Sleep(2000);
        }


        [Then(@"I should be on chosen card homepage displaying same user name")]
        public void ThenIShouldBeOnChosenCardHomepageDisplayingSameUserName()
        {
            Pages.HomePage HomePage = new Pages.HomePage(driver);
            PageFactory.InitElements(driver, HomePage);
            Thread.Sleep(2000);
        }

        [Given(@"I click No Thanks on pop up")]
        public void GivenIClickNoThanksOnPopUp()
        {
            PageFactory.InitElements(driver, HomePage);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            Func<IWebDriver, IWebElement> waitForElement = new Func<IWebDriver, IWebElement>((IWebDriver Web) =>
            {
                Console.WriteLine("Waiting Pop up message");
                IWebElement element = HomePage.NoThanks;
                if (element.GetAttribute("innerHTML").Contains("No thanks"))
                {
                    return element;
                }
                return null;
            });
            IWebElement targetElement = wait.Until(waitForElement);
            HomePage.NoThanks.Click();
            Console.WriteLine("Clicked on No thanks");
        }

        [When(@"I choose to donate ""(.*)"" pounds")]
        public void WhenIChooseToDonatePounds(String p0)
        {
            PageFactory.InitElements(driver, HomePage);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.Until(driver => HomePage.Donate_button.Displayed);
            if (HomePage.Donate_button.GetAttribute("innerHTML").Contains("Donate"))
            {
                HomePage.Donate_button.Click();
                Console.WriteLine("Clicked on Donate");
            }
            
            wait.Until(driver => HomePage.currency_and_amount.Displayed);
            for (int i = 1; i < HomePage.amountOfDonation.Count; i++) {
                IWebElement element= driver.FindElement(By.XPath("//*[@id='amounts']/fieldset/div/div[" + i + "]/label/span/span"));
                string amount = element.GetAttribute("innerHTML");
                Console.WriteLine("amount :" + amount);
                if (amount.Contains(p0)) {
                    element.Click();
                    Console.WriteLine("Clicked on chosen amount :" + p0);
                    break;
                }
            }

            HomePage.awesome_continue_button.Click();
        }

        [Then(@"amount displayed should be ""(.*)"" on following page")]
        public void ThenAmountDisplayedShouldBeOnFollowingPage(String p0)
        {
            PageFactory.InitElements(driver, LoginPage);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.Until(driver => LoginPage.your_email_address_text.Displayed);
            Assert.IsTrue(LoginPage.donation.GetAttribute("innerHTML").Contains(p0));
            Console.WriteLine(" DOnation amount is displayed correctly");
        }

        [When(@"I enter my email address and password ""(.*)""")]
        public void GivenIEnterMyEmailAddressAndPassword(string password)
        {
            PageFactory.InitElements(driver, LoginPage);

            //Generate random string
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            string email = finalString + "@example.com";

            //Enter email and password
            LoginPage.email_address.SendKeys(email);
            Console.WriteLine("Email entered :" + email);
            LoginPage.awesome_continue_button.Click();
        
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.Until(driver => LoginPage.create_account_text.Displayed);
            
            LoginPage.password.SendKeys(password);
            Console.WriteLine("Password entered :" + password);

            PageFactory.InitElements(driver, PaymentPage);
            PaymentPage.awesome_continue_button.Click();
            wait.Until(driver => PaymentPage.payment_method_text.Displayed);
            Assert.IsTrue(PaymentPage.payment_method_text.GetAttribute("innerHTML").Contains("Payment methods"));
            Console.Write("Text displayed on Payment methods :" + "Payment methods");
        }

        [Then(@"I enter card type ""(.*)"" card number ""(.*)"" expiry month ""(.*)"" expiry year ""(.*)"" name on card ""(.*)""")]
        public void ThenIEnterCardTypeCardNumberExpiryMonthExpiryYearNameOnCard(string card_type, string card_number, string expiry_month, string expiry_year, string name_on_card)
        {
            PageFactory.InitElements(driver, PaymentPage);
            PaymentPage.card_type.Click();
            Console.WriteLine("Clicked on card type dropdown");

            new SelectElement(PaymentPage.card_type).SelectByText(card_type);
            Thread.Sleep(150);

            PaymentPage.card_number.SendKeys(card_number);
            Console.WriteLine("Entered Card number :" + card_number);

            PaymentPage.expiry_month.Click();
            Console.WriteLine("Clicked on Expiry month to get dropdown");
            new SelectElement(PaymentPage.expiry_month).SelectByText(expiry_month);
            //Thread.Sleep(150);

            PaymentPage.expiry_year.Click();
            Console.WriteLine("Clicked on Expiry year to get dropdown");
            new SelectElement(PaymentPage.expiry_year).SelectByText(expiry_year);
            //Thread.Sleep(150);

            PaymentPage.name_on_card.SendKeys(name_on_card);
            Console.WriteLine("Entered Name on Card :" + name_on_card);

        }
 


        [Then(@"I close")]
        public void ThenIClose()
        {
            driver.Close();
        }



    }
}
