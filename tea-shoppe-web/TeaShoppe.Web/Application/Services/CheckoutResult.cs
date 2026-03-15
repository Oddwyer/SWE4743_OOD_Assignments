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
    public static CheckoutResult Fail(string message)
    {
        return new CheckoutResult
        {
            Passed = false,
            Message = message
        };
    }

    public static CheckoutResult Success(Order order, decimal total)
    {
        string details = order.OrderDetails();
        int receiptNumber = _next++;
        return new CheckoutResult
        {
            Passed = true,
            Order = order,
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