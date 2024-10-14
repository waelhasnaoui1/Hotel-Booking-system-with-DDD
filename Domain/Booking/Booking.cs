using Domain.Common;

namespace Domain.Booking;

public class Booking
{
    public Guid BookingId { get; private set; }
    public Guid CustomerId { get; private set; }
    public BookingStatus Status { get; private set; }
    public decimal TotalPrice { get;  set; }
    private List<OrderItem> _orderItems;
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

    public Booking(Guid bookingId, Guid customerId, decimal totalPrice)
    {
        BookingId = bookingId;
        CustomerId = customerId;
        TotalPrice = totalPrice;
        _orderItems = new List<OrderItem>();
        Status = BookingStatus.Created;
    }

    public void AddOrderItem(OrderItem item)
    {
        _orderItems.Add(item);
    }

    public void CompleteBooking()
    {
        Status = BookingStatus.Completed;
        // Raise domain event
        DomainEvents.Raise(new BookingCreatedEvent(this));
    }
}