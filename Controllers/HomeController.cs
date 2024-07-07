using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LibManagement.Models;
using LibManagement.Data.Abstract;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace LibManagement.Controllers;

public class HomeController : Controller
{
    IUserRepository user_repository;
    IBookRepository book_repository;
    public HomeController(IUserRepository rep1,IBookRepository rep2){
        user_repository=rep1;
        book_repository=rep2;
    }
    public IActionResult Index()
    {
        List<Book> booklist=book_repository.Books.ToList<Book>();
        
        return View(booklist);
    }
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> LoginAsync(User user)
    {
            if(user_repository.CheckUser(user)){
                var user1=user_repository.Users.FirstOrDefault(o=>o.username==user.username);
                var userClaims=new List<Claim>{
                    new Claim(ClaimTypes.Name,user1.Name)
                };
                var userIdentity=new ClaimsIdentity(userClaims,CookieAuthenticationDefaults.AuthenticationScheme);
                var userproperties=new AuthenticationProperties();

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(userIdentity),userproperties);
                return RedirectToAction("Index","Home");
            }else{
                return View();
            }
    }
    public async Task<IActionResult> Logout(){
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index","Home");
    }
    [HttpGet]
    public IActionResult BookMng(){
        if(User.Identity.IsAuthenticated){
            if(User.Identity.Name.Equals("Admin")){
                return View();
            }else{
                return NotFound();
            }
        }else{
            return NotFound();
        }
    }
    [HttpPost]
    public IActionResult BookMng(Book book){
        if(User.Identity.IsAuthenticated&&User.Identity.Name.Equals("Admin")){
            book_repository.AddBook(book);
            return RedirectToAction("Index","Home");
        }
        else{
            return NotFound();
        }
    }
    [HttpGet]
    public IActionResult BookUpdate(int ?id){
        if(User.Identity.IsAuthenticated && User.Identity.Name.Equals("Admin")){

            if(id!=null){
                var book1=book_repository.Books.FirstOrDefault(p=>p.BookId==id);
                if(book1==null){
                    return NotFound();
                }else{
                    return View(book1);
                }
            }else{
                return NotFound();
            }

        }else{
            return NotFound();
        }
    }
    [HttpPost]
    public IActionResult BookUpdate(int ?id,Book book){
        if(User.Identity.IsAuthenticated && User.Identity.Name.Equals("Admin")){
            if(id!=null && id==book.BookId){
                book_repository.UpdateBook(book);
                return RedirectToAction("Index","Home");
            }
            else{
                return NotFound();
            }
        }
        else{
            return NotFound();
        }
    }
    [HttpGet]
    public IActionResult BookRemove(int? id){
        if(User.Identity.IsAuthenticated && User.Identity.Name.Equals("Admin")){
            if(id!=null){
                var book1=book_repository.Books.FirstOrDefault(p=>p.BookId==id);
                if(book1!=null){
                    book_repository.RemoveBook(book1);
                    return RedirectToAction("Index","Home");
                }
                else{
                    return NotFound();
                }
            }else{
                return NotFound();
            }
        }else{
            return NotFound();
        }
    }
    
}
