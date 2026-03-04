using TeaShoppe.UI;
using TeaShoppe.Domain;
using TeaShoppe.Inventory;

namespace TeaShoppe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool stillShopping = true;

            // Open shoppe
            var cashier = new TeaShoppeCashier();
            do
            {
                cashier.RunShoppe();
                
                // Confirm still shopping
                Console.WriteLine("Search for more tea? (Y/N, default Y): ");
                char selection = char.Parse(Console.ReadLine());
                if (char.ToUpper(selection) == 'N')
                {
                    stillShopping = false;
                    cashier.CheckOut();
                }
            } while (stillShopping);
        }
    }
}