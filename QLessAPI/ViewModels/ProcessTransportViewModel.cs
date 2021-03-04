using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLessAPI.ViewModels
{
    public class ProcessTransportViewModel
    {
        public int TransportCardId { get; set; }
        public int MrtLine { get; set; }
        public decimal Cost { get; set; }
        public decimal Discount { get; set; }
        public decimal DailyDiscount { get; set; }
    }
}
