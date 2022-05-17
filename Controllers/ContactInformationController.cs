using Customer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInformationController : ControllerBase
    {
        private MockContactInformationData _contactInformationData;
        public ContactInformationController(MockContactInformationData contactInformationData)
        {
            _contactInformationData = contactInformationData;
        }
    }
}
