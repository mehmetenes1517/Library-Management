using LibManagement.Data.Abstract;
using LibManagement.Models;
namespace LibManagement.Data.Main{
    public class BookRepository : IBookRepository
    {
        public LibraryContext _context{set;get;}
        public BookRepository(LibraryContext context){
            _context=context;
        }
        public IQueryable<Book> Books => _context.Books;

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void RemoveBook(Book book)
        {
            _context.Remove(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            _context.Update(book);
            _context.SaveChanges();
        }
    }
}