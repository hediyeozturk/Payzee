using KPSService;
using Microsoft.AspNetCore.Mvc;
using PayzeeCaseStudy.API.Models;
using PayzeeCaseStudy.BL.Enum;
using PayzeeCaseStudy.BL.Repository;
using PayzeeCaseStudy.Entity.Models;

namespace PayzeeCaseStudy.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/{action}")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepository customerRepository;


        public CustomerController()
        {
            customerRepository= new CustomerRepository();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerModel model)
            {
            try
            {
                Customer customer = new Customer();
                customer.Surname = model.Surname;
                customer.Name = model.Name;
                customer.BirthDate = model.BirthDate;
                customer.Status = (int)(CustomerStatus.Passive);
                customer.IdentityNo=model.IdentityNo;

                var result = customerRepository.Insert(customer);

                if (result)
                {
                    using (KPSPublicSoapClient client = new(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap))
                    {
                        var response = await client.TCKimlikNoDogrulaAsync(long.Parse(model.IdentityNo), model.Name, model.Surname, model.BirthDate.Year);

                        if (response.Body.TCKimlikNoDogrulaResult)
                        {
                            customer.IdentityNoVerified = true;
                            customer.Status = (int)CustomerStatus.Active;
                            customerRepository.Update();
                        }
                    }
                }
                else
                {
                    return StatusCode(500);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
