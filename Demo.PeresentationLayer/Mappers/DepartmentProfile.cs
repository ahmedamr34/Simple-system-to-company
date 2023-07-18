using AutoMapper;
using Demo.DataAccessLayer.Entities;
using Demo.PeresentationLayer.Models;

namespace Demo.PeresentationLayer.Mappers
{
    public class DepartmentProfile :Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentViewModel, Department>().ReverseMap();
        }

    }
}
