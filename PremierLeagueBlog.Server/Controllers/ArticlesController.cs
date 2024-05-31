using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PremierLeagueBlog.Server.Data;
using PremierLeagueBlog.Server.Data.Models;
using System.Drawing;

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

        // GET: api/Articles 
        // Return ten articles based on current page
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticles(int page = 0)
        {
            var articleCount = await _context.Articles.CountAsync();

            var articles = await _context.Articles
             .OrderByDescending(a => a.Date.Date) 
             .Skip(page * 10)
             .Take(10)
             .ToListAsync();

            return Ok(new
            {
                TotalCount = articleCount,
                Articles = articles
            });
        }

        // PUT: api/Articles/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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

        // POST: api/Articles
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateArticle(Article article)
        {
            if (article == null)
            {
                return BadRequest();
            }

            article.Date = DateTime.Now;
     
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
