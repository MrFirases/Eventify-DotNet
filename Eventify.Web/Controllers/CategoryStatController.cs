using Eventify.Data.Models;
using Eventify.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eventify.Web.Controllers
{
    public class CategoryStatController : Controller
    {
        ICategoryService categoryService = null;
        public CategoryStatController()
        {

            categoryService = new CategoryService();

        }
            // GET: CategoryStat
        public ActionResult Index()
        {

            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            System.Diagnostics.Debug.WriteLine("wiw  Begin list ");


            List<Tuple<int, int>> Favcat = categoryService.mostUsedCategory();

            List<Category> catList = new List<Category>();
            List<int> ctatList = new List<int>();
            List<Tuple<string, int>> StatList = new List<Tuple<string, int>>();
            foreach (Tuple<int, int> elemnt in Favcat)
            {
                System.Diagnostics.Debug.WriteLine("id categorie :" + elemnt.Item1 + "    Nber USers =" + elemnt.Item2);

                Category category = categoryService.getCategoryById(elemnt.Item1);
                if (category != null)
                {
                    string satatString = category.categoryName + " ID : " + category.id;
                    System.Diagnostics.Debug.WriteLine(satatString);
                    StatList.Add(new Tuple<string, int>(satatString,elemnt.Item1));
                }

               



            }
            ViewBag.categstat = StatList;
            System.Diagnostics.Debug.WriteLine("wiw  End list ");
            //verif
            foreach (Tuple<string, int> elem in StatList)
            {
                System.Diagnostics.Debug.WriteLine(elem.Item1+"     "+elem.Item2);
            }

            return View(StatList);
        }


      
    }
}