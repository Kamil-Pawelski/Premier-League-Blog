using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PremierLeagueBlog.Server.Data;
using PremierLeagueBlog.Server.Data.Models;

namespace PremierLeagueBlog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public ArticlesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Articles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticle(int id)
        {
            var article = await _context.Articles.FindAsync(id);

            if(article == null)
            {
                return NotFound();
            }

            return article;
        }

        // GET: api/Articles/Seven
        [HttpGet("Seven")]
        public async Task<ActionResult<IEnumerable<Article>>> GetSevenLatestArticles()
        {
            var articleCount = await _context.Articles.CountAsync();

            if (articleCount > 7) {
                articleCount = 7;
            }
            var articles = await _context.Articles
                .OrderByDescending(a => a.Date)
                .Take(articleCount)
                .ToListAsync();

            return Ok(new
            {
                TotalCount = articleCount,
                Articles = articles
            });
        }
    }
}
