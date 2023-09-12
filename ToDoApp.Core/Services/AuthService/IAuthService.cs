using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Core.Services.AuthService
{
    public interface IAuthService
    {
        string GenerateJwtToken(string name, string email);
        string ComputeSha256Hash(string password);
    }
}
