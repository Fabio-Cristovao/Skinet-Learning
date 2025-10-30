namespace Core.Entities.OrderAggregates;

public enum OrderStatus
{
    Pending,
    PaymentRecieved,
    PaymentFailed,
    PaymentMismatch 
}
