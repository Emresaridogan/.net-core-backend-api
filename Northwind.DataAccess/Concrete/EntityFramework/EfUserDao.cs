using Northwind.Core.DataAccess.EntityFramework;
using Northwind.Core.Entities.Concrete;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfUserDao : EfEntityRepositoryBase<User, NorthwindContext>, IUserDao
    {
        public List<OperationClaim> GetOperationClaims(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim {Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }

        public List<OperationClaim> GetOperationClaims()
        {
            using (var context = new NorthwindContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}
