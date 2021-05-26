using migros.Context;
using migros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace migros
{
    class Program
    {
        static void Main(string[] args)
        {
            //Anakategori kategori = new Anakategori();
            //Altkategori altkategori = new Altkategori();
            //kategoridenproductadrescekme kategoridenproductadrescekme = new kategoridenproductadrescekme();

            ////try
            ////{
            ////    using (var contex = new ProductContext())
            ////    {
            ////        List<Category> GetAllKategoriAddresses2 = contex.Categories.Where(s => s.State == true).ToList();
            ////        foreach (var item in GetAllKategoriAddresses2)
            ////        {

            ////            kategoridenproductadrescekme.katpro(item.Address);
            ////            item.State = false;
            ////            contex.SaveChanges();

            ////        }
            ////    }
            ////}
            ////catch (Exception ex)
            ////{

            ////    throw ex;
            ////}

            ////********************product

            //urun urun = new urun();

            //try
            //{
            //    using (var contex = new ProductContext())
            //    {
            //        List<ProductAddress> products = contex.ProductAddresses.Where(s => s.State == true).ToList();
            //        foreach (var item in products)
            //        {

            //            urun.pro(item.Path);
            //            item.State = false;
            //            contex.SaveChanges();

            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
            var context = new ProductContext();
            var categories = context.Categories.Where(w => w.Name == null).ToList();
            nullkategori nullkategori = new nullkategori();
            foreach (var item in categories)
            {
                nullkategori.kategori_kaydet(item.Address);
            }
            
            
        }
    }
}