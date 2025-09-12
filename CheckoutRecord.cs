using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinerCSEquipmentCheckout
{
    public class CheckoutRecord
    {
        public string ItemId { get; set; }
        public Borrower Borrower { get; set; }
        public DateTime CheckoutDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public CheckoutRecord(string itemId, Borrower borrower, DateTime checkoutDate, DateTime dueDate, DateTime returnDate)
        {
            ItemId = itemId;
            Borrower = borrower;
            CheckoutDate = checkoutDate;
            DueDate = dueDate;
            ReturnDate = returnDate;
        }
    }
}
