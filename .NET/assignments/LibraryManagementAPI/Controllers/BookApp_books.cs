using LibraryManagementAPI.Data;
using LibraryManagementAPI.Data.Repository;
using LibraryManagementAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAPI.Controllers
{
    public class BookApp_books : Controller
    {
        public readonly IBookRepository _IBookRepository;
        public BookApp_books(IBookRepository IBookRepository)
        {
            _IBookRepository = IBookRepository;
        }

        [HttpGet]
        [Route("getbooks")]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _IBookRepository.GetAll();
            return Ok(books);
        }

        [HttpGet]
        [Route("getbookbyid")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _IBookRepository.getbybookidAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        [Route("createbook")]
        public async Task<IActionResult> CreateBook([FromBody] BookDTO book)
        {
            var a = new Book {
            Title= book.Title,
            Genre= book.Genre,
            AuthorId=book.AuthorId
            };

            if (book == null)
            {
                return BadRequest();
            }
            var b = await _IBookRepository.createBookAsync(a);
            return Ok(b);
        }

        [HttpPut]
        [Route("updatebook")]
        public async Task<IActionResult> UpdateBook([FromBody] BookDTO book)
        {
            var a = new Book
            {
                BookId= book.BookId,
                Title=book.Title,
                Genre=book.Genre,
                AuthorId= book.AuthorId,
            };

            if (book == null)
            {
                return BadRequest();
            }
            var b = await _IBookRepository.UpdateBookAsync(a);
            return Ok(b);
        }

        [HttpDelete]
        [Route("deletebook")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _IBookRepository.deleteBookAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
