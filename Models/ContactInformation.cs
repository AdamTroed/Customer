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
        /// One user can have multiple contact informations
        /// </summary>
        public Guid Id { get; set; }

        [Required]
        [Lenght(10, 12, ErrorMessage = "Invalid lenght of social security number")]
        public long SocialSecurityNumber { get; set; }

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
