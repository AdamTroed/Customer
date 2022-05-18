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

        /// <summary>
        /// Update ContactInformation object
        /// 
        /// Patch api/contacts/{id}
        /// 
        /// TODO want a DTO class without id property here as that is for internal use and should not be update-able
        /// 
        /// As only UPDATE was specified in the instructions, we do not add an PUT method, which also adds a new
        /// record if the item passed does not exist.
        /// </summary>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult UpdateContactInformation(Guid id, ContactInformation contactInformation)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var information = _contactInformationData.GetContactInformation(id);
            if (information == null)
                return NotFound();
            
            // update and return the updated object
            return Ok(_contactInformationData.UpdateContactInformation(contactInformation));
        }

        /// <summary>
        /// Delete a ContactInformation object
        /// 
        /// DELETE api/contacts/{id}
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteContactInformation(Guid id)
        {
            var information = _contactInformationData.GetContactInformation(id);
            if (information == null)
                return NotFound();

            _contactInformationData.DeleteContactInformation(information);
            return Ok();
        }
    }
}
