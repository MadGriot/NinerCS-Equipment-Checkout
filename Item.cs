using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinerCSEquipmentCheckout
{
    public class Item
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? Condition { get; set; }
        public ItemStatus Status { get; set; }

        public Item(int id, string name, string category, string condition, ItemStatus status)
        {
            Id = id;
            Name = name;
            Category = category;
            Condition = condition;
            Status = status;
        }
    }
}
