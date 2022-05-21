using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Net;
using System.Net.Mail;
//using AutoItX3Lib;
using System.Threading;
using System.Configuration;
using Microsoft.Office.Interop.Excel;
using Docker.DotNet.Models;
using System;

namespace MusalaFrameWork
{
    internal class HomePage
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public IWebDriver Driver = BasePage.getCurrentDriver(BasePage.driverName);
        public BasePage pageAutomation = BasePage.getInstance();
        private string HomePageURL => "https://www.musala.com/";
        private string CompanyPageURL => "https://www.musala.com/company/";
        private string CareersPageURL => "https://www.musala.com/careers/";
        private string HomePageActualURL => Driver.Url;
        private string CompanyPageActualURL => Driver.Url;
        private string CareersPageActualURL => Driver.Url;
        public IWebElement ContactUsButton => Driver.FindElement(By.XPath("//*[@data-alt='Contact us']"));
        public IWebElement CompanyButton => Driver.FindElement(By.XPath("//ul[@id='menu-main-nav-1']/li[@class='menu-item menu-item-type-post_type menu-item-object-page menu-item-887']/a[@href='https://www.musala.com/company/']"));
        public IWebElement CareersButton => Driver.FindElement(By.XPath("//ul[@id='menu-main-nav-1']/li[@class='menu-item menu-item-type-post_type menu-item-object-page menu-item-478']/a[@href='https://www.musala.com/careers/']"));
        public IWebElement ComposeButton => Driver.FindElement(By.XPath("//div[contains(text(),'Compose')]"));                                                              
        public IWebElement RecipientsField => Driver.FindElement(By.XPath("//textarea[contains(@class,'vO') and contains(@role,'combobox')]"));
        public IWebElement BodyField => Driver.FindElement(By.XPath("//div[@aria-label='Message Body']"));
        public IWebElement SendMailField => Driver.FindElement(By.XPath("//div[@aria-label='Send ‪(Ctrl-Enter)‬']"));
        public IWebElement AttachedField => Driver.FindElement(By.XPath("//div[@aria-label='Attach files']"));

        internal void GoTo()
        {
            _logger.Debug("Attempting to Reach the URL");
            Driver.Url = ConfigurationManager.AppSettings["URL"];
            if (HomePageURL == HomePageActualURL)
            {
                _logger.Info($"Open URL =>{Driver.Url}");
                Driver.Manage().Window.Maximize();
            }
            else
                throw new Exception("You are Not navigated to the  right URL");
                

        }
        internal void ClickContactUs()
        {
            _logger.Debug("Attempting to open the contact us Form");
            IJavaScriptExecutor je = Driver as IJavaScriptExecutor;
            Thread.Sleep(2000);
            je.ExecuteScript("window.scrollBy(0,950);");
            
            pageAutomation.ClickButton(ContactUsButton);
            _logger.Debug("Contact us Form Opened successfully");

        }
        internal void ClickCompany()
        {
            _logger.Debug("Attempting to open the Company Tab");
            IJavaScriptExecutor je = Driver as IJavaScriptExecutor;
            Thread.Sleep(2000);
            je.ExecuteScript("arguments[0].click();", CompanyButton);

            if (CompanyPageURL == CompanyPageActualURL)
            {
                _logger.Debug("Company Tab Opened successfully");
            }
            else
                throw new Exception("You are Not navigated to the  right URL");
        }

        internal void ClickCareers()
        {
            _logger.Debug("Attempting to open the careers Tab");
            IJavaScriptExecutor je = Driver as IJavaScriptExecutor;
            Thread.Sleep(2000);
            je.ExecuteScript("arguments[0].click();", CareersButton);

            if (CareersPageURL == CareersPageActualURL)
            {
                _logger.Debug("Company Tab Opened successfully");
            }
            else
                throw new Exception("You are Not navigated to the  right URL");
        }
        //public void SendEmail(string _To, string _Subject, string _Mbody)
        //{
        //    _logger.Debug("Attempting to send Email");
        //    pageAutomation.ClickButton(ContactUsButton);


        //    _logger.Info($"The mail Have been sent successfully ");
        //}


    }
}