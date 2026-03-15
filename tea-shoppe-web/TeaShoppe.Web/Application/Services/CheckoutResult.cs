using TeaShoppe.Web.Domain.Orders;

namespace TeaShoppe.Web.Application.Services;

/// <summary>
/// Class to return the filtered inventory list and applied filters derived from InventoryQueryService. 
/// </summary>
public class CheckoutResult
{
    private bool _success { get; set; }
    private Order _order { get; set; }
    private static int _next = 100;
    public string Message { get; set; }

    public CheckoutResult()
    {
    }
    public static CheckoutResult Fail(string message)
    {
        return new CheckoutResult
        {
            _success = false,
            Message = message
        };
    }

    public static CheckoutResult Success(Order order, decimal total)
    {
        string details = order.OrderDetails();
        int receiptNumber = _next++;
        return new CheckoutResult
        {
            _success = true,
            _order = order,
            Message = $"""
                       {details}

                       *** Purchase Complete ***
                       Your package is on the way.
                       Receipt Number: {receiptNumber}

                       Receipt Total ${total}

                       **Thank you for shopping at Sweet Teas**
                       """
        };
    }
}