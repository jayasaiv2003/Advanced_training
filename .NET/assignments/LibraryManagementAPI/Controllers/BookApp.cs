using LibraryManagementAPI.Data;
using LibraryManagementAPI.Data.Repository;
using LibraryManagementAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace LibraryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookApp : Controller
    {
        private readonly IAuthorRepository _authorRepository;

        public BookApp(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;

        }
        [HttpGet]
        [Route("GetAthors")]

        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _authorRepository.GetAll();
            return Ok(authors);
        }
        [HttpGet]
        [Route("getauthorbyid")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _authorRepository.getbyidAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }
        //[HttpGet]
        //[HttpGet("GetAuthorByName/{name}")] 
        //public async Task<IActionResult> GetAuthorByName(string name)
        //{
        //    var author = await _authorRepository.getbynameAsync(name);
        //    if (author == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(author);

        //}
        [HttpPost]
        [Route("CreateAuthor")]

        public async Task<IActionResult> CreateAuthor([FromBody] AuthorDTO model)
        {
            var a = new Author
            {
                Name=model.Name,
                Country=model.Country
            };

            if (model==null)
            {
                return BadRequest();
            }
            var b= await _authorRepository.createAsync(a);
            if (b==null) return NotFound();
            return Ok(b);
        }

        [HttpDelete]
        [Route("DeleteAuthor/{id}")]    

        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _authorRepository.getbyidAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            bool result = await _authorRepository.deleteAuthorAsync(id);
            return Ok(author);
        }

        [HttpPut]
        [Route("UpdateAuthor")]
        public async Task<ActionResult<Author>> UpdateAuthor([FromBody] AuthorDTO model)
        {
            if (model == null||model.AuthorID<=0) return BadRequest();
            var existingAuthor = await _authorRepository.getbyidAsync(model.AuthorID);
            if(existingAuthor==null) return NotFound();
            existingAuthor.Name=model.Name;
            existingAuthor.Country=model.Country;
            //existingAuthor.
            var updatedAuthor = await _authorRepository.UpdateAsync(existingAuthor);
            return Ok(updatedAuthor);
        }
    }
}
