using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QA_Challenge
{
    public class Scenario1
    {
        [SetUp]
        public void start()
        {
            System.SetProperty("webdriver.chrome.driver", "D:\\chromedriver.exe");
            WebDriver driver = new ChromeDriver();
        }

        [Test]
        public void scenario1()
        {
            WebDriver driver = new ChromeDriver();
            //loading the url
            driver.Navigate().GoToUrl("https://computer-database.gatling.io/computers");

            //adding a new computer -------- (1)
            driver.FindElement(By.XPath("//div[@id='actions']//a[@class='btn success']")).Click();
            driver.FindElement(By.XPath("//div[@class='input']//input[@id='name']")).SendKeys("ThinkPad");
            driver.FindElement(By.XPath("//div[@class='input']//input[@id='introduced']")).SendKeys("1992-01-01");
            SelectElement company = new SelectElement(driver.FindElement(By.XPath("//div//select[@id='company']")));
            company.SelectByText("Lenovo Group");
            driver.FindElement(By.XPath("//div[@class='actions']//input[@value='Create this computer']")).Click();
            //Message shown as "Done ! Computer ThinkPad has been created" 


            //filter by name --------------- (2)
            driver.FindElement(By.XPath("//div[@id='actions']//input[@id='searchbox']")).SendKeys("ThinkPad");
            driver.FindElement(By.XPath("//div[@id='actions']//a[@class='searchsubmit']")).Click();
            //Message shown as "25 computers found"

            //editing computer ------------- (3)
            driver.FindElement(By.XPath("//tbody//tr//td//a[contains(text(),'ThinkPad')]")).Click();
            driver.FindElement(By.XPath("//div[@class='input']//input[@id='introduced']")).SendKeys("1993-01-01");
            driver.FindElement(By.XPath("//div[@class='actions']//input[@value='Create this computer']")).Click();
            //Message shown as "Done ! Computer ThinkPad has been updated"
        }

        [TearDown]
        public void close()
        {
            driver.Quit();
            Console.WriteLine("Scenario1 passed!");
        }

    }
}