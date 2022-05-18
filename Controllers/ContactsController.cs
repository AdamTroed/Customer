using Customer.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Customer.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private MockContactInformationData _contactInformationData;
        public ContactsController(MockContactInformationData contactInformationData)
        {
            _contactInformationData = contactInformationData;
        }

        // GET api/contacts
        [HttpGet]
        public IActionResult GetContactInformations()
        {
            return Ok(_contactInformationData.GetContactInformations());
        }

        // GET api/contacts/{id}
        [HttpGet("{id}")]
        public IActionResult GetContactInformation(Guid id)
        {
            var information = _contactInformationData.GetContactInformation(id);

            if (information != null)
                return Ok(information);

            return NotFound($"Contact information with Id: {id} was not found");
        }

        /// <summary>
        /// Add a new ContactInformation object
        /// 
        /// POST api/contacts
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddContactInformation(ContactInformation contactInformation)
        {
            //TODO add validation on the model
            _contactInformationData.AddContactInformation(contactInformation);

            // return the user to the hosted instance and get method passing id
            return Created($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}/{contactInformation.Id}", contactInformation);
        }
    }
}
