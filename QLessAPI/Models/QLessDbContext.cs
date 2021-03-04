using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLessAPI.Models
{
    public class QLessDbContext : DbContext
    {

        public DbSet<TransportCard> TransportCard { get; set; }
        public DbSet<Transport> Transport { get; set; }
        public DbSet<DiscountCardDetails> DiscountCardDetails { get; set; }
        public DbSet<CardType> CardType { get; set; }

        public QLessDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
