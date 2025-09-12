using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinerCSEquipmentCheckout
{
    public class Borrower
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public Borrower(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
