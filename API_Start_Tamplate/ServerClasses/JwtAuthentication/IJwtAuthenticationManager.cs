using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Start_Template
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
}
