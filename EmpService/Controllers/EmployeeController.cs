using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpService.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmpService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
      

        private readonly IDBRepository<Emp> _repo;

        public EmployeeController(IDBRepository<Emp> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Emp> Get()
        {            
            return _repo.GetAllEmployee();
        }
    }
}
