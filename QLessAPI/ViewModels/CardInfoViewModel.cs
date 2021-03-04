using QLessAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLessAPI.ViewModels
{
    public class CardInfoViewModel
    {
        public int Id { get; set; }
        public decimal Load { get; set; }
        public int CardTypeId { get; set; }
        public string DateRegistered { get; set; }
        public string CreateDate { get; set; }
        public string LastDateUsed { get; set; }
        public string ExpirationDate { get; set; }
        public int TodayCardUsage { get; set; }


        public virtual CardType CardType { get; set; } = new CardType();
        public virtual List<Transport> Transports { get; } = new List<Transport>();
        public virtual DiscountCardDetails DiscountCardDetails { get; set; } = new DiscountCardDetails();
    }
}
