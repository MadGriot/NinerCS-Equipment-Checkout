
namespace NinerCSEquipmentCheckout
{
    public class Catalog : ICatalog
    {
        private readonly Repository repository;

        public Catalog(Repository repository)
        {
            this.repository = repository;
        }
        public Item FindById(string itemId)
        {
            throw new NotImplementedException();
        }

        public void ListAvailable()
        {
            Console.WriteLine("Available Items:");
            foreach (Item item in repository.AllItems().Where(x => x.Status == ItemStatus.AVAILABLE))
            {
                Console.WriteLine($"- {item.Id} | {item.Name} | {item.Category}");
            }
        }

        public void ListUnavailable()
        {
            Console.WriteLine("Unavailable Items:");
            foreach (Item item in repository.AllItems().Where(x => x.Status == ItemStatus.CHECKED_OUT || x.Status == ItemStatus.LOST))
            {
                Console.WriteLine($"- {item.Id} | {item.Name} | {item.Category}");
            }
        }

        public List<Item> SearchBy(string? query)
        {
            return repository.AllItems()
                .Where(x => x.Name != null && x.Name.Contains(query)).ToList();
        }
    }
}
