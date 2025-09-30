
namespace NinerCSEquipmentCheckout
{
    public class Program
    {
        static void Main(string[] args)
        {
            int choiceNumber = -1;
            int itemID = 0;
            Repository repository = new Repository();
            Catalog catalog = new Catalog(repository);
            CheckoutService checkoutService = new CheckoutService(catalog, repository);

            Item testItem = new Item(9, "UltraComputer", "Mainframe", "Used", ItemStatus.AVAILABLE);
            repository.SaveItem(testItem);
            Borrower dummyBorrower = new Borrower("AGuy", "dummyEmail@Mail.com");
            DateTime testDateTime = DateTime.Now;
            testDateTime = testDateTime.AddHours(2);
            checkoutService.Checkout(9, dummyBorrower, testDateTime);

            while (choiceNumber != 0)
            {
                Console.WriteLine("=============================");
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
                Console.WriteLine("=============================");
                string continued = "y";
                switch (choiceNumber)
                {
                    case 0:
                        Console.WriteLine("Goodbye");
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
                        Console.WriteLine("Check out item");
                        Console.Write("Insert Item ID: ");
                        if (!int.TryParse(Console.ReadLine(), out itemID))
                        {
                            Console.WriteLine("Invalid ID input.");
                            continue;
                        }
                        if (!checkoutService.CanCheckout(itemID))
                        {
                            Console.WriteLine($"You cannot checkout {repository.GetItem(itemID).Name}");
                            continue;
                        }
                        Console.Write("Your name: ");
                        string? yourName = Console.ReadLine();
                        Console.Write("Your email: ");
                        string? email = Console.ReadLine();

                        Borrower borrower = new Borrower(yourName, email);
                        DateTime dueDate = DateTime.Now;
                        dueDate = dueDate.AddDays(7);

                        Console.WriteLine($"Due Date: {dueDate.ToString("M/d/yyyy")}");

                        Console.WriteLine($"Your receipt");
                        Receipt receipt = checkoutService.Checkout(itemID, borrower, dueDate);
                        Console.WriteLine($"{receipt.ToString()}");
                        break;
                    case 5:
                        Console.WriteLine("Retern an item");
                        Console.Write("Insert Item ID: ");
                        if (!int.TryParse(Console.ReadLine(), out itemID))
                        {
                            Console.WriteLine("Invalid ID input.");
                            continue;
                        }
                        Receipt receipt2 = checkoutService.ReturnItem(itemID);
                        Console.WriteLine($"{receipt2.ToString()}");
                        break;
                    case 6:
                        List<CheckoutRecord> itemsSoonToBeDue = checkoutService.FindDueSoon(TimeSpan.FromHours(24));
                        if (itemsSoonToBeDue.Any())
                        {
                            Console.WriteLine("Due soon (next 24h");
                            foreach (CheckoutRecord checkoutRecord in itemsSoonToBeDue)
                            {
                                Console.WriteLine($"Item ID: {checkoutRecord.ItemId} | Borrowed by {checkoutRecord.Borrower.Name} | {checkoutRecord.Borrower.Email}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("None Found.");
                        }
                        break;
                    case 7:
                        List<CheckoutRecord> itemsOverdue = checkoutService.FindOverdue();
                        if (itemsOverdue.Any())
                        {
                            Console.WriteLine("Items Overdue");
                            foreach (CheckoutRecord checkoutRecord in itemsOverdue)
                            {
                                Console.WriteLine($"Item ID: {checkoutRecord.ItemId} | Borrowed by {checkoutRecord.Borrower.Name} | {checkoutRecord.Borrower.Email}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("None Found.");
                        }
                        break;
                    case 8:
                        Console.WriteLine("Search");
                        Console.Write("Query: ");
                        string? query = Console.ReadLine();
                        List<Item> itemsSearched = catalog.SearchBy(query);
                        if (itemsSearched.Any())
                        {
                            Console.WriteLine("Results");
                            foreach (Item item in itemsSearched)
                            {
                                Console.WriteLine($"{item.Id} | {item.Name} | {item.Condition}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("None Found.");
                        }
                        break;
                    case 9:
                        Console.WriteLine("Mark item LOST");
                        Console.Write("Insert Item ID: ");
                        if (!int.TryParse(Console.ReadLine(), out itemID))
                        {
                            Console.WriteLine("Invalid ID input.");
                            continue;
                        }
                        checkoutService.MarkLost(itemID);
                        break;

                    }
            }

        }
    }
}
