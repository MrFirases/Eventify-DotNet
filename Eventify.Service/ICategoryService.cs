using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventify.Data.Models;
using Service.Pattern;

namespace Eventify.Service
{
    public interface ICategoryService :IMyServiceGeneric<Category>
    {
         IEnumerable<Category> getAllCategory();
        Category getCategoryById(int idCategory);
        IEnumerable<Category> getCategoryByName();
        Boolean addCategory(Category cateegory);
        Boolean deteCategory(int idCategory);
        Boolean updateCategory(Category category);
        int categoryPerUser(int idCategory);
        List<Tuple<int, int>> mostUsedCategory();
        int totalCategoryUsers();
        void twitterCategory();

    }
}
