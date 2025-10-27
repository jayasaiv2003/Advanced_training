using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryManagementAPI.Data
{
    public class Book
    {
        //BookId,Title,Genre,AuthorId, Author? Author

        public int BookId { get; set; }
        public string Title { get; set; }

        public string Genre { get; set; }

        [ForeignKey("AuthorId")]

        public int AuthorId { get; set; }

        [JsonIgnore]
        public Author? Author { get; set; }
    }
}
