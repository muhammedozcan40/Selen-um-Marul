using migros.Context;
using migros.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace migros
{
    public class nullkategori
    {
        public void kategori_kaydet(string nullkaturl)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(nullkaturl);
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Siteye Gidildi!");
            Thread.Sleep(2000);

            
            
            IWebElement kategories = driver.FindElement(By.XPath("/html/body/div[6]/div[4]/div/div[1]/div/div[2]/ul/li[last()-1]/a"));
            IWebElement kategories2 = driver.FindElement(By.XPath("/html/body/div[6]/div[4]/div/div[1]/div/div[2]/ul/li[last()]/strong"));

            string katURL = kategories.GetAttribute("href");

            string name = kategories2.GetAttribute("innerHTML");
            Console.WriteLine(name);

            Regex r = new Regex(@"kategori\/(?<katCode>.*?)\/.*");

            string katCode = null;
            if (r.Match(nullkaturl).Success)
            {
                katCode = r.Match(nullkaturl).Groups["katCode"].Value;
            }

            Console.WriteLine(katCode);
            var contex = new ProductContext();

            Category category = new Category();
            category.Name = name;
       
            category.Description = katCode;
            category.Address = nullkaturl;
            Category bulcategory = contex.Categories.FirstOrDefault(o => o.Description == katCode);
            category.ParentCategoryID = bulcategory.ID;

            using (var context = new ProductContext())
            {
                context.Categories.Update(category);

                context.SaveChanges();
            }
            driver.Close();

        }
    }
}
