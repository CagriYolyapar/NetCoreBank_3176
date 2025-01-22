using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreBank.Models.ContextClasses;
using NetCoreBank.Models.Entities;
using NetCoreBank.Models.RequestModels;
using NetCoreBank.Models.ResponseModels;

namespace NetCoreBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        MyContext _context;

        public TransactionController(MyContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public async Task<IActionResult> Test()
        //{
        //    List<PaymentResponseModel> cardInfoes = await _context.CardInfoes.Select(x => new PaymentResponseModel
        //    {
        //        CardUserName = x.CardUserName
        //    }).ToListAsync();

        //    return Ok(cardInfoes);
        //}


        [HttpPost]
        public async Task<IActionResult> StartTransaction(PaymentRequestModel item)
        {
            if(_context.CardInfoes.Any(x => x.CardNumber == item.CardNumber && x.CVV == item.CVV && x.CardUserName == item.CardUserName)) //aslında burada daha katı daha ayrıntılı bir business logic yapılır
            {
                UserCardInfo? uCInfo = await _context.CardInfoes.SingleOrDefaultAsync(x => x.CardNumber == item.CardNumber && x.CVV == item.CVV && x.CardUserName == item.CardUserName);

                if (uCInfo.Balance >= item.ShoppingPrice)
                {
                    uCInfo.Balance -= item.ShoppingPrice; //Fiyat,kartın balance'indan düser

                    await _context.SaveChangesAsync();
                    return Ok("Ödeme basarıyla alındı");
                }

                else return StatusCode(400, "Kart bakiyesi yetersiz bulundu");
            }
            return StatusCode(400, "Kart bulunamadı");
        }
    }
}
