using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITest.Specs.Pages
{
    class PaymentPage
    {
        IWebDriver driver;
        public PaymentPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='Payment-fieldset']/h2")]
        public IWebElement payment_method_text;

        [FindsBy(How = How.XPath, Using = "//*[@id='Authentication-fieldset']/div[2]/div/a[2]/span/span/span")]
        public IWebElement awesome_continue_button;

        [FindsBy(How = How.Id, Using = "Payment_CardType")]
        public IWebElement card_type;

        [FindsBy(How = How.Id, Using = "Payment_CardNumber")]
        public IWebElement card_number;

        [FindsBy(How = How.Id, Using = "Payment_ExpiryDatePart_Month")]
        public IWebElement expiry_month;

        [FindsBy(How = How.Id, Using = "Payment_ExpiryDatePart_Year")]
        public IWebElement expiry_year;

        [FindsBy(How = How.Id, Using = "Payment_NameOnCard")]
        public IWebElement name_on_card;

    }
}
