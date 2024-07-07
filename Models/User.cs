using System.ComponentModel.DataAnnotations;

namespace LibManagement.Models{
    public class User{
        [Key]
        public int UserId{set;get;}
        public string? Name{set;get;}
        public string? username{get;set;}
        public string? password{set;get;}
    }
}