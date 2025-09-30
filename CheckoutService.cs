

namespace NinerCSEquipmentCheckout
{
    public class CheckoutService : ICheckoutService
    {
        private readonly ICatalog catalog;
        private readonly IRepository repository;

        public CheckoutService(ICatalog catalog, IRepository repository)
        {
            this.catalog = catalog;
            this.repository = repository;
        }

        public bool CanCheckout(int itemId)
        {
            return repository.GetItem(itemId).Status == ItemStatus.AVAILABLE;
        }

        public Receipt Checkout(int itemId, Borrower borrower, DateTime dueDate)
        {
            CheckoutRecord checkoutRecord = new CheckoutRecord(itemId, borrower, DateTime.Now, dueDate);
            repository.SaveRecord(checkoutRecord);
            repository.GetItem(itemId).Status = ItemStatus.CHECKED_OUT;
            return new Receipt($"Due Date: {dueDate.ToString()}", itemId, DateTime.Now);
        }

        public List<CheckoutRecord> FindDueSoon(TimeSpan window)
        {

            DateTime now = DateTime.Now;
            DateTime cutoff = now.Add(window);

            return repository.AllRecords()
                .Where(x => x.DueDate > now && x.DueDate <= cutoff)
                .ToList();
        }

        public List<CheckoutRecord> FindOverdue()
        {
            return repository.AllRecords()
                .Where(x => x.DueDate < DateTime.Now).ToList();
        }

        public ICatalog GetCatalog()
        {
            return catalog;
        }

        public List<CheckoutRecord> ListActiveLoans()
        {
            throw new NotImplementedException();
        }

        public void MarkLost(int itemId)
        {
            repository.GetItem(itemId).Status = ItemStatus.LOST;
        }

        public Receipt ReturnItem(int itemId)
        {
            repository.GetActiveRecordFor(itemId).ReturnDate = DateTime.Now;
            repository.GetItem(itemId).Status = ItemStatus.AVAILABLE;
            return new Receipt($"Returned", itemId, DateTime.Now);
        }
    }
}
