using System.Collections.Generic;
using Viridian.Demo.Informix.DataAccess;

namespace Viridian.Demo.Informix.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        List<Users> FindAll();

        List<Users> FindByStatus(string status);
        
        Users Insert(Users model);

        Users Update(Users model);
    }
}