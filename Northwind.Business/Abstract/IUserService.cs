using Northwind.Core.Entities.Concrete;
using Northwind.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetOperationClaims(User user);
        List<OperationClaim> GetOperationClaims();

        User GetUserByMail(string email);
        IDataResult<List<User>> GetUsers();

        IResult AddUser(User user);
        IResult DeleteUser(User user);
        IResult UpdateUser(User user);

    }
}
