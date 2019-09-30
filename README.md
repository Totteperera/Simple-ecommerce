# Simple-ecommerce

Ecommerce selling deodorants. On this simple ecommerce you can do the following:
- Listing Products with information.
- Adding products to cart.
- Place order

# Get started

Clone Project and run iisexpress. Project is using localdb.

# Solution

### DB

Models:
- Product
- Cart
- Order
- OrderRow

```
public class Product
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public string ArticleNumber { get; set; }
    public decimal Price { get; set; }
    public byte[] Image { get; set; } 
}
```

```
public class Cart
{
    public int ID { get; set; }
    public string SessionId { get; set; }
    public decimal TotalPrice { get; set; }

    public virutal ICollection<OrderRow> OrderRows { get; set; }
}
```

```
public class Order
{
    public int ID { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal TotalPrice { get; set; }

    public virtual ICollection<OrderRow> OrderRows { get; set; }
}
```

```
public class OrderRow
{
    public int ID { get; set; }
    public int? OrderID { get; set; }
    public int ProductID { get; set; }
    public int? CartID { get; set; }
    public int Quantity { get; set; }

    public virtual Order Order { get; set; }
    public virtual Product Product { get; set; }
    public virtual Cart Cart { get; set; }
}
```


# Improvements
- Include IoC container
- Use automapper
- No time spent on shapes and colors
- Create better error handling.

