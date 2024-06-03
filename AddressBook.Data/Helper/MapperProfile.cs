using AddressBook.Domain.DTOs.Departments;
using AddressBook.Domain.DTOs.Job;
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
        .ForMember(q => q.Job, o => o.MapFrom(s => s.Department.Job.Name))
        .ForMember(q => q.JobId, o => o.MapFrom(s => s.Department.Job.Id));
            CreateMap<Person, PostPersonDTO>().ReverseMap();
            CreateMap<Person, PutPersonDTO>().ReverseMap();
            #endregion
            #region Job
            CreateMap<GetJobsDTO, Job>().ReverseMap();
            #endregion
            #region Department
            CreateMap<GetDepartmentsDTO,Department>().ReverseMap(); 
            #endregion
        }
    }
}
