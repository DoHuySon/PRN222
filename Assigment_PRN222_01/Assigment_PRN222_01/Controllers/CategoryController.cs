using Assigment_PRN222_01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assigment_PRN222_01.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly FunewsManagementContext _context;

        public CategoryController(ILogger<CategoryController> logger, FunewsManagementContext context)
        {
            _logger = logger;
            _context = context;
        }
        // GET: CategoryController
        public ActionResult View()
        {
            var categoryyy = _context.Categories.ToList();
            return View(categoryyy);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var categoryy = _context.Categories.FirstOrDefault(m => m.CategoryId == id);
            return View(categoryy);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View("~/Views/Category/Create.cshtml");
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(View));
            }
            return View();
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _context.Categories.FirstOrDefault(m => m.CategoryId == id);
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,  Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Update(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(View));
            }
            return View();
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var caategory = _context.Categories.FirstOrDefault(m => m.CategoryId == id);
            _context.Categories.Remove(caategory);
            _context.SaveChanges();
            return RedirectToAction(nameof(View));
        }

        // POST: CategoryController/Delete/5
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var caategory = _context.Categories.FirstOrDefault(m => m.CategoryId == id);
            _context.Categories.Remove(caategory);
            _context.SaveChanges();
            return View();
        }*/
    }
}
