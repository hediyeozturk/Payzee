using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using PayzeeCaseStudy.API.Models;
using PayzeeCaseStudy.BL.Models.User;
using System.Text;

namespace PayzeeCaseStudy.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/{action}")]
    public class UserController : ControllerBase
    {
        private IMemoryCache memoryCache;
        public UserController(IMemoryCache _memoryCache)
        {
            memoryCache= _memoryCache;
        }

        [HttpPost]
        public async Task<IActionResult> Login()
        {
            try
            {
                UserModel? model=new UserModel();
                model.Email = "murat.karayilan@dotto.com.tr";
                model.ApiKey = "kU8@iP3@";
                model.Lang = "TR";
                model.MemberID = 1;
                model.MerchantId = 1894;
                

                var json = JsonConvert.SerializeObject(model);
                var url = "https://ppgsecurity-test.birlesikodeme.com:55002/api/ppg/Securities/authenticationMerchant";
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                using (HttpClient client = new())
                {
                    var response = await client.PostAsync(url, data);

                    if (((int)response.StatusCode) == StatusCodes.Status200OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        LoginResponse loginResponse = JsonConvert.DeserializeObject<LoginResponse>(result);

                        if (loginResponse != null && !loginResponse.fail && !string.IsNullOrEmpty(loginResponse.result.token))
                        {
                            string tokenCheck = string.Empty;
                            memoryCache.TryGetValue(model.MemberID, out tokenCheck);

                            var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(30));

                            if (string.IsNullOrEmpty(tokenCheck))
                                memoryCache.Set<string>(model.MemberID, loginResponse.result.token, cacheEntryOptions);
                            else
                            {
                                memoryCache.Remove(model.MemberID);
                                memoryCache.Set<string>(model.MemberID, loginResponse.result.token, cacheEntryOptions);
                            }
                        }
                        else
                        {
                            return BadRequest();
                        }

                        return Ok();
                    }
                    else
                    {
                        return StatusCode((int)response.StatusCode);
                    }
                }

            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }



    }
}
