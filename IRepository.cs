using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinerCSEquipmentCheckout
{
    public interface IRepository
    {
        // Save or update an item in the inventory.
        void SaveItem(Item item);

        // Retrieve an item by its ID.
        Item GetItem(string itemId);

        // Get all items in the inventory.
        List<Item> AllItems();

        // Save or update a loan record.
        void SaveRecord(CheckoutRecord record);

        // Get the active loan record for a specific item.
        CheckoutRecord GetActiveRecordFor(string itemId);

        // Get all loan records (active and returned).
        List<CheckoutRecord> AllRecords();
    }
}
