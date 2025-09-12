using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinerCSEquipmentCheckout
{
    public interface IClock
    {
        // Returns the current date (or time).
        DateTime Today();
    }
}
