using migros.Context;
using migros.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;


namespace migros
{
    public class kategoridenproductadrescekme
    {
        public void katpro(string katurl,int i=1)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(katurl);
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Siteye Gidildi!");
            Thread.Sleep(2000);

            IReadOnlyCollection<IWebElement> prolist = driver.FindElements(By.ClassName("list"));
            IReadOnlyCollection<IWebElement> aa = driver.FindElements(By.XPath("//*[@id='product-list']/div[2]/div"));

            foreach (IWebElement kategori in aa)
            {
              
                IWebElement katname = kategori.FindElement(By.XPath("div/form/div[1]/h5"));

                string urunurl = katname.FindElement(By.TagName("A")).GetAttribute("href");

                ProductAddress productAddress = new ProductAddress();
                productAddress.State = true;
                productAddress.Path = urunurl;

                using (var context = new ProductContext())
                {
                    context.ProductAddresses.AddRange(productAddress);

                    context.SaveChanges();
                }

                Console.WriteLine(urunurl);


            }
            if (i == 1)
            {
                bool c = true;

                try
                {

                    driver.FindElement(By.CssSelector("#inner-search-pagination > li.pag-next"));

                }
                catch (Exception)
                {
                    c = false;
                }
                if (c)
                {
                    IWebElement nextPageEl = driver.FindElement(By.CssSelector("#inner-search-pagination > li.pag-next"));
                    i++;
                    string nextpage = katurl + "?sayfa=" + i;
                    driver.Close();
                    this.katpro(nextpage, i);
                }
                else
                {
                    Console.WriteLine("Kategori" + i + "sayfa");
                }
            }
            

             if (i != 1)
            {
                bool c = true;

                try
                {
                    driver.FindElement(By.CssSelector("#inner-search-pagination > li.pag-next"));
                }
                catch (Exception)
                {
                    c = false;
                }
                 
                    if (c)
                    {
                        IWebElement nextPageEl = driver.FindElement(By.CssSelector("#inner-search-pagination > li.pag-next"));
                        i++;
                        string _katUrl = katurl.IndexOf("?sayfa") == 0 ? katurl : katurl.Substring(0, katurl.IndexOf("?sayfa"));
                        string nextpage = _katUrl + "?sayfa=" + i;
                        driver.Close();
                        this.katpro(nextpage, i);

                    }
                    else
                    {
                        Console.WriteLine("Kategori" + i + "sayfa");
                   
                }
            
            }
            


        }

    }
}
