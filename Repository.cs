
namespace NinerCSEquipmentCheckout
{
    public class Repository : IRepository
    {
        List<Item> items = new List<Item>();
        List<CheckoutRecord> records = new List<CheckoutRecord>();
        public List<Item> AllItems()
        {
            return items;
        }

        public List<CheckoutRecord> AllRecords()
        {
            return records;
        }

        public CheckoutRecord GetActiveRecordFor(int itemId)
        {
            return records.First(x => x.ItemId == itemId);
        }

        public Item GetItem(int itemId)
        {
            return items.First(x => x.Id == itemId);
        }

        public void SaveItem(Item item)
        {
            items.Add(item);
        }

        public void SaveRecord(CheckoutRecord record)
        {
            records.Add(record);
        }
    }
}
