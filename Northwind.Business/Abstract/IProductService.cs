using Northwind.Core.Utilities.Results;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Abstract
{
    public interface IProductService 
    {
        IDataResult<Product> GetProductById(int productId);
        IDataResult<List<Product>> GetProducts();
        IDataResult<List<Product>> GetProductsByCategory(int categoryId);

        IResult AddProduct(Product product);

        IResult DeleteProduct(Product product);
        IResult UpdateProduct(Product product);
    }
}
