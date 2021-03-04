using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QLessAPI.Models
{
    public class DiscountCardDetails
    {

        [Key]
        public int Id { get; set; }
        public int TransportCardId { get; set; }
        [Column(TypeName = "varchar(14)")]
        public string GovernmentIdNumber { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string GovernmentIdType { get; set; }
    }
}
