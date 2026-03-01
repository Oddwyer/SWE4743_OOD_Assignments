using TeaShoppe.Inventory;

namespace tea_shoppe.Decorators;

public class TeaByName: InventoryQuery {
    private readonly string _name;
    
    public TeaByName(IRepository inner, string name): base (inner)
    {
        _name = name;    
    }

    public override IReadOnlyList<RepositoryItem> GetInventory()
    {
        return inner.GetInventory().Where(x => x.Name == _name).ToList();
    }
}