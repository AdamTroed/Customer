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
        [HttpGet("{id}", Name = "GetContactInformation")]
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
        /// 
        /// TODO want a DTO without id property here as that is for internal use
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddContactInformation(ContactInformation contactInformation)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _contactInformationData.AddContactInformation(contactInformation);

            return CreatedAtRoute(nameof(GetContactInformation), new { Id = contactInformation.Id }, contactInformation);
        }

        }
    }
}
