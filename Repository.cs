
namespace NinerCSEquipmentCheckout
{
    public class Repository : IRepository
    {
        List<Item> items = new List<Item>();
        public List<Item> AllItems()
        {
            return items;
        }

        public List<CheckoutRecord> AllRecords()
        {
            throw new NotImplementedException();
        }

        public CheckoutRecord GetActiveRecordFor(string itemId)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(string itemId)
        {
            throw new NotImplementedException();
        }

        public void SaveItem(Item item)
        {
            items.Add(item);
        }

        public void SaveRecord(CheckoutRecord record)
        {
            throw new NotImplementedException();
        }
    }
}
