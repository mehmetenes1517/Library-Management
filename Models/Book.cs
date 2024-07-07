using System.ComponentModel.DataAnnotations;

namespace LibManagement.Models{
    public class Book{
        [Key]
        public int BookId{set;get;}
        public string? Name{set;get;}
        public string? Writer{set;get;}
        public string? Type{set;get;}
        public DateTime? Year{set;get;}
    }
}