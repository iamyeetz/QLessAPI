using QLessAPI.Interfaces;
using QLessAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLessAPI.Services
{
    public class CardService : ICardService
    {
        private readonly QLessDbContext _db;
        public CardService(QLessDbContext db)
        {
            _db = db;
        }
        public async Task<int> CreateNewCard()
        {
            try
            {
                TransportCard transportCard = new TransportCard
                {
                    Load = 100,
                    DateRegistered = null,
                    CreateDate = DateTime.Now,
                    ExpirationDate = DateTime.Now.AddYears(5),
                    LastDateUsed = null,
                    CardTypeId = 1
                };
                await _db.AddAsync(transportCard);
                await _db.SaveChangesAsync();
                int id = transportCard.Id;
                return id;
            }
            catch (Exception)
            {

                return 0;
            }

        }

        public async Task<bool> DiscountCardRegistration(int transportTypeId,int cardTypeId)
        {
            try
            {
                TransportCard item = await GetTransportCardById(transportTypeId);
                item.CardTypeId = cardTypeId;
                item.DateRegistered = DateTime.Now;
                _db.Update(item);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public async Task<TransportCard> GetTransportCardById(int id)
        {
           TransportCard toReturn =  await _db.TransportCard.FindAsync(id);
           return toReturn;
        }

        public async Task<bool> TopUpAccount(TransportCard transportCard)
        {
            try
            {
                _db.TransportCard.Update(transportCard);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
          
        }

        public async Task<bool> UpdateCard(TransportCard transportCard)
        {
    
            try
            {
                _db.Update(transportCard);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
