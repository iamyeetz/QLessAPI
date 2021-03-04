using Microsoft.EntityFrameworkCore;
using QLessAPI.Interfaces;
using QLessAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLessAPI.Services
{
    public class DiscountCardDetailsService : IDiscountCardDetailsService
    {

        private readonly QLessDbContext _db;
        public DiscountCardDetailsService(QLessDbContext db)
        {
            _db = db;
        }
        public async Task<bool> AddDiscountCardDetails(DiscountCardDetails discountCardDetails)
        {
            try
            {
                await _db.DiscountCardDetails.AddAsync(discountCardDetails);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> DeleteDiscountCardDetails(DiscountCardDetails discountCardDetails)
        {
   
            try
            {
                _db.DiscountCardDetails.Remove(discountCardDetails);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<DiscountCardDetails> GetDiscountCardDetailsById(int id)
        {
            DiscountCardDetails toReturn = await Task.Run(() => _db.DiscountCardDetails.Where(x => x.TransportCardId == id).SingleOrDefault());
            return toReturn;
        }
    }
}
