using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLessAPI.Interfaces
{
    public interface ICardService
    {

        Task<int> CreateNewCard();
        Task<bool> DiscountCardRegistration(int transportCardId,int cardTypeId);
        Task<bool> UpdateCard(TransportCard transportCard);
        Task<bool> TopUpAccount(TransportCard transportCard);
        Task<TransportCard> GetTransportCardById(int id);

    }
}
