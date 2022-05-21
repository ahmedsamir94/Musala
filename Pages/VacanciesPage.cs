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
    internal class VacanciesPage
    {
        static void Main(string[] args)
        { }
        public BasePage pageAutomation = BasePage.getInstance();

        public IWebDriver Driver = BasePage.getCurrentDriver(BasePage.driverName);

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public IWebElement SelectSofiaButton => Driver.FindElement(By.XPath("//select[@id='get_location']/option[@value='Sofia']"));
        public IWebElement SelectSkopjeButton => Driver.FindElement(By.XPath("//select[@id='get_location']/option[@value='Skopje']"));


        public void SelectSofiaLocation()
        {
            pageAutomation.ClickButton(SelectSofiaButton);
            Console.WriteLine("Sofia");
            Console.WriteLine(" ");
            _logger.Info($"Sofia Location Selected successfully");

        }

        public void SelectSkopjeLocation()
        {
            pageAutomation.ClickButton(SelectSkopjeButton);
            Console.WriteLine("Skopje");
            Console.WriteLine(" ");
            _logger.Info($"Skopje Location Selected successfully");


        }

        public void PrintVacancies()
        {

            var parent = Driver.FindElements(By.XPath(".//*[@class='card-container']"));

            foreach (var item in parent)
            {
                var title = item.FindElement(By.XPath(".//*[@class='card-jobsHot__title']")).Text;
                var url = item.FindElement(By.ClassName("card-jobsHot__link"));
                
                Console.WriteLine("Position : {0} ",title);
                Console.WriteLine("More info : {0}" ,url.GetProperty("href"));
                Console.WriteLine(" ");


            }
            _logger.Info($"Vacancies printed successfully");

        }



    }
}