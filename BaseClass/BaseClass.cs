using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace n11_TestProject
{
    [TestFixture]
    public class BaseClass
    {

        protected const string n11_Url = "https://www.n11.com/";
        protected IWebDriver driver;
        protected const string email = "testautomation9696@gmail.com";
        protected const string password = "Test2019";
        protected const string menu_favorite = "//*[@id='myAccount']/div[1]/div[1]/div[2]/ul/li[5]/a";
        protected const string my_favorite = "//*[@id='myAccount']/div[3]/ul/li[1]/div/a";
        protected const string second_page = ".//*[@id='contentListing']/div/div/div[2]/div[4]/a[2]";
        protected const string third_productItem = ".//*[@id='view']/ul/li[3]/div/div[2]/span[@class='textImg followBtn']";

        [SetUp]
        public void Start_n11HomePage()
        {         
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(n11_Url);      
        }
        public void FindElementByIdClick(string id)
        {
            driver.FindElement(By.Id(id)).Click();
        }
        public void FindElementByIdSendKeys(string id, string input)
        {
            driver.FindElement(By.Id(id)).SendKeys(input);
        }
        public void FindElementByXpathClick(string xpath)
        {
            driver.FindElement(By.XPath(xpath)).Click();
        }
        public void FindElementByClassClick(string name)
        {
            driver.FindElement(By.ClassName(name)).Click();
        }
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
