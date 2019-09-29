using SimpleEcommerce.BL.Models;
using SimpleEcommerce.DAL.Models;
using System;

namespace SimpleEcommerce.BL.Mappers
{
    public static class ProductMapper
    {
        public static ProductViewModel Map(this Product product)
        {
            return new ProductViewModel
            {
                ArticleNumber = product.ArticleNumber,
                Brand = product.Brand,
                ID = product.ID,
                ImageUrl = GetImageUrl(product),
                Name = product.Name,
                Price = product.Price
            };
        }

        private static string GetImageUrl(Product product)
        {
            return product.Image != null ? $"data:image/png;base64,{Convert.ToBase64String(product.Image)}" : "";
        }
    }
}
