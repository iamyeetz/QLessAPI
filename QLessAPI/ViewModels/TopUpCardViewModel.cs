using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLessAPI.ViewModels
{
    public class TopUpCardViewModel
    {
        public int TransportCardId { get; set; }
        public decimal Balance { get; set; }
        public decimal Cash { get; set; }
        public decimal Amount  { get; set; }
        public decimal Change { get; set; }
    }
}
