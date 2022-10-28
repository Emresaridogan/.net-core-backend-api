using Autofac;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.Core.Utilities.Security.Jwt;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDao>().As<IProductDao>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDao>().As<ICategoryDao>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDao>().As<IUserDao>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();    
        }
    }
}
