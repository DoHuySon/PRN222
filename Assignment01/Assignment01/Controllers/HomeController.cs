using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment01.Models;

namespace Assignment01.Controllers;

public class HomeController : Controller
{
    private readonly FunewsManagementContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, FunewsManagementContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var articles = _context.NewsArticles.ToList();
        return View(articles);
    }
    public ActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(NewsArticle article)
    {
        if (ModelState.IsValid)
        {
            _context.Add(article);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(article);
    }
    public IActionResult Edit(String? id)
    {
        if(id == null)
        {
            return NotFound();
        }
        var articles = _context.NewsArticles.FirstOrDefault(m => m.NewsArticleId.Equals(id));
        if (articles == null)
        {
            return NotFound();
        }
        return View(articles);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, NewsArticle article)
    {
        if (!id.Equals(article.NewsArticleId))
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            _context.Update(article);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(article);
    }
    public IActionResult Details(String? id)
    {
        if(id == null)
        {
            return NotFound();
        }
        var articles = _context.NewsArticles.FirstOrDefault(m => m.NewsArticleId.Equals(id));

        if(articles == null)
        {
            return NotFound();
        }
        return View(articles);
    }
    public ActionResult Delete(String? id)
    {
        if(id == null)
        {
            return NotFound();
        }
        var acticles = _context.NewsArticles.FirstOrDefault(m => m.NewsArticleId.Equals(id));
        _context.NewsArticles.Remove(acticles);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));

    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Login()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
