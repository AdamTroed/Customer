using Customer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{
    [ApiController]
    public class ContactInformationController : ControllerBase
    {
        private MockContactInformationData _contactInformationData;
        public ContactInformationController(MockContactInformationData contactInformationData)
        {
            _contactInformationData = contactInformationData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetContactInformations()
        {
            return Ok(_contactInformationData.GetContactInformations());
        }
    }
}
