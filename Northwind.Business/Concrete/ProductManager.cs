using Northwind.Business.Abstract;
using Northwind.Business.Constants;
using Northwind.Core.Utilities.Results;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDao _productDao;

        public ProductManager(IProductDao productDao)
        {
            _productDao = productDao;
        }

        public IResult AddProduct(Product product)
        {
            _productDao.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult DeleteProduct(Product product)
        {
            _productDao.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<Product> GetProductById(int productId)
        {
            try
            {
                return new SuccessDataResult<Product>(_productDao.Get(p => p.ProductId == productId));

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IDataResult<List<Product>> GetProducts()
        {
            return new SuccessDataResult<List<Product>>(_productDao.GetList().ToList());
        }

        public IDataResult<List<Product>> GetProductsByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDao.GetList(p => p.CategoryId == categoryId).ToList());
        }

        public IResult UpdateProduct(Product product)
        {
            _productDao.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
