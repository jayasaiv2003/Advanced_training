namespace LibraryManagementAPI.Data.Repository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAll();
        Task<Book> getbybookidAsync(int id);
        //Task<Book> getbynameAsync(string name);
        //Task<Book> getbynameAsync(string propertyName, string value);
        Task<Book> createBookAsync(Book book);
        Task<Book> UpdateBookAsync(Book book);
        Task<bool> deleteBookAsync(int id);
    }
}
