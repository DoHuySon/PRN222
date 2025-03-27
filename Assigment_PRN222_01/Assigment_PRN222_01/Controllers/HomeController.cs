using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assigment_PRN222_01.Models;
using Microsoft.AspNetCore.Authorization;
using Assigment_PRN222_01.Service;

namespace Assigment_PRN222_01.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly FunewsManagementContext _context;
    private readonly ArticleService _articleService;
    public HomeController(ILogger<HomeController> logger, FunewsManagementContext context, ArticleService articleService)
    {
        _logger = logger;
        _context = context;
        _articleService = articleService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult NewsArticleLecture()
    {
        var acticle = _context.NewsArticles.ToList().Where(m => m.NewsStatus == true);
        return View(acticle);
    }
    public IActionResult Search(string keyword)
    {
        var list = _articleService.searchArticle(keyword);
        return View(list);
    }
    public IActionResult DetailsNewArticle(string? id)
    {
        if(id == null)
        {
            return NotFound();
        }
        var article = _context.NewsArticles.FirstOrDefault(m => m.NewsArticleId.Equals(id));
        if(article == null)
        {
            return NotFound();
        }
        return View(article);
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
