using Assigment_PRN222_01.Models;
using Assigment_PRN222_01.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assigment_PRN222_01.Controllers
{
    public class ArticleController : Controller
    {
        private readonly FunewsManagementContext _context;
        private readonly ILogger<ArticleController> _logger;
        private readonly ArticleService _articleService;
        private readonly EmailService _emailService;
        public ArticleController(FunewsManagementContext context, ILogger<ArticleController> logger, ArticleService articleService, EmailService emailService)
        {
            _context = context;
            _logger = logger;
            _articleService = articleService;
            _emailService = emailService;
        }

        // GET: ArticleController
        public ActionResult View()
        {
            var article = _context.NewsArticles.ToList();
            return View(article);
        }
        public ActionResult sort()
        {
            var sortedList = _context.NewsArticles
                            .OrderBy(x => x.NewsTitle) // Sắp xếp tăng dần
                            .ToList();
            return View(sortedList);
        }
        public IActionResult Search(string keyword)
        {
            var list = _articleService.searchArticle(keyword);
            return View(list);
        }
        // GET: ArticleController/Details/5
        public ActionResult Details(string id)
        {
            var article = _context.NewsArticles.FirstOrDefault(m => m.NewsArticleId.Equals(id));
            
            return View(article);
        }

        // GET: ArticleController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View("~/Views/Article/CreateArticle.cshtml");
        }

        // POST: ArticleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateArticle(NewsArticle articlee)
        {
            if (ModelState.IsValid)
            {
                _context.NewsArticles.Add(articlee);
                _context.SaveChanges();
                _emailService.SendEmail();
                return RedirectToAction(nameof(View));
            }
            return View(articlee);
        }

        // GET: ArticleController/Edit/5
        public ActionResult Edit(string id)
        {
            var article = _context.NewsArticles.FirstOrDefault(m => m.NewsArticleId.Equals(id));
            return View(article);
        }

        // POST: ArticleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, NewsArticle article)
        {
            if (article.NewsArticleId.Equals(id))
            {
                _context.NewsArticles.Update(article);
                _context.SaveChanges();
                return RedirectToAction(nameof(View));
            }
            return View();
        }

        // GET: ArticleController/Delete/5
        public ActionResult Delete(string id)
        {
            var article = _context.NewsArticles.FirstOrDefault(m => m.NewsArticleId.Equals(id));
            return View(article);
        }

        // POST: ArticleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletee(string NewsArticleId)
        {
            var article = _context.NewsArticles.FirstOrDefault(m => m.NewsArticleId.Equals(NewsArticleId));
            _context.NewsArticles.Remove(article);
            _context.SaveChanges();
            return RedirectToAction(nameof(View));
        }
    }
}
