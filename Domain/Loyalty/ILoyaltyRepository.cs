namespace Domain.Loyalty;

public interface ILoyaltyRepository
{
    LoyaltyPoints GetLoyaltyPointsByCustomerId(Guid customerId);
    void Add(LoyaltyPoints loyaltyPoints);
}