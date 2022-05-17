using System;
using System.Collections.Generic;
using System.Linq;

namespace Customer.Models
{
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
        public ContactInformation AddContactInformation(ContactInformation contactInformation)
        {
            throw new NotImplementedException();
        }

        public void DeleteContactInformation(ContactInformation contactInformation)
        {
            throw new NotImplementedException();
        }

        public ContactInformation EditContactInformation(ContactInformation contactInformation)
        {
            throw new NotImplementedException();
        }

        public ContactInformation GetContactInformation(Guid id)
        {
            return contactInformations.SingleOrDefault(x => x.Id == id);
        }

        public List<ContactInformation> GetContactInformations()
        {
            return contactInformations;
        }
    }
}
