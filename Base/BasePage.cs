using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using System;
using System.Threading;
using OpenQA.Selenium.Firefox;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using System.Configuration;

namespace MusalaFrameWork
{
    public class BasePage
    {

        private static BasePage instance = null;

        private static IWebDriver driver = null;
        public TestContext testcontext;
        public static string driverName;



        public static BasePage getInstance()
        {

            if (instance == null)
            {
                instance = new BasePage();
            }
            return instance;

        }

   
        private BasePage()
        {
        }

        public static IWebDriver getCurrentDriver(string DriverName)
        {
            if ((driver == null) && (DriverName == "chrome"))
            {
                driver = new ChromeDriver(ConfigurationManager.AppSettings["DriverPath"]);
            }
            else if ((driver == null) && (DriverName == "firefox"))
            {
                driver = new FirefoxDriver();
            }

            return driver;
        }


            public void killCurrentDriver()
        {

            driver.Close();
            driver.Quit();
            driver = null;
        }

        public void SendKeys(IWebElement field, string data)
        {
            try
            {
                field.SendKeys(data);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public void ClickButton(IWebElement BTN)
        {
            try
            {
                BTN.Click();
                Thread.Sleep(10000);
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            catch (Exception)
            {

                throw;
            } 
        }


    }
}