using TeaShoppe.Inventory;

namespace TeaShoppe.Decorators;

// Decorator class to search repository by tea name.
public class TeaByName: InventoryQuery {
    private readonly string _name;
    
    public TeaByName(IRepository inner, string name): base (inner)
    {
        _name = name;    
    }

    public override IReadOnlyList<RepositoryItem> GetInventory()
    {
        return inner.GetInventory().Where(x => x.Name.Equals(_name, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}