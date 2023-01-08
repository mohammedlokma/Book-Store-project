//using BookStore.DataAccess.Data;
//using BookStore.DataAccess.Repository.IRepository;
//using BookStore.Models;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace BookStore.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    public class UserUnitController : Controller
//    {
//        private readonly IUnitOfWork _unit;
//        private readonly ApplicationDbContext _db;
//        public UserUnitController(IUnitOfWork unit, ApplicationDbContext db)
//        {
//            _unit = unit;
//            _db = db;
//        }
//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult Upsert(int? id)
//        {
//            ApplicationUser user = new ApplicationUser();
//            if(id == null)
//            {
//                return View(user);
//            }
//            user = _unit.ApplicationUser.Get(id.GetValueOrDefault());
//            if(user == null)
//            {
//                return NotFound();
//            }
//            return View(user);
//        }
       

//        #region API CALLS

//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            var allObj = _unit.ApplicationUser.GetAll();
//            var userRole = _db.UserRoles.ToList();
//            var roles = _db.Roles.ToList();
//            foreach (var user in allObj)
//            {
//                var roleId = userRole.FirstOrDefault(u => u.UserId == user.Id).RoleId;
//                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;
//                if (user.Company == null)
//                {
//                    user.Company = new Company()
//                    {
//                        Name = ""
//                    };
//                }
//            }
//            return Json(new { data = allObj });
            

//        }
//        [HttpPost]
//        public IActionResult LockUnlock([FromBody] string id)
//        {
//            var objFromDb = _unit.ApplicationUser.Get(id.GetValueOrDefault());
//            if (objFromDb == null)
//            {
//                return Json(new { success = false, message = "Error While Locking/Unlocking" });

//            }
//            if (objFromDb != null && objFromDb.LockoutEnd > DateTime.Now)
//            {
//                //user is currently locked, we will unlock them
//                objFromDb.LockoutEnd = DateTime.Now;
//            }
//            else
//            {
//                objFromDb.LockoutEnd = DateTime.Now.AddYears(100);
//            }
//            _db.SaveChanges();
//            return Json(new { success = true, message = "Operation Successful" });
//        }

//        #endregion
//    }
//}
