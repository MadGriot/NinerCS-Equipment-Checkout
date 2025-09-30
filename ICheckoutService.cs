
namespace NinerCSEquipmentCheckout
{
    public interface ICheckoutService
    {
            // Provides access to the catalog of items.
            ICatalog GetCatalog();

            // Checks out an item to a borrower and returns a receipt.
            Receipt Checkout(int itemId, Borrower borrower, DateTime dueDate);

            // Returns an item and generates a receipt.
            Receipt ReturnItem(int itemId);

            // Marks an item as lost.
            void MarkLost(int itemId);

            // Lists all currently active loans.
            List<CheckoutRecord> ListActiveLoans();

            // Finds loans that are due within a given time window (e.g., next 24 hours).
            List<CheckoutRecord> FindDueSoon(TimeSpan window);

            // Finds loans that are overdue.
            List<CheckoutRecord> FindOverdue();

            bool CanCheckout(int itemId);
    }
}
