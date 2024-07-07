using LibManagement.Models;

namespace LibManagement.Data.Abstract{
    public interface IUserRepository{
        public IQueryable<User> Users{get;}
        public bool CheckUser(User user);
    }
}