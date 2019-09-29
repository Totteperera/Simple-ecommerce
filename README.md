# Simple-ecommerce

Ecommerce selling deodorants. Contains, list of products, add-to-cart, and place order.

# Solution

### DB

Models:
- Product
- Cart
- Order
- OrderRow

Relations: 
- Product to OrderRow: One to many
- Order to OrderRow: One to many
- Cart to OrderRow: One to many

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
    public int OrderID { get; set; }
    public int ProductID { get; set; }
    public int CartID { get; set; }
    public int Quantity { get; set; }

    public virtual Order Order { get; set; }
    public virtual Product Product { get; set; }
    public virtual Cart Cart { get; set; }
}
```


# Improvements
- Include IoC container
- Use automapper

