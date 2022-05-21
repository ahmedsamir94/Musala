using System;
using OpenQA.Selenium;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Linq;

namespace MusalaFrameWork
{
    internal class CompanyPage
    {
        public BasePage pageAutomation = BasePage.getInstance();

        public IWebDriver Driver = BasePage.getCurrentDriver(BasePage.driverName);

        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private string FacebookPageURL => "https://www.facebook.com/MusalaSoft?fref=ts";

        private string FacebookActualPageURL => Driver.Url;


        public IWebElement LeadershipSection => Driver.FindElement(By.XPath("//h2[contains(text(),'Leadership')]"));
        public IWebElement FacebookButton => Driver.FindElement(By.XPath("//a[@href='https://www.facebook.com/MusalaSoft?fref=ts']"));

        
        public void VerifyLeaderShipVisibility()
        {
            Assert.IsTrue(LeadershipSection.Displayed);
            _logger.Info($"Leadership exists successfully");
        }
        public void CLickFacebook()
        {
            IJavaScriptExecutor je = Driver as IJavaScriptExecutor;
            Thread.Sleep(2000);
            je.ExecuteScript("arguments[0].click();", FacebookButton);

            Driver.SwitchTo().Window(Driver.WindowHandles.Last());

            if (FacebookPageURL == FacebookActualPageURL)
            {
                _logger.Debug("Facebook Page is Opened successfully");
            }
            else
                throw new Exception("You are Not navigated to the  right URL");

            _logger.Info($"You are Navigated to facebook page successfully");
        }
    }
}