using Refactor1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor1.Service
{
    public interface IServiceManager
    {
        Task<User> Authenticate(string email, string password);
    }
}
