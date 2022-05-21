using OpenQA.Selenium;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
//using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using NLog;
using System;


namespace MusalaFrameWork
{
    public class BaseTest
    {
        public static ExtentReports extent = new ExtentReports();
        public static ExtentTest test;
        public static string DriverName =ConfigurationManager.AppSettings["Browser"];


        public BasePage pageAutomation = BasePage.getInstance();
        public IWebDriver Driver = BasePage.getCurrentDriver(DriverName);
        //internal MailLogingPage mailLogin { get; private set; }
        internal ContactUsPage contactUs { get; private set; }
        internal CompanyPage company { get; private set; }
        internal CareersPage careers { get; private set; }
        internal VacanciesPage vacancy { get; private set; }
        internal HomePage Home { get; private set; }
        public TestContext TestContext { get; set; }
        public TestData tests { get; set; }

        
        
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            Reporter.ReportTestOutcome("");
            pageAutomation.killCurrentDriver();

        }

        [TestInitialize]
        public void SetupForEverySingleTestMethod()
        {
            contactUs = new ContactUsPage();
            company = new CompanyPage();
            careers = new CareersPage();
            vacancy = new VacanciesPage();
            Home = new HomePage();
            tests = new TestData();
            
        Reporter.AddTestCaseMetadataToHtmlReport(TestContext);

        }

    }
}