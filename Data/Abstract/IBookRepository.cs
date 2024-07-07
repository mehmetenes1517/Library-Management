using LibManagement.Models;

namespace LibManagement.Data.Abstract{
    public interface IBookRepository{
        public IQueryable<Book> Books{get;}
        public void AddBook(Book book);
        public void RemoveBook(Book book);
        public void UpdateBook(Book book);

    }
}