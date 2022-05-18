using Customer.Core.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Customer.Models
{
    /// <summary>
    /// In this project this class serves as a DTO and and domain entity
    /// These should be separate, but due to the time limit, it does not
    /// </summary>
    public class ContactInformation
    {
        /// <summary>
        /// Id - unique identifier for each record
        /// 
        /// One user can have multiple contact informations hence we
        /// add this id as a unique id per record
        /// 
        /// TODO: This should not be available for the users
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// This should NOT be nullable, as per specifications it shouldn't.
        /// But it needs to be nullable to make the data annotation validations to work properly
        /// and we do not have a DTO class to handle this separately
        /// </summary>
        [Required]
        [Lenght(10, 12, ErrorMessage = "Invalid lenght of social security number")]
        public long? SocialSecurityNumber { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Phone number
        /// 
        /// string as it can include country code, e.g. +46
        /// </summary>
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
