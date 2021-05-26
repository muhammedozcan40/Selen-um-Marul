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
    public class Altkategori
    {
        
        public void altkategori_kaydet()
        {

            var contex = new ProductContext();

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.migros.com.tr/elektronik-c-a6");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Siteye Gidildi!");
            Thread.Sleep(5000);

            IReadOnlyCollection<IWebElement> kategories = driver.FindElements(By.ClassName("main-product-list"));
            IWebElement anakategories = driver.FindElement(By.XPath("//*[@id='page-area']/div/div/div[1]/div[1]/div/div[1]/div/h1"));

            List<Category> categories = new List<Category>();

            string parentcat=anakategories.GetAttribute("innerHTML");
            foreach (IWebElement kategori in kategories)
            {
                Regex r = new Regex(@"\/www\.migros\.com\.tr\/(?<katCode>.*)");

                IWebElement katname = kategori.FindElement(By.XPath("header/h2"));

                IWebElement katurl1 = kategori.FindElement(By.XPath("header"));
                string katURL = katurl1.FindElement(By.TagName("A")).GetAttribute("href");

                string katCode = null;

                string katname2 = katname.Text;


                if (r.Match(katURL).Success)
                {
                    katCode = r.Match(katURL).Groups["katCode"].Value;
                }

                Category category = new Category();
                category.Name = katname2;
                category.State = true;
                category.Address = katURL;
                category.Description = katCode;

                Category b = contex.Categories.FirstOrDefault(o => o.Name == parentcat);
                category.ParentCategoryID = b.ID;
                using (var context = new ProductContext())
                {
                    context.Categories.AddRange(category);

                    context.SaveChanges();
                }

            }

        }

    }
}
