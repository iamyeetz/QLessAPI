using QLessAPI.Models;
using System.Threading.Tasks;

namespace QLessAPI.Interfaces
{
    public interface ICardTypeService
    {

        Task<CardType> GetCardTypeById(int id);
    }
}
