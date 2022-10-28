using Northwind.Core.Utilities.Results;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<Category> GetCategoryById(int categoryId);
        IDataResult<List<Category>> GetCategories();
        
        IResult AddCategory(Category category);
        IResult UpdateCategory(Category category);
        IResult DeleteCategory(Category category);
    }
}
