using Management_System1.Models;
using Management_System1.Repository;
using Management_System1.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Management_System1.Controllers
{
    public class AccountController : Controller
    {

        IUserRepository _userRepository;
        ILoginRepository _loginRepository;
        public AccountController(IUserRepository userRepository ,ILoginRepository loginRepository)
        {
            _userRepository = userRepository;
            _loginRepository = loginRepository;
        }
      
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel r )
        {

            if(ModelState.IsValid)
            {
                var user = _loginRepository.Exist(r.Name, r.Passward);
                if (user != null)
                {
                    Claim c1 = new Claim(ClaimTypes.Name, user.Name);
                    Claim c2 = new Claim(ClaimTypes.Email, "Email :" + user.Email);
                    ClaimsIdentity ci = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    Claim r1 = new Claim(ClaimTypes.Role, "admain");
                    Claim r2 = new Claim(ClaimTypes.Role, "instructor");
                    ci.AddClaim(r1);
                    ci.AddClaim(r2);
                    ci.AddClaim(c1);
                    ci.AddClaim(c2);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal();

                    claimsPrincipal.AddIdentity(ci);
                    //send with all request
                    await HttpContext.SignInAsync(claimsPrincipal);
                    return RedirectToAction("index", "home");



                    //    var roleName=  user.Roles.FirstOrDefault(d => d.Id == user.Id).Name.ToList();
                    /*   foreach(var i in roleName)
                       {
                       Claim r1 = new Claim(ClaimTypes.Role,i.ToString());
                       ci.AddClaim(r1);

                       }
                     */

                }
                else
                {
                    ModelState.AddModelError("", "UserName or Password InVaild");
                    return View(r);

                }
            }

            return View(r);

        }


        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync();

        return RedirectToAction("index", "home");

        }



        public IActionResult Register ()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register( RegisterViewModel r)
        {


            if(ModelState.IsValid)
            {
                User s = new User() { Name = r.Name, Age = r.Age, Email = r.Email, Password = r.Password };
                _userRepository.AddUser(s);
                Role r1 = _userRepository.GetRole("Admain");
                Role r2 = _userRepository.GetRole("Instructor");

                // s.Roles.Add(r1);
                // s.Roles.Add(r2);

                r1.users.Add(s);
                r2.users.Add(s);
                _userRepository.SaveChanged();

                return RedirectToAction("Index","home");
            }



            return View(r);
        }

    }
}
