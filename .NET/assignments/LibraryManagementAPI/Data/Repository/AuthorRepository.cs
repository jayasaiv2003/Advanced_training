
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Data.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext _dbcontext;

        public AuthorRepository(LibraryDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<Author> createAsync(Author author)
        {
            await _dbcontext.Authors.AddAsync(author);
            await _dbcontext.SaveChangesAsync();
            return author;
        }

        public async Task<bool> deleteAuthorAsync(int id)
        {
            if (id<=0) return false;
            var author = _dbcontext.Authors.Where(n => n.AuthorID == id).FirstOrDefaultAsync().Result;  
            _dbcontext.Authors.Remove(author);
            _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Author>> GetAll()
        {
            return await _dbcontext.Authors.Include(b => b.Books).ToListAsync();
        }

        public async Task<Author> getbyidAsync(int id)
        {
            return await _dbcontext.Authors.Where(n => n.AuthorID == id).Include(b => b.Books).FirstOrDefaultAsync();
        }

        //public Task<Author> getbynameAsync(string name)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Author> UpdateAsync(Author author)
        {
            var existingAuthor = await _dbcontext.Authors.Where(n => n.AuthorID == author.AuthorID).FirstOrDefaultAsync();
            if (existingAuthor == null)
            {
                return null;
            }
            existingAuthor.Name = author.Name;
            existingAuthor.Country = author.Country;
            await _dbcontext.SaveChangesAsync();
            return existingAuthor;
        }
    }
}
