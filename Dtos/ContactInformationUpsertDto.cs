using Customer.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Customer.Dtos
{
    public class ContactInformationUpsertDto
    {
        [Required]
        [Lenght(10, 12, ErrorMessage = "Invalid lenght of social security number. It has to be between 10-12 numbers.")]
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
