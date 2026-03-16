using TeaShoppe.Web.Application.Services;
using TeaShoppe.Web.Application.Factories;

namespace TeaShoppe.Web.Application.Interfaces;

/// <summary>
/// Interface for CheckoutService concrete class honoring Dependency Inversion Principle;
/// high-level modules (UI controllers) depend on abstractions, not concrete implementations
/// </summary>

public interface ICheckoutService
{
    // Method to accept purchase and payment details to perform checkout transaction.
    public CheckoutResult Checkout(Guid selectedItemId, int selectedQuantity, string paymentType,
        string cardNumber);
}