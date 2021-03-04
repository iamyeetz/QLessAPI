using QLessAPI.Interfaces;
using QLessAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLessAPI.Services
{
    public class CardTypeService : ICardTypeService
    {
        private readonly QLessDbContext _db;
        public CardTypeService(QLessDbContext db)
        {
            _db = db;
        }
        public async Task<CardType> GetCardTypeById(int id)
        {
            CardType toReturn = await _db.CardType.FindAsync(id);
            return toReturn;
        }
    }
}
