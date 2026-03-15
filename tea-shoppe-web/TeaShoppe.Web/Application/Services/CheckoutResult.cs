using TeaShoppe.Web.Domain.Orders;

namespace TeaShoppe.Web.Application.Services;

/// <summary>
/// Represents the result of a checkout attempt, including success/failure and confirmation details.
/// </summary>
public class CheckoutResult
{
    public bool Passed { get; private init; }
    public Order? Order { get; private init; }
    private static int _next = 100;
    public string Message { get; private init; } = string.Empty;

    public CheckoutResult()
    {
    }
    
    // Method to return error result when checkout process fails.
    public static CheckoutResult Fail(string message)
    {
        return new CheckoutResult
        {
            Passed = false,
            Message = message
        };
    }

    // Method to return success details when checkout process succeeds.
    public static CheckoutResult Success(Order order, decimal total)
    {
        string details = order.OrderDetails();
        int receiptNumber = _next++;
        decimal tax = total * 0.07m;
        decimal receiptTotal = total + tax;
        return new CheckoutResult
        {
            Passed = true,
            Order = order,
            Message = $"""
                       Your package is on the way.
                       Receipt Number: {receiptNumber}
                       {details}
                       7% Tax Applied: {tax:c} 

                       Receipt Total {receiptTotal:C}

                       Thank you for shopping at Sweet Teas!
                       """
        };
    }
}