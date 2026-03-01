namespace TeaShoppe.Payment;

/// <summary>
/// Interface for payment strategies implemented strategy design pattern 
/// </summary>

public interface IPaymentStrategy
{
    void Pay(decimal amount);
}