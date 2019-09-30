namespace SimpleEcommerce.DAL.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string ArticleNumber { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
    }
}
