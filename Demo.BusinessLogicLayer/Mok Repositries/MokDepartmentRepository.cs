using Demo.BusinessLogicLayer.Interfaces;
using Demo.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.Mok_Repositries
{
    public class MokDepartmentRepository : IDepartmentRepository
    {
        public Task<int> Add(Department item)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Department item)
        {
            throw new NotImplementedException();
        }

        public Task<Department> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Department>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Department item)
        {
            throw new NotImplementedException();
        }
    }
}
