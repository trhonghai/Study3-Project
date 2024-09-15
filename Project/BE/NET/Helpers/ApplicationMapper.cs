using AutoMapper;
using NET.Data;
using NET.Dto;
using NET.GenericRepository;

namespace NET.Helpers
{
    public class Application
    {
        public class ApplicationMapper : Profile
        {
            public ApplicationMapper()
            {
                CreateMap<RegisterDto, ApplicationUser>()
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));



            }

        }
    }

}