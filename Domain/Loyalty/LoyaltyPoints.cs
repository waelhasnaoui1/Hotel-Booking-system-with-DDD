namespace Domain.Loyalty;

public class LoyaltyPoints
{
    public Guid LoyaltyPointsId { get; private set; }
    public Guid CustomerId { get; private set; }
    public int Points { get; private set; }

    public LoyaltyPoints(Guid loyaltyPointsId, Guid customerId)
    {
        LoyaltyPointsId = loyaltyPointsId;
        CustomerId = customerId;
        Points = 0;
    }

    public void AddPoints(int points)
    {
        Points += points;
    }

    public void RedeemPoints(int points)
    {
        Points -= points;
    }
}