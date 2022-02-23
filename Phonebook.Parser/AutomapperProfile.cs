using System;
using AutoMapper;
using Phonebook.EF;
using Phonebook.Parser.Models;

namespace Phonebook.Parser
{
    public class PhonebookJsonToDbProfile : Profile
    {
        public PhonebookJsonToDbProfile()
        {
            CreateMap<Result, PhonebookContext.UserDb>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.login.uuid)))
                .ForMember(dest => dest.LoginDb, opt => opt.MapFrom(src => src.login))
                .ForMember(dest => dest.LocationDb, opt => opt.MapFrom(src => src.location))
                .ForMember(dest => dest.Picture, opt => opt.MapFrom(src => src.picture))
                .ForMember(dest => dest.IdentityCard, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.dob.date))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.name.first))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.name.last))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.name.title))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.gender))
                .ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.nat))
                .ForMember(dest => dest.Registered, opt => opt.MapFrom(src => src.registered.date))
                .ForMember(dest => dest.UsersPhonesDb, opt => opt.MapFrom(src => new[]
                {
                        new PhonebookContext.UsersPhonesDb
                        {
                            Phone = new PhonebookContext.PhoneDb
                            {
                                Number = src.phone,
                                Type = 1
                            }
                        },
                        new PhonebookContext.UsersPhonesDb
                        {
                            Phone = new PhonebookContext.PhoneDb
                            {
                                Number = src.cell,
                                Type = 2,
                            }
                        },
                }));

            CreateMap<Picture, PhonebookContext.PictureDb>()
                .ForMember(dest => dest.Large, opt => opt.MapFrom(src => src.large))
                .ForMember(dest => dest.Thumbnail, opt => opt.MapFrom(src => src.thumbnail))
                .ForMember(dest => dest.Medium, opt => opt.MapFrom(src => src.medium));

            CreateMap<Id, PhonebookContext.IdentityCardDb>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.value));

            CreateMap<Street, PhonebookContext.StreetDb>()
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.number))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name));

            CreateMap<Timezone, PhonebookContext.TimezoneDb>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.description))
                .ForMember(dest => dest.Offset, opt => opt.MapFrom(src => src.offset));

            CreateMap<Location, PhonebookContext.LocationDb>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.city))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.country))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.coordinates.latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.coordinates.longitude))
                .ForMember(dest => dest.Postcode, opt => opt.MapFrom(src => src.postcode))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.state))
                .ForMember(dest => dest.StreetDb, opt => opt.MapFrom(src => src.street))
                .ForMember(dest => dest.TimezoneDb, opt => opt.MapFrom(src => src.timezone));

            CreateMap<Login, PhonebookContext.LoginDb>()
                .ForMember(dest => dest.Md5, opt => opt.MapFrom(src => src.md5))
                .ForMember(dest => dest.Salt, opt => opt.MapFrom(src => src.salt))
                .ForMember(dest => dest.Sha1, opt => opt.MapFrom(src => src.sha1))
                .ForMember(dest => dest.Sha256, opt => opt.MapFrom(src => src.sha256))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.username))
                .ForMember(dest => dest.Uuid, opt => opt.MapFrom(src => Guid.Parse(src.uuid)));
        }
    }
}
