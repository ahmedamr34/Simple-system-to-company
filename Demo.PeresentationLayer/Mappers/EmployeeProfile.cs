using AutoMapper;
using Demo.DataAccessLayer.Entities;
using Demo.PeresentationLayer.Models;

namespace Demo.PeresentationLayer.Mappers
{
    public class EmployeeProfile :Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeViewModel , Employee>().ReverseMap(); 
        }
    }
}
