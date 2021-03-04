using QLessAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLessAPI
{
    public  class TransportCard
    {

        [Key]     
        public int Id { get; set; }
        public decimal Load { get; set; }
        public int CardTypeId { get; set; }
        public DateTime? DateRegistered { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastDateUsed { get; set; }
        public DateTime ExpirationDate { get; set; }



        public virtual CardType CardType { get; set; }
        public virtual List<Transport> Transports { get; }
        public virtual DiscountCardDetails DiscountCardDetails { get; set; }
      
    }
    
}
