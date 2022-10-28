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
    public class CategoryManager : ICategoryService
    {
        private ICategoryDao _categoryDao;

        public CategoryManager(ICategoryDao categoryDao)
        {
            _categoryDao = categoryDao;
        }

        public IResult AddCategory(Category category)
        {
            _categoryDao.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult DeleteCategory(Category category)
        {
            _categoryDao.Delete(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public IDataResult<List<Category>> GetCategories()
        {
            try
            {
                return new SuccessDataResult<List<Category>>(_categoryDao.GetList().ToList());

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IDataResult<Category> GetCategoryById(int categoryId)
        {
            try
            {
                return new SuccessDataResult<Category>(_categoryDao.Get(c => c.CategoryId == categoryId));

            }
            catch (Exception)
            {

                throw;
            }

        }

        public IResult UpdateCategory(Category category)
        {
            _categoryDao.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
