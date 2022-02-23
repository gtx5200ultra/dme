using AutoMapper;
using Phonebook.Contracts;

namespace Phonebook.EF
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PhonebookContext.UserDb, PhonebookUser>()
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Pictures, opt => opt.MapFrom(src => src.Picture))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));

            CreateMap<PhonebookContext.PictureDb, PhonebookPicture>()
                .ForMember(dest => dest.Large, opt => opt.MapFrom(src => src.Large))
                .ForMember(dest => dest.Medium, opt => opt.MapFrom(src => src.Medium))
                .ForMember(dest => dest.Thumbnail, opt => opt.MapFrom(src => src.Thumbnail));
        }
    }
}
