using System;
using System.Collections.Generic;
using System.Linq;

namespace Customer.Models
{
    /// <summary>
    /// Fake DB
    /// </summary>
    public class MockContactInformationData
    {
        private List<ContactInformation> contactInformations = new List<ContactInformation>()
        {
            new ContactInformation()
            {
                Id = Guid.NewGuid(),
                SocialSecurityNumber = 1234567890,
                EmailAddress = "adam.troed.carl@hotmail.se",
                PhoneNumber = "+46111222444",
            },
            new ContactInformation()
            {
                Id = Guid.NewGuid(),
                SocialSecurityNumber = 1234567890,
                EmailAddress = "test@test.com",
                PhoneNumber = "0701113334",
            }
        };

        public void AddContactInformation(ContactInformation contactInformation)
        {
            contactInformation.Id = Guid.NewGuid();
            contactInformations.Add(contactInformation);
        }

        public void DeleteContactInformation(ContactInformation contactInformation)
        {
            contactInformations.Remove(contactInformation);
        }

        public ContactInformation UpdateContactInformation(ContactInformation contactInformation)
        {
            var existingContactInformation = GetContactInformation(contactInformation.Id);
            existingContactInformation.SocialSecurityNumber = contactInformation.SocialSecurityNumber;
            existingContactInformation.EmailAddress = contactInformation.EmailAddress;
            existingContactInformation.PhoneNumber = contactInformation.PhoneNumber;

            return existingContactInformation;
        }

        public ContactInformation GetContactInformation(Guid id)
        {
            return contactInformations.SingleOrDefault(x => x.Id == id);
        }

        public List<ContactInformation> GetAllContactInformation()
        {
            return contactInformations;
        }
    }
}
