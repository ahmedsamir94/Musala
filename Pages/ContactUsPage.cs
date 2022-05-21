using System;
using OpenQA.Selenium;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace MusalaFrameWork
{
    internal class ContactUsPage
    {
        public BasePage pageAutomation = BasePage.getInstance();

        public IWebDriver Driver = BasePage.getCurrentDriver(BasePage.driverName);

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public IWebElement EmailField => Driver.FindElement(By.Name("your-email"));
        public IWebElement NameField => Driver.FindElement(By.Name("your-name"));
        public IWebElement PhoneField => Driver.FindElement(By.Name("mobile-number"));
        public IWebElement SubjectField => Driver.FindElement(By.Name("your-subject"));
        public IWebElement MessageField => Driver.FindElement(By.Name("your-message"));
        public IWebElement SendButton => Driver.FindElement(By.ClassName("btn-cf-wrapper"));
        public IWebElement MailErrorField => Driver.FindElement(By.XPath("//span[contains(text(),'The e-mail address entered is invalid.')]"));


        public void FillContactUs(string _name, string _email, string _phone, string _subject, string _message)
        {
            Thread.Sleep(3000);
            _logger.Debug("Attempting to Fill in the contacts Form");
            pageAutomation.SendKeys(NameField, _name);
            pageAutomation.SendKeys(EmailField, _email);
            pageAutomation.SendKeys(PhoneField, _phone);
            pageAutomation.SendKeys(SubjectField, _subject);
            pageAutomation.SendKeys(MessageField, _message);
            pageAutomation.ClickButton(SendButton);

            Assert.IsTrue(MailErrorField.Displayed);
            _logger.Info($"Error (The e-mail address entered is invalid.) appeared successfully ");

        }


    }
}