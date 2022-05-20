using AutoMapper;
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
        private readonly IMapper _mapper;
        public ContactsController(MockContactInformationData contactInformationData, IMapper mapper)
        {
            _contactInformationData = contactInformationData;
            _mapper = mapper;
        }

        // GET api/contacts
        [HttpGet]
        public IActionResult GetAllContactInformation()
        {
            return Ok(_contactInformationData.GetAllContactInformation());
        }

        // GET api/contacts/{id}
        [HttpGet("{id}", Name = "GetContactInformation")]
        public IActionResult GetContactInformation(Guid id)
        {
            var information = _contactInformationData.GetContactInformation(id);

            if (information == null)
                return NotFound($"Contact information with Id: {id} was not found");

            return Ok(information);
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
        /// Put api/contacts/{id}
        /// 
        /// TODO want a DTO class without id property here as that is for internal use and should not be update-able
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateContactInformation(Guid id, ContactInformation contactInformation)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var information = _contactInformationData.GetContactInformation(id);
            if (information == null)
                return NotFound();
            
            // update and return the updated object
            return Ok(_contactInformationData.UpdateContactInformation(id ,contactInformation));
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
