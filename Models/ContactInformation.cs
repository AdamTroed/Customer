using Customer.Core.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Customer.Models
{
    public class ContactInformation
    {
        /// <summary>
        /// Id - unique identifier for each record
        /// 
        /// One user can have multiple contact informations hence we
        /// add this id as a unique id per record
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
