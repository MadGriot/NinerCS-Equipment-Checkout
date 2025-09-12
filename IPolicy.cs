using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinerCSEquipmentCheckout
{
    public interface IPolicy
    {
        // Determines if an item is eligible for checkout.
        bool CanCheckout(Item item);

        // Adjusts the proposed due date to fit within allowed limits.
        DateTime NormalizeDueDate(DateTime proposed);
    }
}
