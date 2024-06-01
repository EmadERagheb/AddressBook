using AddressBook.Domain.DTOs.Person;
using AddressBook.Domain.Models;
using AutoMapper;


namespace AddressBook.Data.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region PersonDTO
            CreateMap<Person, GetPagingPersonsDTO>()
        .ForMember(q => q.Department, o => o.MapFrom(s => s.Department.Name))
        .ForMember(q => q.Job, o => o.MapFrom(s => s.Department.Job.Name));

            CreateMap<Person, GetPersonDTO>()
        .ForMember(q => q.Department, o => o.MapFrom(s => s.Department.Name))
        .ForMember(q => q.Job, o => o.MapFrom(s => s.Department.Job.Name));
            CreateMap<Person, PostPersonDTO>().ReverseMap();
            CreateMap<Person, PutPersonDTO>();
            #endregion
        }
    }
}
