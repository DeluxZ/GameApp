using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameApp.Data;
using Microsoft.EntityFrameworkCore;

namespace GameApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: User
        public ActionResult Index()
        {
            var allUsers = _context.Users.Include(u => u.Games).ToList();

            return View(allUsers);
        }

        // GET: User/Details/5
        public ActionResult Details(string id)
        {
            var user = _context.Users.Include(u => u.Games).FirstOrDefault(u => u.Id == id);

            return View(user);
        }
    }
}