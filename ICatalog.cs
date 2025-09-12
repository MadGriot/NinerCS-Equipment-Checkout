using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinerCSEquipmentCheckout
{
    public interface ICatalog
    {
        // Returns a list of items that are currently available for checkout.
        List<Item> ListAvailable();

        // Returns a list of items that are currently unavailable for checkout.
        List<Item> ListUnavailable();

        // Finds a specific item by its ID.
        Item FindById(string itemId);

        // OPTIONAL. Searches items by a keyword (e.g., name or category).
        List<Item> SearchBy(int criteria, string query);
    }
}
