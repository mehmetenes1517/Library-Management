using LibManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibManagement.Data.Main{
    public class LibraryContext:DbContext{
        public DbSet<User> Users=>Set<User>();
        public DbSet<Book> Books=>Set<Book>();
        public LibraryContext(DbContextOptions<LibraryContext> options):base(options){
            
        }
    }
}