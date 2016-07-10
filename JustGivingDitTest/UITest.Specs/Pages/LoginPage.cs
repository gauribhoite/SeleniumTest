using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITest.Specs.Pages
{
    class LoginPage
    {
        IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        [FindsBy(How = How.Id, Using = "Identity_EmailAddress")]
        public IWebElement email_address;

        [FindsBy(How = How.XPath, Using = "//*[@id='email-content']/div[2]/div/a[2]/span")]
        public IWebElement awesome_continue_button;

        [FindsBy(How = How.ClassName, Using = "mimic-label")]
        public IWebElement create_account_text;

        [FindsBy(How = How.Id, Using = "Authentication_Password")]
        public IWebElement password;

        [FindsBy(How = How.XPath, Using = "//*[@id='email-content']/div[1]/label")]
        public IWebElement your_email_address_text;

        [FindsBy(How = How.ClassName, Using = "donation")]
        public IWebElement donation;
    }
}
