using Management_System1.Data;
using Management_System1.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Management_System1.Controllers
{
    public class ManageController : Controller
    {
        private ApplicationDBContext _db;

        IUserRepository _userRepository;

        public ManageController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }



        public IActionResult AllUser()
        {
            var users = _userRepository.getAllUser();



            return View(users);
        }



        public IActionResult ManageRoles(int id)
        {
            var users = _userRepository.UserAndRoles(id);

            var rolesIn = users.Roles;
            var allRoles = _userRepository.AllRoles();
            var rolesOut = allRoles.Except(rolesIn).ToList();

            ViewBag.user = users;
            ViewBag.rolesIn = rolesIn;
            ViewBag.rolesOut = rolesOut;

            return View();
        }


        [HttpPost]
        public IActionResult ManageRoles(int id, int[] RolesToAdd, int[] RolesToRemove)
        {
            var users = _userRepository.UserAndRoles(id);

            foreach (var rolesId in RolesToRemove)
            {
                var r = _userRepository.GetRoleById(rolesId);
                users.Roles.Remove(r);
            }


            foreach (var rolesId in RolesToAdd)
            {
                var r = _userRepository.GetRoleById(rolesId);
                users.Roles.Add(r);
            }

            _userRepository.SaveChanged();

            return RedirectToAction("AllUser");
        }
    }
}
