using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinerCSEquipmentCheckout
{
    public class Receipt
    {
        public string Message { get; set; }
        public int ItemId { get; set; }
        public DateTime Timestamp { get; set; }

        public Receipt(string message, int itemId, DateTime timestamp)
        {
            Message = message;
            ItemId = itemId;
            Timestamp = timestamp;
        }

        public override string ToString()
        {
            return $"{Timestamp.ToString("M/d/yyyy")} | {Timestamp.ToString("HH:mm")} | {Message} | {ItemId}";
        }
    }
}
