using QLessAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLessAPI.Interfaces
{
    public interface ITransportService
    {
        Task<List<Transport>> GetAllTransportById(int id);
        Task<bool> AddTransport(Transport transport);
    }
}
