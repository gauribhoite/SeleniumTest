using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UITest.Specs.Pages
{
    class HomePage
    {
        IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        [FindsBy(How =How.CssSelector, Using = "div.discovery-cards-header")]
        public IWebElement header;

        [FindsByAll]
        [FindsBy(How = How.CssSelector, Using = "div.discovery-card-container")]
        public IList<IWebElement> cards;

        [FindsByAll]
        [FindsBy(How = How.ClassName, Using = "user-ask-details")]
        public IList<IWebElement> UserDetail;

        [FindsBy(How = How.XPath, Using = "//*[@id='container']/div/button[2]")]
        public IWebElement NoThanks;

        [FindsBy(How = How.ClassName, Using = "dna-button")]
        public IWebElement Donate_button;

        [FindsByAll]
        [FindsBy(How = How.ClassName, Using = "ui-radio")]
        public IList<IWebElement> amountOfDonation;

        [FindsBy(How = How.ClassName, Using = "currency-and-amount")]
        public IWebElement currency_and_amount;

        [FindsBy(How = How.XPath, Using = "//a[contains(@class,'awesome-continue-button')]/span")]
        public IWebElement awesome_continue_button;


    }
}
