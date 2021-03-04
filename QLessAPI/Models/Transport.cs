using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLessAPI.Models
{
    public class Transport
    {
        [Key]
        public int Id { get; set; }
        public int TransportCardId { get; set; }
        public int MrtLine { get; set; }
        public decimal Cost { get; set; }
        public DateTime TrasportDate { get; set; }
    }


    
   
}
