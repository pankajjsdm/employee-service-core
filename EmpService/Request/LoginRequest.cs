using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace EmpService.Request
{
    public class LoginRequest
    {
        [DataMember(IsRequired =true)]
        public string Username { get; set; }
        [DataMember(IsRequired = true)]
        public string Password { get; set; }
    }
}
