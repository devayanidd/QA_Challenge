using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace QA_Challenge
{
    public class Scenario2
    {
        [SetUp]
        public void start()
        {
            System.SetProperty("webdriver.chrome.driver", "D:\\chromedriver.exe");
            WebDriver driver = new ChromeDriver();
        }

        [Test]
        public void scenario2()
        {
            //loading the url
            driver.Navigate().GoToUrl("https://computer-database.gatling.io/computers");

            //adding a new computer -------- (1)
            driver.FindElement(By.Id("add")).Click();
            driver.FindElement(By.Id("name")).SendKeys("ThinkPad");
            driver.FindElement(By.Id("introduced")).SendKeys("1992-01-01");
            SelectElement company = new SelectElement(driver.FindElement(By.Id("company")));
            company.SelectByValue("35");
            driver.FindElement(By.ClassName("btn primary")).Click();
            //Message shown as "Done ! Computer ThinkPad has been created"

            //filter by name --------------- (2)
            driver.FindElement(By.Id("searchbox")).SendKeys("ThinkPad");
            driver.FindElement(By.ClassName("searchsubmit")).Click();
            //Message shown as "25 computers found"

            //editing computer ------------- (3)
            driver.FindElement(By.XPath("//tbody//tr//td//a[contains(text(),'ThinkPad')]")).Click();
            driver.FindElement(By.Id("introduced")).SendKeys("1993-01-01");
            driver.FindElement(By.ClassName("btn primary")).Click();
            //Message shown as "Done ! Computer ThinkPad has been updated"
        }

        [TearDown]
        public void close()
        {
            driver.Quit();
            Console.WriteLine("Scenario2 passed!");
        }

    }
}
