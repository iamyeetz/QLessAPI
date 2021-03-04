using Microsoft.EntityFrameworkCore;
using QLessAPI.Interfaces;
using QLessAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLessAPI.Services
{
    public class TransportService : ITransportService
    {
        private readonly QLessDbContext _db;
        public TransportService(QLessDbContext db)
        {
            _db = db;
        }

        public async Task<bool> AddTransport(Transport transport)
        {
      
            try
            {
                await _db.Transport.AddAsync(transport);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<List<Transport>> GetAllTransportById(int id)
        {
            List<Transport> toReturn = await _db.Transport.Where(x => x.TransportCardId == id).ToListAsync();
            return toReturn;
        }
    }
}
