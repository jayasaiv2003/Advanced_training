
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _dbcontext;
        public BookRepository(LibraryDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<Book> createBookAsync(Book book)
        {
            await _dbcontext.Books.AddAsync(book);
            await _dbcontext.SaveChangesAsync();
            return book;
        }

        public async Task<bool> deleteBookAsync(int id)
        {
            if (id<=0) return false;
            var book = _dbcontext.Books.Where(n => n.BookId == id).FirstOrDefaultAsync().Result;
            _dbcontext.Books.Remove(book);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Book>> GetAll()
        {
            return await _dbcontext.Books.Include(b => b.Author).ToListAsync();
        }

        public async Task<Book> getbybookidAsync(int id)
        {
           return await _dbcontext.Books.Where(n => n.BookId == id).Include(b => b.Author).FirstOrDefaultAsync();  
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            var existing = await _dbcontext.Books.Where(n => n.BookId == book.BookId).FirstOrDefaultAsync();
            if (existing == null)
            {
                return null;
            }
            existing.Title = book.Title;
            existing.Genre = book.Genre;
            existing.AuthorId=book.AuthorId;
            await _dbcontext.SaveChangesAsync();
            return existing;

        }
    }
}
