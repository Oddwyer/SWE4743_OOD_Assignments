namespace TeaShoppe.UI;

public class InventoryQueryOutputWriter
{
    public TextWriter Writer { get; }
    public InventoryQueryOutputWriter(TextWriter output)
    {
        Writer = output;
    }
}