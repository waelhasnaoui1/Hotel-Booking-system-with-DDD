namespace Domain.Booking;

public class OrderItem
{
    public Guid OrderItemId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }

    // Constructor
    public OrderItem(Guid productId, int quantity, decimal price)
    {
        OrderItemId = Guid.NewGuid();
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }

    // Method to calculate total price for this order item
    public decimal GetTotalPrice()
    {
        return Quantity * Price;
    }
}