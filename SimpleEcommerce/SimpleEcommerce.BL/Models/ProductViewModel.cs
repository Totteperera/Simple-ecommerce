using AutoMapper;
using SimpleEcommerce.DAL.Models;
using System;

namespace SimpleEcommerce.BL.Models
{
    public class ProductViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string ArticleNumber { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
