using Northwind.Core.DataAccess;
using Northwind.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Abstract
{
    public interface IUserDao : IEntityRepository<User>
    {
        List<OperationClaim> GetOperationClaims(User user);
        List<OperationClaim> GetOperationClaims();

    }
}
