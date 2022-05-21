using System;
using OpenQA.Selenium;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Linq;
using AutoItX3Lib;

namespace MusalaFrameWork
{
    internal class CareersPage
    {
        public BasePage pageAutomation = BasePage.getInstance();

        public IWebDriver Driver = BasePage.getCurrentDriver(BasePage.driverName);

        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private string JoinUsPageURL => "https://www.musala.com/careers/join-us/";

        private string JoinUsActualPageURL => Driver.Url;


        public IWebElement LeadershipSection => Driver.FindElement(By.XPath("//h2[contains(text(),'Leadership')]"));
        public IWebElement SelectVacancyButton => Driver.FindElement(By.XPath("//img[@alt='Java Developer']"));
        public IWebElement SelectLocationButton => Driver.FindElement(By.XPath("//select[@id='get_location']/option[@value='Bulgaria']"));
        public IWebElement OpenPositionsButton => Driver.FindElement(By.XPath("//button[@class='contact-label contact-label-code btn btn-1b']"));
        public IWebElement RequirmentsSection => Driver.FindElement(By.XPath("//h2[contains(text(),'Requirements')]"));
        public IWebElement GeneralDescriptionSection => Driver.FindElement(By.XPath("//h2[contains(text(),'General description')]"));
        public IWebElement ResponsibiltiesSection => Driver.FindElement(By.XPath("//h2[contains(text(),'Responsibilities')]"));
        public IWebElement WhatWeOfferSection => Driver.FindElement(By.XPath("//h2[contains(text(),'What we offer')]"));
        public IWebElement NameField => Driver.FindElement(By.Name("your-name"));
        public IWebElement EmailField => Driver.FindElement(By.Name("your-email"));
        public IWebElement PhoneField => Driver.FindElement(By.Name("mobile-number"));
        public IWebElement ApplyButton => Driver.FindElement(By.XPath("//input[@value='Apply']"));
        public IWebElement SendButton => Driver.FindElement(By.XPath("//input[@value='Send']"));
        public IWebElement UploadButton => Driver.FindElement(By.Id("uploadtextfield"));
        public IWebElement AgreeButton => Driver.FindElement(By.Id("adConsentChx"));
        public IWebElement CloseButton => Driver.FindElement(By.ClassName("close-form"));
        public IWebElement MailErrorField => Driver.FindElement(By.XPath("//span[contains(text(),'The e-mail address entered is invalid.')]"));




        public void VerifyLeaderShipVisibility()
        {
            Assert.IsTrue(LeadershipSection.Displayed);
            _logger.Info($"Leadership exists successfully");
        }
        public void CLickOpenPosistions()
        {
            
            pageAutomation.ClickButton(OpenPositionsButton);

            if (JoinUsPageURL == JoinUsActualPageURL)
            {
                _logger.Debug("JoinUs Page is Opened successfully");
            }
            else
                throw new Exception("You are Not navigated to the right URL");
        }
        public void SelectLocation()
        {
            pageAutomation.ClickButton(SelectLocationButton);
            _logger.Debug("Bulgaria Location selected successfully");

        }

        public void selectVacancy()
        {
            IJavaScriptExecutor je = Driver as IJavaScriptExecutor;
            Thread.Sleep(2000);
            je.ExecuteScript("arguments[0].click();", SelectVacancyButton);
            _logger.Debug("Vacancy selected successfully");


        }
        public void CheckVisibiltyOfJobSections()
        {
            Assert.IsTrue(GeneralDescriptionSection.Displayed);
            Assert.IsTrue(RequirmentsSection.Displayed);
            Assert.IsTrue(ResponsibiltiesSection.Displayed);
            Assert.IsTrue(WhatWeOfferSection.Displayed);
           _logger.Info($"Job Sections exists successfully");
        }
        public void CheckVisibiltyOfApplyButton()
        {
            Assert.IsTrue(ApplyButton.Displayed);
            _logger.Info($"Apply Button exists successfully");
        }
        public void ClickApplyButton()
        {
            IJavaScriptExecutor je = Driver as IJavaScriptExecutor;
            Thread.Sleep(2000);
            je.ExecuteScript("arguments[0].click();", ApplyButton);
            _logger.Info($"Apply Button CLicked successfully");

        }

        public void FillApplyForm(string _name, string _email, string _phone)
        {
            _logger.Debug("Attempting to Fill in the contacts Form");
            pageAutomation.SendKeys(NameField, _name);
            pageAutomation.SendKeys(EmailField, _email);
            pageAutomation.SendKeys(PhoneField, _phone);

            IJavaScriptExecutor je = Driver as IJavaScriptExecutor;
            Thread.Sleep(2000);
            je.ExecuteScript("arguments[0].click();", UploadButton);

            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            Thread.Sleep(2000);
            autoIt.Send(ConfigurationManager.AppSettings["AttachedSheet"]);
            Thread.Sleep(2000);
            autoIt.Send("{ENTER}");

            Thread.Sleep(2000);
            je.ExecuteScript("arguments[0].click();", AgreeButton);

            Thread.Sleep(2000);
            je.ExecuteScript("arguments[0].click();", SendButton);

            Thread.Sleep(3000);
            je.ExecuteScript("arguments[0].click();", CloseButton);

            Thread.Sleep(5000);
            Assert.IsTrue(MailErrorField.Displayed);
            _logger.Info($"Error (The e-mail address entered is invalid.) appeared successfully ");

        }
    }
}