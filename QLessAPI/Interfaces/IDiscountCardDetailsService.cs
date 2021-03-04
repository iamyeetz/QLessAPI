using QLessAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLessAPI.Interfaces
{
    public interface IDiscountCardDetailsService
    {

        Task<bool> AddDiscountCardDetails(DiscountCardDetails discountCardDetails);
        Task<bool> DeleteDiscountCardDetails(DiscountCardDetails discountCardDetails);
        Task<DiscountCardDetails> GetDiscountCardDetailsById(int id);
    }
}
