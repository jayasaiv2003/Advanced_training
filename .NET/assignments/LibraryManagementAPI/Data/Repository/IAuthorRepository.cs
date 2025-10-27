namespace LibraryManagementAPI.Data.Repository
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAll();

        Task<Author> getbyidAsync(int id);

        //Task<Author> getbynameAsync(string name);

        Task<Author> createAsync(Author author);

        Task<bool> deleteAuthorAsync(int id);

        Task<Author> UpdateAsync(Author author);

    }
}
