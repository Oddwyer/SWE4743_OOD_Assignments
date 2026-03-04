using TeaShoppe.Orders;

namespace TeaShoppe.Payment;

/// <summary>
/// Interface for payment strategies implemented strategy design pattern 
/// </summary>

public interface IPaymentStrategy
{
    public bool Pay(decimal amount);
}