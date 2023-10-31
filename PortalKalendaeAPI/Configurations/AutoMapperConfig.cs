using AutoMapper;
using Core.Collections;
using Core.Dtos;
using Microsoft.Graph.Models;

namespace PortalKalendaeAPI.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UserDto, UserCollectionDto>().ReverseMap();
            CreateMap<UserCollection, UserCollectionDto>().ReverseMap();
            CreateMap<BDProfileLevelCollection, BDProfileLevelDto>().ReverseMap();
            CreateMap<BDProfileLevelCollection, BDProfileLevelOptionsDto>().ReverseMap();
            CreateMap<BDProfileLevelCollection, BDProfileLevelInsertDto>().ReverseMap();
            CreateMap<BDProfileLevelCollection, BDProfileLevelUpdateDto>().ReverseMap();

            CreateMap<Group, MemberOfDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<Presence, PresenceDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Activity, opt => opt.MapFrom(src => src.Activity))
                .ForMember(dest => dest.Availability, opt => opt.MapFrom(src => src.Availability));

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.BusinessPhones, opt => opt.MapFrom(src => src.BusinessPhones))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.GivenName, opt => opt.MapFrom(src => src.GivenName))
                .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitle))
                .ForMember(dest => dest.Mail, opt => opt.MapFrom(src => src.Mail))
                .ForMember(dest => dest.MobilePhone, opt => opt.MapFrom(src => src.MobilePhone))
                .ForMember(dest => dest.OfficeLocation, opt => opt.MapFrom(src => src.OfficeLocation))
                .ForMember(dest => dest.PreferredLanguage, opt => opt.MapFrom(src => src.PreferredLanguage))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.UserPrincipalName, opt => opt.MapFrom(src => src.UserPrincipalName))
                .ForMember(dest => dest.Presence, opt => opt.Ignore())
                .ForMember(dest => dest.MemberOf, opt => opt.Ignore());
        }
    }
}

