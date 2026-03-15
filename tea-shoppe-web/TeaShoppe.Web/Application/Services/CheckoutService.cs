using TeaShoppe.Web.Application.Interfaces;
using TeaShoppe.Web.Domain.Orders;
using TeaShoppe.Web.Application.Factories;
using TeaShoppe.Web.Domain.Inventory;
using TeaShoppe.Web.Domain.InventoryQuery;

namespace TeaShoppe.Web.Application.Services;
/*
public class CheckoutService
{
    PaymentStrategyFactory _paymentStrategyFactory;
    private IReadOnlyList<InventoryItem>  _repository;

    public CheckoutService(PaymentStrategyFactory paymentStrategyFactory, IInventory repository)
    {
        _paymentStrategyFactory = paymentStrategyFactory;
        _repository = repository.GetInventory();
    }

    private bool ValidateQuantity(QueryItem item)
    {
        selectedItem = _repository.FirstOrDefault(i => i.InventoryItemId == item.)
        if(_repository.Contains(item.OrderItemId)
    }
}*/