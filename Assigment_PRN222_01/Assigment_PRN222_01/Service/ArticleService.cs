using Assigment_PRN222_01.Models;

namespace Assigment_PRN222_01.Service
{
    public class ArticleService
    {
        private readonly FunewsManagementContext _context;
        public ArticleService(FunewsManagementContext context)
        {
            _context = context;
        }
        public List<NewsArticle> searchArticle(string search)
        {
            if (!string.IsNullOrWhiteSpace(search))
            {
                var list = _context.NewsArticles
                    .Where(m => m.NewsTitle.Contains(search.Trim()) || m.Headline.Contains(search.Trim()))
                    .ToList();
                return list;
            }
            else
            {
                var list = _context.NewsArticles.ToList(); // Nếu search rỗng, trả về toàn bộ danh sách
                return list;
            }
            
        }
    }
}
