using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinerCSEquipmentCheckout
{
    internal interface INotifier
    {
        // Called to log when an item is due soon.
        void DueSoon(Borrower borrower, CheckoutRecord record);

        // Called to log when an item is overdue.
        void Overdue(Borrower borrower, CheckoutRecord record);
    }
}
