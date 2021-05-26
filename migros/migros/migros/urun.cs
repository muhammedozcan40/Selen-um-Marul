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
    public class urun
    {
        public void pro(string proUrl)
        {
            var contex = new ProductContext();

            Product products = new Product();

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(proUrl);
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Siteye Gidildi!");
            Thread.Sleep(2000);

            bool c = true;

            try
            {

                driver.FindElement(By.ClassName("product-no-stock-alert"));

            }
            catch (Exception)
            {
                c = false;
            }
            if (!c)
            {


                //Brand kısmı

                IWebElement Brand = driver.FindElement(By.XPath("//*[@id='product-page']/div/div/div[1]/div[2]/div/span/strong"));
                IWebElement BrandName1 = Brand.FindElement(By.XPath("a"));
                string BrandString = BrandName1.GetAttribute("innerHTML");

                string BrandNameUrl = Brand.FindElement(By.TagName("A")).GetAttribute("href");

                Regex r = new Regex(@"\/www\.migros\.com\.tr\/(?<brandCode>.*)");

                string brandCode = null;
                if (r.Match(BrandNameUrl).Success)
                {
                    brandCode = r.Match(BrandNameUrl).Groups["brandCode"].Value;
                }

                Brands bulbrand = contex.Brands.FirstOrDefault(o => o.Name == BrandString);
                if (bulbrand == null)
                {
                    Brands _brand = new Brands();
                    _brand.Name = BrandString;
                    _brand.Address = BrandNameUrl;
                    _brand.Description = brandCode;
                    _brand.Source = 1;
                    _brand.State = true;

                    using (var context = new ProductContext())
                    {
                        context.Brands.Add(_brand);

                        context.SaveChanges();
                    }
                    products.BrandID = _brand.ID;

                }
                else
                {
                    products.BrandID = bulbrand.ID;
                }


                //Unit kısmı

                IWebElement UnitA2 = driver.FindElement(By.ClassName("select-radio"));
                string UnitString = UnitA2.GetAttribute("data-selected-unit-label");

                if (UnitString == "Kg")
                {
                    products.UnitID = 8;
                }
                else if (UnitString == "Adet")
                {
                    products.UnitID = 5;
                }

                //name

                IWebElement Name = driver.FindElement(By.XPath("//*[@id='product-page']/div/div/div[1]/div[2]/div/h1"));
                string NameString = Name.GetAttribute("innerHTML");
                NameString = NameString.Trim();
                products.Name = NameString;

                //Desciription

                bool cDesciription = true;

                try
                {

                    driver.FindElement(By.XPath("//*[@id='product-page']/div/div/div[3]/div[2]/div[2]/div"));

                }
                catch (Exception)
                {
                    cDesciription = false;
                }
                if (cDesciription)
                {


                    IWebElement Desciription = driver.FindElement(By.XPath("//*[@id='product-page']/div/div/div[3]/div[2]/div[2]/div"));
                    string des = Desciription.Text;
                    products.Description = des;
                }
                //state
                products.State = true;

                //CategoryID


                IWebElement kategoribul = driver.FindElement(By.XPath("//*[@id='product-page']/div/ul/li[3]"));
                string katURLbul = kategoribul.FindElement(By.TagName("A")).GetAttribute("href");


                Category bul = contex.Categories.FirstOrDefault(o => o.Address == katURLbul);

                products.CategoryID = bul.ID;




                //Address

                products.Address = proUrl;

                //source

                products.Source = 1;

                //price

                IWebElement price = driver.FindElement(By.XPath("//*[@id='store-product-primary-price']"));

                string pricea = price.Text.Trim();
                string _priceb = pricea.IndexOf("TL") == 0 ? pricea : pricea.Substring(0, pricea.IndexOf("TL"));

                products.Price = Convert.ToDecimal(_priceb);

                //File
                IWebElement Desciription2 = driver.FindElement(By.XPath("//*[@id='carouselImage-0']"));
                string dess = Desciription2.GetAttribute("src");

                string filecode2 = null;
                Regex r2 = new Regex(@".*\/product\/(?<fileCode>.*)\/.*");

                if (r2.Match(dess).Success)
                {
                    filecode2 = r2.Match(dess).Groups["fileCode"].Value;
                }
                products.Code = filecode2;

                using (var context = new ProductContext())
                {
                    context.Products.Add(products);
                    context.SaveChanges();
                }


                File file = new File();
                file.Path = dess;
                file.State = true;
                file.RelativePath = filecode2 + ".jpg";
                file.ProductID = products.ID;
                System.Net.WebClient wc = new System.Net.WebClient();
                wc.DownloadFile(dess, String.Concat(@"C:\Users\DELL E6420\source\repos\migros\migros\Images\", filecode2, ".jpg"));

                using (var context = new ProductContext())
                {
                    context.Files.Add(file);
                    context.SaveChanges();
                }
                driver.Close();
                Console.WriteLine("Basari ile eklendi");
            }
            else
            {
                driver.Close();
                Console.WriteLine("Bu ürün stoklarımızda yoktur ya da şu an satışta değildir.");
            }
           
        }
    }
}
