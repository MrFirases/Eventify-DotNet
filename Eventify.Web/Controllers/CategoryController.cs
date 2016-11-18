using Eventify.Data.Models;
using Eventify.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eventify.Web.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService categoryService = null;

        public CategoryController()
        {
            categoryService = new CategoryService();
        }

        // GET: Category
        public ActionResult Index()
        {
            IEnumerable<Category> listCategory = categoryService.getAllCategory();
            //ViewBag.listOfCategory = listCategory;
            categoryService.commit();

            return View(listCategory);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Category category = categoryService.GetById(id);
                return View(category);
            }
            
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                categoryService.Add(category);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            Category category = categoryService.GetById(id);
            if (category.Equals(null)) { return RedirectToAction("Index"); }
            
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Category category = categoryService.GetById(id);
                
                System.Diagnostics.Debug.WriteLine("wiw" + category.id);
                category.categoryName = Request.Form["categoryName"];
                categoryService.updateCategory(category);
                categoryService.commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            Category category = categoryService.GetById(id);
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                categoryService.deteCategory(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
