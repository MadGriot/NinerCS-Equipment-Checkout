
namespace NinerCSEquipmentCheckout
{
    public interface ICatalog
    {
        // Returns a list of items that are currently available for checkout.
        void ListAvailable();

        // Returns a list of items that are currently unavailable for checkout.
        void ListUnavailable();

        // Finds a specific item by its ID.
        Item FindById(string itemId);

        // OPTIONAL. Searches items by a keyword (e.g., name or category).
        List<Item> SearchBy(string query);
    }
}
