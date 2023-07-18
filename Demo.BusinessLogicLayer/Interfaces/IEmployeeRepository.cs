using Demo.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.Interfaces
{
    public interface IEmployeeRepository : IGenaricRepository<Employee>
    {
        IQueryable<Employee>GetEmployeesByDepartmentName(string departmentName);

        IQueryable<Employee> GetEmployeesByName( string name);
    }
}
