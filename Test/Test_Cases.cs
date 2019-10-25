using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
/*
       1.  http://www.n11.com<http://www.n11.com/> sitesine gelecek ve anasayfanin acildigini onaylayacak        
       2.  Login ekranini acip, bir kullanici ile login olacak ( daha once siteye uyeliginiz varsa o olabilir )
       3.  Hatalı şifre girişi ve hatalı girişi onayla       
       4.  Ekranin ustundeki Search alanina 'samsung' yazip Ara butonuna tiklayacak 
       5.  Gelen sayfada samsung icin sonuc bulundugunu onaylayacak         6.  Arama sonuclarindan 2. sayfaya tiklayacak ve acilan sayfada 2. sayfanin su an gosterimde oldugunu onaylayacak
       7.  Ustten 3. urunun icindeki 'favorilere ekle' butonuna tiklayacak 
       8.  Ekranin en ustundeki 'favorilerim' linkine tiklayacak 
       9.  Acilan sayfada bir onceki sayfada izlemeye alinmis urunun bulundugunu onaylayacak
       10. Favorilere alinan bu urunun yanindaki 'Kaldir' butonuna basarak, favorilerimden cikaracak
       11. Sayfada bu urunun artik favorilere alinmadigini onaylayacak. 
       12. Samsung ara 1. ürünü sepete ekle
       13. Sepete git eklenen ürünü sil ve onayla
*/
namespace n11_TestProject
{
    [TestClass]
    public class Test_Cases:BaseClass
    {
        [TestMethod]
        public void TestCase1()
        {
            try
            {
                Start_n11HomePage();
                Assert.IsTrue(n11_Url == "https://www.n11.com/");
                TearDown();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "Test Failed!");
                TearDown();
                throw;
            }        
        }
        [TestMethod]
        public void TestCase2()
        {
            try
            {
                Start_n11HomePage();
                FindElementByClassClick("btnSignIn");
                FindElementByIdSendKeys("email", email);
                FindElementByIdSendKeys("password", password);
                FindElementByIdClick("loginButton");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                TearDown();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "Test Failed!");
                TearDown();
                throw;
            }          
        }
        [TestMethod]
        public void TestCase3()
        {
            Start_n11HomePage();
            FindElementByClassClick("btnSignIn");
            FindElementByIdSendKeys("email", "testautomation9696@gmail.com");
            FindElementByIdSendKeys("password", "123456");
            FindElementByIdClick("loginButton");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id='loginForm']/div[2]/div[2]/div")).Text, "E-posta adresiniz veya şifreniz hatalı");
            Console.WriteLine("E-posta adresiniz veya şifreniz hatalı");
            TearDown();
        }
        [TestMethod]
        public void TestCase4()
        {
            try
            {
                Start_n11HomePage();
                FindElementByClassClick("btnSignIn");
                FindElementByIdSendKeys("email", email);
                FindElementByIdSendKeys("password", password);
                FindElementByIdClick("loginButton");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                FindElementByIdSendKeys("searchData","samsung");
                FindElementByClassClick("searchBtn");
                TearDown();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "Test Failed!");
                TearDown();
                throw;
            }
        }
        [TestMethod]
        public void TestCase5()
        {
            try
            {
                Start_n11HomePage();
                FindElementByClassClick("btnSignIn");
                FindElementByIdSendKeys("email", email);
                FindElementByIdSendKeys("password", password);
                FindElementByIdClick("loginButton");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                FindElementByIdSendKeys("searchData", "samsung");
                FindElementByClassClick("searchBtn");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                IWebElement result = driver.FindElement(By.ClassName("resultText"));
                Assert.IsTrue(result.Text.Contains("Samsung"));
                Assert.IsTrue(result.Text.Contains("sonuç bulundu."));
                TearDown();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "Test Failed!");
                TearDown();
                throw;
            }
        }
        [TestMethod]
        public void TestCase6()
        {
            try
            {
                Start_n11HomePage();
                FindElementByClassClick("btnSignIn");
                FindElementByIdSendKeys("email", email);
                FindElementByIdSendKeys("password", password);
                FindElementByIdClick("loginButton");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                FindElementByIdSendKeys("searchData", "samsung");
                FindElementByClassClick("searchBtn");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                //FindElementByXpathClick(second_page);    
                driver.Url = "https://www.n11.com/arama?q=samsung&pg=2";
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                IWebElement currentPage = driver.FindElement(By.Id("currentPage"));
                string Sayfa = currentPage.GetAttribute("value").ToString();
                Assert.IsTrue(Sayfa.Equals("2"), "2. sayfaya ulaşılamadı!");
                Console.WriteLine("2. sayfaya ulaşıldı!");
                TearDown();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "Test Failed!");
                TearDown();
                throw;
            }
        }
        IWebElement List_3rdItem;
        [TestMethod]
        public void TestCase7()
        {
            try
            {
                Start_n11HomePage();
                FindElementByClassClick("btnSignIn");
                FindElementByIdSendKeys("email", email);
                FindElementByIdSendKeys("password", password);
                FindElementByIdClick("loginButton");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                FindElementByIdSendKeys("searchData", "samsung");
                FindElementByClassClick("searchBtn");
                driver.Url = "https://www.n11.com/arama?q=samsung&pg=2";
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                List_3rdItem = driver.FindElement(By.XPath(third_productItem));
                List_3rdItem.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                Console.WriteLine("Favoriye Eklendi!");
                TearDown();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "Test Failed!");
                TearDown();
                throw;
            }
        }
        [TestMethod]
        public void TestCase8()
        {
            try
            {
                Start_n11HomePage();
                FindElementByClassClick("btnSignIn");
                FindElementByIdSendKeys("email", email);
                FindElementByIdSendKeys("password", password);
                FindElementByIdClick("loginButton");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                FindElementByClassClick("myAccount");
                FindElementByXpathClick(menu_favorite);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                TearDown();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "Test Failed!");
                TearDown();
                throw;
            }
        }
        [TestMethod]
        public void TestCase9()
        {
            try
            {
                Start_n11HomePage();
                FindElementByClassClick("btnSignIn");
                FindElementByIdSendKeys("email", email);
                FindElementByIdSendKeys("password", password);
                FindElementByIdClick("loginButton");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                FindElementByClassClick("myAccount");
                FindElementByXpathClick(menu_favorite);
                IWebElement favorite = driver.FindElement(By.ClassName("listItemWrap"));
                Assert.IsTrue(favorite.Text.Contains("Favorilerim (1)"));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                TearDown();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "Test Failed!");
                TearDown();
                throw;
            }
        }
        [TestMethod]
        public void TestCase10()
        {
            try
            {
                Start_n11HomePage();
                FindElementByClassClick("btnSignIn");
                FindElementByIdSendKeys("email", email);
                FindElementByIdSendKeys("password", password);
                FindElementByIdClick("loginButton");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                FindElementByClassClick("myAccount");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                FindElementByXpathClick(menu_favorite);
                FindElementByXpathClick(my_favorite);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                string delete_FavoriteProduct = ".wishProBtns span.deleteProFromFavorites";
                IWebElement delete = driver.FindElement(By.CssSelector(delete_FavoriteProduct));
                delete.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
                FindElementByClassClick("btnHolder");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                TearDown();  
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "Test Failed!");
                TearDown();
                throw;
            }
        }
        [TestMethod]
        public void TestCase11()
        {
            try
            {
                Start_n11HomePage();
                FindElementByClassClick("btnSignIn");
                FindElementByIdSendKeys("email", email);
                FindElementByIdSendKeys("password", password);
                FindElementByIdClick("loginButton");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                FindElementByClassClick("myAccount");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                FindElementByXpathClick(menu_favorite);
                FindElementByXpathClick(my_favorite);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                string deleted_FavoriteProduct = "#watchList .emptyWatchList";
                IWebElement deleted = driver.FindElement(By.CssSelector(deleted_FavoriteProduct));               
                string emptyList = "İzlediğiniz bir ürün bulunmamaktadır.";
                Assert.IsTrue(deleted.Text.Contains(emptyList));
                Console.WriteLine(emptyList);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                TearDown();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "Test Failed!");
                TearDown();
                throw;
            }
        }

        [TestMethod]
        public void TestCase12()
        {
            try
            {
                Start_n11HomePage();
                FindElementByClassClick("btnSignIn");
                FindElementByIdSendKeys("email", email);
                FindElementByIdSendKeys("password", password);
                FindElementByIdClick("loginButton");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                FindElementByIdSendKeys("searchData", "samsung");
                FindElementByClassClick("searchBtn");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                FindElementByXpathClick("//*[@id='view']/ul/li/div/div[1]/a");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                SelectElement select = new SelectElement(driver.FindElement(By.Id("726242504")));
                select.SelectByIndex(1);
                SelectElement select2 = new SelectElement(driver.FindElement(By.Id("726242503")));
                select2.SelectByIndex(1);
                FindElementByXpathClick("//*[@id='contentProDetail']/div/div[3]/div[2]/div[3]/div[3]/a[2]");
                Console.WriteLine("Ürününüz sepete eklendi!");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                TearDown();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "Test Failed!");
                TearDown();
                throw;
            }
        }
        [TestMethod]
        public void TestCase13()
        {
            try
            {
                Start_n11HomePage();
                FindElementByClassClick("btnSignIn");
                FindElementByIdSendKeys("email", email);
                FindElementByIdSendKeys("password", password);
                FindElementByIdClick("loginButton");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                FindElementByXpathClick("//*[@id='header']/div/div/div[2]/div[2]/div[4]/a");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                FindElementByXpathClick("//*[@id='newCheckout']/div/div[1]/div[2]/div[1]/section[2]/table[2]/tbody/tr/td[1]/div[3]/div[2]/span[@class='removeProd svgIcon svgIcon_trash']");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='wrapper']/div[2]/div/div[1]/div[1]/h2[@class='title']")).Text.Contains("Sepetiniz Boş"));
                Console.WriteLine("Sepetiniz Boş!");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                TearDown();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "Test Failed!");
                TearDown();
                throw;
            }
        }  
    }
}
