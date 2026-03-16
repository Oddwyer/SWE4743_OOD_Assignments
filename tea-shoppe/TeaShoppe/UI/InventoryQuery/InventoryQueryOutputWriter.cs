namespace tea_shoppe.UI.InventoryQuery;

public class InventoryQueryOutputWriter
{
    public TextWriter Writer { get; }
    public InventoryQueryOutputWriter(TextWriter output)
    {
        Writer = output;
    }
}