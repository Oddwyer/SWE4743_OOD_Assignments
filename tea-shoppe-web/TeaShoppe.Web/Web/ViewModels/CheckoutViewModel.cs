using TeaShoppe.Web.Domain.Orders;

namespace TeaShoppe.Web.Web.ViewModels;

/// <summary>
/// Mirroring data fields in CheckoutService (servicing backend domain logic) this model class services the
/// frontend by collecting necessary purchase and payment data to pass to the backend for completing the checkout
/// process and displaying results.
/// </summary>
public class CheckoutViewModel
{
    
        // Checkout inputs.
        public Guid SelectedItemId { get; set; } 
        public int SelectedQuantity { get; set; }
        public string PaymentType { get; set; }
        public string CardNumber { get; set; }

        // Checkout outputs.
        public bool Success { get; set; } = true;
        public Order? Order { get; set; }
        public string Message { get; set; } = "";
}