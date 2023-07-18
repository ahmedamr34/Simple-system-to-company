using Demo.BusinessLogicLayer.Interfaces;
using Demo.DataAccessLayer.Contexts;
using Demo.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.Repositries
{
    public class EmployeeRepository : GenaricRepository<Employee>, IEmployeeRepository
    {
        private readonly MVCProject _dbContext;

        //constructor
        public EmployeeRepository(MVCProject dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }


        public IQueryable<Employee> GetEmployeesByDepartmentName(string departmentName)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Employee> GetEmployeesByName(string name)
        =>   _dbContext.employees.Where(E => E.Name.Contains(name));
        
    }
}
