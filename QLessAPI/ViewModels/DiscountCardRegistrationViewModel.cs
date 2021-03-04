using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLessAPI.ViewModels
{
    public class DiscountCardRegistrationViewModel
    {
        public int TransportCardId { get; set; }

        public int CardTypeId { get; set; }
        public string IdType { get; set; }
        public string IdNumber { get; set; }

    }
}
