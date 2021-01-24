using AutoMapper;
using ContactManagement.API.APIModels;
using ContactManagement.Core;
using ContactManagement.Data.Entity;

namespace ContactManagement.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ContactDTO, ContactAPIModel>()
                .ForMember(s => s.FirstName, opt => opt.MapFrom(o => o.FirstName))
                .ForMember(s => s.LastName, opt => opt.MapFrom(o => o.LastName))
                .ForMember(s => s.Status, opt => opt.MapFrom(o => o.Status))
                .ForMember(s => s.IsFavourate, opt => opt.MapFrom(o => o.IsFavourate))
                .ForMember(s => s.Company, opt => opt.MapFrom(o => o.Company));

            CreateMap<ContactNumberDTO, ContactNumberAPIModel>()
                .ForMember(s => s.Number, opt => opt.MapFrom(o => o.Number))
                .ForMember(s => s.Type, opt => opt.MapFrom(o => o.NumberType));

            CreateMap<ContactAPIModel, ContactDTO>()
                .ForMember(s => s.FirstName, opt => opt.MapFrom(o => o.FirstName))
                .ForMember(s => s.LastName, opt => opt.MapFrom(o => o.LastName))
                .ForMember(s => s.Status, opt => opt.MapFrom(o => o.Status))
                .ForMember(s => s.IsFavourate, opt => opt.MapFrom(o => o.IsFavourate))
                .ForMember(s => s.Company, opt => opt.MapFrom(o => o.Company));

            CreateMap<ContactNumberAPIModel, ContactNumberDTO>()
                .ForMember(s => s.Number, opt => opt.MapFrom(o => o.Number))
                .ForMember(s => s.NumberType, opt => opt.MapFrom(o => o.Type));

            CreateMap<ContactDTO, Contact>()
                .ForMember(s => s.FirstName, opt => opt.MapFrom(o => o.FirstName))
                .ForMember(s => s.LastName, opt => opt.MapFrom(o => o.LastName))
                .ForMember(s => s.StatusId, opt => opt.MapFrom(o => (int)o.Status))
                .ForMember(s => s.IsFavourate, opt => opt.MapFrom(o => o.IsFavourate))
                .ForMember(s => s.Company, opt => opt.MapFrom(o => o.Company));

            CreateMap<ContactNumberDTO, ContactNumber>()
                .ForMember(s => s.Number, opt => opt.MapFrom(o => o.Number))
                .ForMember(s => s.NumberType, opt => opt.MapFrom(o => (ContactNumberTypeDTO)o.NumberType));

            CreateMap<Contact, ContactDTO>()
                .ForMember(s => s.FirstName, opt => opt.MapFrom(o => o.FirstName))
                .ForMember(s => s.LastName, opt => opt.MapFrom(o => o.LastName))
                .ForMember(s => s.Status, opt => opt.MapFrom(o => o.StatusId))
                .ForMember(s => s.IsFavourate, opt => opt.MapFrom(o => o.IsFavourate))
                .ForMember(s => s.Company, opt => opt.MapFrom(o => o.Company));

            CreateMap<ContactNumber, ContactNumberDTO>()
                .ForMember(s => s.Number, opt => opt.MapFrom(o => o.Number))
                .ForMember(s => s.NumberType, opt => opt.MapFrom(o => o.NumberType));
        }
    }
}