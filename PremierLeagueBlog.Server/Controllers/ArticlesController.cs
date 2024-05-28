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
        // Return the seven most recent articles
        [HttpGet("Seven")]
        public async Task<ActionResult<IEnumerable<Article>>> GetSevenRecentArticles()
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

        // PUT: api/Articles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticle(int id, Article article)
        {
            if (id != article.Id)
            {
                return BadRequest();
            }

            _context.Entry(article).State = EntityState.Modified;

            await _context.SaveChangesAsync();
   

            return NoContent();
        }

        // DELETE: api/Articles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var article = await _context.Articles.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
