namespace NinerCSEquipmentCheckout
{
    public class Program
    {
        static void Main(string[] args)
        {
            int choiceNumber = -1;
            Repository repository = new Repository();
            Catalog catalog = new Catalog(repository);
            while (choiceNumber != 0)
            {

                Console.WriteLine("1) Add items to inventory");
                Console.WriteLine("2) List available items");
                Console.WriteLine("3) List unavailable items");
                Console.WriteLine("4) Check out item");
                Console.WriteLine("5) Return item");
                Console.WriteLine("6) Due soon (next 24h)");
                Console.WriteLine("7) Overdue");
                Console.WriteLine("8) Search");
                Console.WriteLine("9) Mark item LOST");
                Console.WriteLine("0) Exit");
                Console.Write("Select a number: ");
                if (!int.TryParse(Console.ReadLine(), out choiceNumber))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    return;
                }
                string continued = "y";
                switch (choiceNumber)
                {
                    case 0:
                        break;
                    case 1:
                        while (continued == "y")
                        {
                            Console.WriteLine("Add items to inventory");
                            Console.WriteLine("Enter each field on its own line: ID, Name, Category, Condition");

                            Console.Write("ID: ");
                            if (!int.TryParse(Console.ReadLine(), out int ID))
                            {
                                Console.WriteLine("Invalid ID input.");
                                continue;
                            }

                            Console.Write("Name: ");
                            string? name = Console.ReadLine();

                            Console.Write("Category: ");
                            string? category = Console.ReadLine();

                            Console.Write("Condition: ");
                            string? condition = Console.ReadLine();


                            Item item = new Item(ID, name, category, condition, ItemStatus.AVAILABLE);
                            repository.SaveItem(item);
                            Console.Write("Add another item? (y/n): ");
                            continued = Console.ReadLine().ToLower();
                        }
                        break;
                    case 2:
                        catalog.ListAvailable();
                        break;
                    case 3:
                        catalog.ListUnavailable();
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                }
            }

        }
    }
}
