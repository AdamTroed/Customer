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

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddContactInformation(ContactInformation contactInformation)
        {
            //TODO add validation on the model
            _contactInformationData.AddContactInformation(contactInformation);

            // return the user to the hosted instance and get method passing id
            return Created($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}/{contactInformation.Id}", contactInformation);
        }
    }
}
