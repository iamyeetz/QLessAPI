using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLessAPI.Interfaces;
using QLessAPI.Models;
using QLessAPI.Services;
using QLessAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace QLessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;
        private readonly ICardTypeService _cardTypeService;
        private readonly IDiscountCardDetailsService _discountCardDetailsService;
        private readonly ITransportService _transportService;
        public CardController(ICardService cardService ,
                              ICardTypeService cardTypeService, 
                              IDiscountCardDetailsService discountCardDetailsService,
                              ITransportService transportService)
        {
            _cardService = cardService;
            _cardTypeService = cardTypeService;
            _discountCardDetailsService = discountCardDetailsService;
            _transportService = transportService;
        }

       [HttpPost]
       [Route("CreateCard")]
       public async Task<IActionResult> CreateNewCard()
        {
           
            int result = await _cardService.CreateNewCard();
            
            if(result > 0 )
            {
                return Ok(new { response_message = "Successfully Created Q-LESS Card. Card Number is : " + result, id = result, isError = false });
             }
            else
            {
                return BadRequest(new { response_message = "Internal Server Error. Please contact your local IT.", isError = true });
            }

        }

        [HttpPost]
        [Route("AvailDiscountCard")]
        public  async Task<IActionResult> DiscountCardRegistration([FromBody] DiscountCardRegistrationViewModel dcr)
        {

            TransportCard transportCard = await _cardService.GetTransportCardById(dcr.TransportCardId);
            if((DateTime.Now.Date - transportCard.CreateDate.Date).Days > 60 )
            {
                return BadRequest(new { response_message = "Cannot Proceed. Card is only eligible for discount registration within 60 days after the card was purchased.", isError = true });
            }


            DiscountCardDetails toSave = new DiscountCardDetails
            {
                TransportCardId = dcr.TransportCardId,
                GovernmentIdNumber = dcr.IdNumber,
                GovernmentIdType = dcr.IdType

            };

            CardType cardType = await _cardTypeService.GetCardTypeById(dcr.CardTypeId);

            bool discountDetailsResult = await _discountCardDetailsService.AddDiscountCardDetails(toSave);
            if (!discountDetailsResult)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return BadRequest(new { response_message = "Internal Server Error. Please contact your local IT.", isError = true });
            }               

          
            bool transportCardUpdateResult = await _cardService.DiscountCardRegistration(dcr.TransportCardId, cardType.id);
            //rolling back / deleting inserted 

            if (!transportCardUpdateResult)
            {
                DiscountCardDetails discountCardDetails = await _discountCardDetailsService.GetDiscountCardDetailsById(cardType.id);
                bool responseRollback =  await _discountCardDetailsService.DeleteDiscountCardDetails(discountCardDetails);

                //while (!responseRollback)
                //{
                //    await Task.Delay(3000);
                //    responseRollback = _discountCardDetailsService.DeleteDiscountCardDetails(discountCardDetails).GetAwaiter().GetResult();
                //}
                //transportCardUpdateResult = true;
            }

            if(transportCardUpdateResult)
            {
                return Ok(new { response_message = "Successfully registered discount card.", isError = false });
            }
                return BadRequest(new { response_message = "Internal Server Error. Please contact your local IT.", isError = true });

           
        }

        [HttpGet]
        [Route("GetCardById")]
        public async Task<IActionResult> GetTransportCardById([FromQuery] int id)
        {
            TransportCard transportCard = await _cardService.GetTransportCardById(id);
            if(transportCard == null)
            {
                return BadRequest(new {response_message = "Cannot find record with the entered transport card id. Please try again." ,isError = true});
            }
            CardInfoViewModel response = new CardInfoViewModel
            {
                CardType = _cardTypeService.GetCardTypeById(transportCard.CardTypeId).Result,
                CardTypeId = transportCard.CardTypeId,
                CreateDate = formatDateToShow(transportCard.CreateDate),
                DateRegistered = formatDateToShow(transportCard.DateRegistered),
                DiscountCardDetails = _discountCardDetailsService.GetDiscountCardDetailsById(id).Result,
                ExpirationDate = formatDateToShow(transportCard.ExpirationDate),
                Id = transportCard.Id,
                LastDateUsed = formatDateToShow(transportCard.LastDateUsed),
                Load = transportCard.Load,
                TodayCardUsage = _transportService.GetAllTransportById(id).Result.Count


            };
            //result.CardType = await _cardTypeService.GetCardTypeById(result.CardTypeId);
            return Ok(response);
        }

        [HttpPost]
        [Route("TopUpAccount")]
        public async Task<IActionResult> TopUpTransportCard([FromBody] TopUpCardViewModel tuc )
        {

            if(tuc.Amount < 100 || tuc.Amount >10000)
            {
                return BadRequest(new { response_message = "Cannot Proceed. You can only top up between the amount of 100 to 10000 pesos.", isError = true });
            }

            TransportCard transportCard = await _cardService.GetTransportCardById(tuc.TransportCardId);
            transportCard.Load += tuc.Amount;
            bool response = await _cardService.TopUpAccount(transportCard);



            if(response)
            {

                tuc.Balance = transportCard.Load;
                tuc.Change = tuc.Cash - tuc.Amount;
                
                return Ok(new { response_message = "Successfully Credited to account." ,isError = false, tuc });
            }
            else
            {
                return BadRequest(new { response_message = "Internal Server Error. Please contact your local IT.", isError = true });
            }

        
        }

        [HttpPost]
        [Route("ProcessTrip")]
        public async Task<IActionResult> ProcessTrip([FromBody] ProcessTransportViewModel pt)
        {
            Transport transport = new Transport
            {
                Cost = pt.Cost - (pt.Discount + pt.DailyDiscount),
                MrtLine = pt.MrtLine,
                TransportCardId = pt.TransportCardId,
                TrasportDate = DateTime.Now

            };

            bool resultAddTransport = await _transportService.AddTransport(transport);

            TransportCard transportCard = await _cardService.GetTransportCardById(pt.TransportCardId);
            transportCard.Load -= pt.Cost;
            transportCard.LastDateUsed = DateTime.Now;
            transportCard.ExpirationDate = DateTime.Now.AddYears(5);

            bool resultUpdateCard = await _cardService.UpdateCard(transportCard);

            return Ok(new { response_message = "Successfuly proccessed trip." });

        }


        private string formatDateToShow(DateTime? date)
        {
            if(date != null)
            {
                var year = date.Value.Year;
                var month = date.Value.Month;
                var day = date.Value.Day;
                var toReturn = month + "-" + day + "-" + year;
                return toReturn;
            }

            return null;
        }

    }
}
