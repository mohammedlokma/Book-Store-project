using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BookStore.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
namespace BookStore.ViewComponents
{
    public class UserNameViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unit;
        public UserNameViewComponent(IUnitOfWork unit)
        {
            _unit = unit; 
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userFromDb = _unit.ApplicationUser.GetFirstOrDefault(u => u.Id == claims.Value);

            return View(userFromDb);
        }
    }
}
