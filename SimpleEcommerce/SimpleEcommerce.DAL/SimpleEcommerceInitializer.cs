using SimpleEcommerce.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;

namespace SimpleEcommerce.DAL
{
    public class SimpleEcommerceInitializer : DropCreateDatabaseIfModelChanges<SimpleEcommerceContext>
    {

        private const string _imageFolderLocation = @"/Content/Images/";
        private const string _fileExtention = ".png";

        protected override void Seed(SimpleEcommerceContext context)
        {
            var products = new List<Product>
            {
                new Product
                {
                    ArticleNumber = "0011",
                    Name = "Boss The Scent",
                    Brand = "Hugo Boss",
                    Price = 275,
                    Image = GetImage("0011")
                },
                new Product
                {
                    ArticleNumber = "0022",
                    Name = "Boss Bottled",
                    Brand = "Hugo Boss",
                    Price = 265,
                    Image = GetImage("0022")
                },
                new Product
                {
                    ArticleNumber = "0033",
                    Name = "CK Be",
                    Brand = "Calvin Klein",
                    Price = 310,
                    Image = GetImage("0033")
                },
                new Product
                {
                    ArticleNumber = "0044",
                    Name = "Code for Men",
                    Brand = "Armani",
                    Price = 230,
                    Image = GetImage("0044")
                },
                new Product
                {
                    ArticleNumber = "0055",
                    Name = "Eternity for Men",
                    Brand = "Calvin Klein",
                    Price = 295,
                    Image = GetImage("0055")
                },
                new Product
                {
                    ArticleNumber = "0066",
                    Name = "Euphoria Men",
                    Brand = "Calvin Klein",
                    Price = 195,
                    Image = GetImage("0066")
                },
            };
            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();
        }

        private byte[] GetImage(string fileName)
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            return File.ReadAllBytes(baseDirectory + _imageFolderLocation + fileName + _fileExtention);
        }
    }
}
