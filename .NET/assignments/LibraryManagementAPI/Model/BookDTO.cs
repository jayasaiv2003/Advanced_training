using LibraryManagementAPI.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementAPI.Model
{
    public class BookDTO
    {
        
        public int BookId { get; set; }
        public string Title { get; set; }

        public string Genre { get; set; }

        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }

        //public Author? Author { get; set; }

    }
}
