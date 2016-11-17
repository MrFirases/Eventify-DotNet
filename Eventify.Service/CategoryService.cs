using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventify.Data.Infrastructure;
using Eventify.Data.Models;
using Service.Pattern;

namespace Eventify.Service
{
    public class CategoryService : MyServiceGeneric<Category>,ICategoryService
    {

        private static IDataBaseFactory dbfac = new DataBaseFactory();

        private static IUnitOfWork itw = new UnitOfWork(dbfac);

        public CategoryService() : base(itw)
        {

        }

        public bool addCategory(Category cateegory)
        {
            
            try
            {

                itw.getRepository<Category>().Add(cateegory);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
          
            
            
        }

        public bool deteCategory(int idCategory)
        {
            try
            {

             Category categorie=   itw.getRepository<Category>().GetById(idCategory);
                itw.getRepository<Category>().Delete(categorie);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        public IEnumerable<Category> getAllCategory()
        {
            return itw.getRepository<Category>()
                .GetMany();
        }

        public IEnumerable<Category> getCategoryById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> getCategoryByName()
        {
            throw new NotImplementedException();
        }

        public bool updateCategory(Category category)
        {
            try
            {
              //  System.Diagnostics.Debug.WriteLine("wiw2" + category.id);
               
                itw.getRepository<Category>().Update(category);
                
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }







    }



}
