using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using webAPi.Model;
using webAPi.Dtos;

namespace webAPi.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForDetailDto>()              
                 .ForMember(des => des.Age, opt =>
                 {
                     opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                 });
            CreateMap<User, UserListForDto>();                                   
            CreateMap<UserToUpdateDto, User>();
            CreateMap<UserToRegisterDto, User>();
            CreateMap<EmployeeToCreateDto, Employee>();
            CreateMap<EmployeeDetailDto, Employee>();
            CreateMap<EmployeeToUpdateDto, Employee>();
            CreateMap<InsertWorkLogDto, WorkLog>();
        }
    
    }
}
