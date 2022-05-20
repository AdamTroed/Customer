using AutoMapper;
using Customer.Dtos;
using Customer.Models;

namespace Customer.Profiles
{
    public class ContactInformationProfile : Profile
    {
        public ContactInformationProfile()
        {
            CreateMap<ContactInformation, ContactInformationReadDto>();
        }
    }
}
