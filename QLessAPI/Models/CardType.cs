using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QLessAPI.Models
{
    public class CardType
    {
        [Key]
        public int id { get; set; }
        public char Type { get; set; }
        [Column(TypeName ="varchar(20)")]
        public string Name { get; set; }
        public decimal Discount { get; set; }
    }
}
