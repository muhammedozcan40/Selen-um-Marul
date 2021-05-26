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
    public class Anakategori
    {
        public void kategori_kaydet()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.migros.com.tr/");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Siteye Gidildi!");
            Thread.Sleep(5000);

            IReadOnlyCollection<IWebElement> kategories = driver.FindElements(By.XPath("//*[@id='mobile-sidebar-nav']/ul/li"));

            List<Category> categories = new List<Category>();

            foreach (IWebElement kategori in kategories)
            {
                Regex r = new Regex(@"\/www\.migros\.com\.tr\/(?<katCode>.*)");

                string katCode = null;
                string katURL = kategori.FindElement(By.TagName("A")).GetAttribute("href");
                if (r.Match(katURL).Success)
                {
                    katCode = r.Match(katURL).Groups["katCode"].Value;
                }
                IWebElement kategori2 = kategori.FindElement(By.XPath("a/span"));
                string ka = kategori2.GetAttribute("innerHTML");
                Category category = new Category();
                category.Name = ka;
                category.State = true;
                category.Address = katURL;
                category.Description = katCode;
                using (var context = new ProductContext())
                {
                    context.Categories.AddRange(category);

                    context.SaveChanges();
                }
            }

        }
    }
}
