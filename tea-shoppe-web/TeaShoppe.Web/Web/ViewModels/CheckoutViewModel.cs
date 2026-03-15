using TeaShoppe.Web.Domain.Orders;

namespace TeaShoppe.Web.Web.ViewModels;

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