using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpService.Repository
{
    public class EmployeeRepository: IDBRepository<Emp>
    {
        readonly EmployeeContext _EmpContext;

        public EmployeeRepository(EmployeeContext context)
        {
            _EmpContext = context;
        }

       

        public IEnumerable<Emp> GetAllEmployee()
        {
            return _EmpContext.Emp.ToList(); 
        }
    }
}
