using FUNewsManageSystem.Models.NewsArticle;
using ServiceLayer.NewsArticle;

namespace FUNewsManageSystem.Pages
{
    public class IndexModel(INewsArticleService newsArticleService, IMapper mapper) : PageModel
    {
        public IEnumerable<NewsArticleViewModel> NewsArticles { get; set; } = null!;

        public async Task OnGetAsync()
        {
            var articleDtos = await newsArticleService.GetActiveNewsArticlesAsync();
            NewsArticles = mapper.Map<IEnumerable<NewsArticleViewModel>>(articleDtos);
        }
    }
}
