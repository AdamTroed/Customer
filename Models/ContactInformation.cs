using System;
using System.ComponentModel.DataAnnotations;

namespace Customer.Models
{
    public class ContactInformation
    {
        /// <summary>
        /// Id - unique identifier for each record
        /// 
        /// One user can have multiple contact informations
        /// </summary>
        public Guid Id { get; set; }

        public int SocialSecurityNumber { get; set; }

        public string EmailAddress { get; set; }

        /// <summary>
        /// Phone number
        /// 
        /// string as it can include country code, e.g. +46
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
