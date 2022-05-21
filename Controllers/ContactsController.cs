using AutoMapper;
using Customer.Dtos;
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

            return Ok(_mapper.Map<ContactInformationReadDto>(information));
        }

        /// <summary>
        /// Add a new ContactInformation object
        /// 
        /// POST api/contacts
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddContactInformation(ContactInformationUpsertDto contactInformationUpsertDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var informationModel = _mapper.Map<ContactInformation>(contactInformationUpsertDto);
            _contactInformationData.AddContactInformation(informationModel);

            return CreatedAtRoute(nameof(GetContactInformation), new { Id = informationModel.Id }, _mapper.Map<ContactInformationReadDto>(informationModel));
        }

        /// <summary>
        /// Update ContactInformation object
        /// 
        /// Put api/contacts/{id}
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateContactInformation(Guid id, ContactInformationUpsertDto contactInformationUpsertDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var informationFromRepo = _contactInformationData.GetContactInformation(id);
            if (informationFromRepo == null)
                return NotFound();

            // map and update the repo
            var informationFromRepoUpdated = _mapper.Map(contactInformationUpsertDto, informationFromRepo);
            _contactInformationData.UpdateContactInformation(informationFromRepoUpdated);

            // return the updated object
            return Ok(_mapper.Map<ContactInformationReadDto>(informationFromRepoUpdated));
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
