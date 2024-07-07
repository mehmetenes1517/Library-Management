using LibManagement.Data.Abstract;
using LibManagement.Models;

namespace LibManagement.Data.Main{
    public class UserRepository : IUserRepository
    {
        public LibraryContext _context{set;get;}
        public UserRepository(LibraryContext context){
            _context=context;
        }
        public IQueryable<User> Users => _context.Users;

        public bool CheckUser(User user)
        {
            var correct_user=_context.Users.FirstOrDefault(p=> p.username == user.username);
            if(correct_user!=null){
                if(correct_user.password==user.password){
                    return true;
                }
                else{
                    return false;
                }
            }
            return false;
        }
    }
}