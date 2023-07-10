using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using PayzeeCaseStudy.BL;
using PayzeeCaseStudy.BL.Enum;
using PayzeeCaseStudy.BL.Models.Transaction;
using PayzeeCaseStudy.BL.Repository;
using PayzeeCaseStudy.Entity.Models;    
using System.Net.Http.Headers;
using System.Text;

namespace PayzeeCaseStudy.API.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        readonly private TransactionRepository transactionRepository;
        private IMemoryCache _memoryCache;


        public PaymentController(IMemoryCache memoryCache)
        {
            transactionRepository = new TransactionRepository();
            _memoryCache = memoryCache;
        }

        [HttpPost]
        public async Task<IActionResult> NoneSecure(VposNoneSecureRequest model)
        {
            try
            {
                Transaction transaction = new Transaction();

                model.hash = HashOperations.CreateHashNoneSecure(model);
                model.txnType = "Auth";

                var modelJson = JsonConvert.SerializeObject(model);
                var url = "https://ppgpayment-test.birlesikodeme.com:20000/api/ppg/Payment/NoneSecurePayment";
                var data = new StringContent(modelJson, Encoding.UTF8, "application/json");

                transaction.CustomerId = Convert.ToInt32(model.customerId);
                transaction.OrderId = model.orderId;
                transaction.Request = modelJson;
                transaction.OrderId = model.orderId;
                transaction.TransactionType = TransactionType.Void.ToString();
                transactionRepository.Insert(transaction);  

                using (HttpClient client = new())
                {
                    string userToken = _memoryCache.Get<string>(model.memberId);

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userToken);

                    var response = await client.PostAsync(url, data);
                    string responseBody = await response.Content.ReadAsStringAsync();

                    transaction.Response = responseBody;
                    transaction.ResponseCode = response.StatusCode.ToString();
                    transactionRepository.Update();

                    if (((int)response.StatusCode) == StatusCodes.Status200OK)
                    {
                        return new ContentResult
                        {
                            ContentType = "text/html",
                            Content = responseBody
                        };                        
                    }
                    else
                        return StatusCode((int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
