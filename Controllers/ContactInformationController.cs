using Customer.Models;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetContactInformation(Guid id)
        {
            var information = _contactInformationData.GetContactInformation(id);

            if (information != null)
                return Ok(information);

            return NotFound($"Contact information with Id: {id} was not found");
        }
    }
}
