using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementAPI.Data
{
    public class Author
    {

        

        public int AuthorID { get; set; }

        public string Name { get; set; }
        public string Country { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
