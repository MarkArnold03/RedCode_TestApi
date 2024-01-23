using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedCode_Test.Data;
using RedCode_Test.Models;

namespace RedCode_Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public BookController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Book>>> GetAll()
        {
            return Ok(await _dbContext.Books.ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Book>> GetOne(int id)
        {
            var hero = _dbContext.Books.Find(id);

            if (hero == null)
            {
                return BadRequest("Book not found");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostHero(Book book)
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Books.ToListAsync());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Book>> UpdateBook(Book book, int id)
        {
            var bookToUpdate = await _dbContext.Books.FindAsync(id);

            if (bookToUpdate == null)
            {
                return BadRequest("Book not found");
            }

            bookToUpdate.Title = book.Title;
            bookToUpdate.Writer = book.Writer;
            bookToUpdate.PublishDate = book.PublishDate;

            await _dbContext.SaveChangesAsync();

            return Ok(await _dbContext.Books.ToListAsync());
        }


        [HttpDelete]
        [Route("{id}")]
        //[Route("Delete/{id:int}")]
        public async Task<ActionResult<Book>> Delete(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);

            if (book == null)
            {
                return BadRequest("Book not found");
            }

            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Books.ToListAsync());
        }
    }
}
