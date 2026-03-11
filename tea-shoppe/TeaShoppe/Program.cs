using TeaShoppe.UI;
using TeaShoppe.Domain;
using TeaShoppe.Inventory;

namespace TeaShoppe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TeaShoppeFacade newShoppe = new TeaShoppeFacade(Console.In, Console.Out);
            bool stillShopping = true;

            // Open shoppe
            var cashier = new TeaShoppeCashier(newShoppe, Console.In, Console.Out);
            while (stillShopping)
            {
                cashier.RunShoppe();

                // Confirm still shopping
                Console.Write("Search for more tea? (Y/N, default Y): ");
                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    char selection = char.Parse(input);
                    if (char.ToUpper(selection) == 'N')
                    {
                        stillShopping = false;
                        cashier.CheckOut();
                    }
                }
                
            }
        }
    }
}