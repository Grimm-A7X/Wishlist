using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WishlistSteam.Data;
using WishlistSteam.Models;
using WishlistSteam.Services.Exceptions;

namespace WishlistSteam.Controllers
{
    public class GamesController : Controller
    {
        private readonly SteamDbContext _context;

        public GamesController(SteamDbContext contexto)
        {
            _context = contexto;
        }

        public IActionResult Index()
        {
            // return View(_context.Wishlists.ToList());
            // var list = _context.Wishlists.ToList();
            var list = _context.Wishlists.ToList();
            return View(list);
        }

        public IActionResult Index1()
        {
            // return View(_context.Wishlists.ToList());
            var list = _context.Wishlists.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Wishlist wishlist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wishlist);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(wishlist);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishlist = _context.Wishlists.FirstOrDefault(m => m.Id == id);

            if (wishlist == null)
            {
                return NotFound();
            }

            return View(wishlist);
        }

        public IActionResult Details1(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishlist = _context.Wishlists.FirstOrDefault(m => m.Id == id);

            if (wishlist == null)
            {
                return NotFound();
            }

            return View(wishlist);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _context.Wishlists.FirstOrDefault(m => m.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var obj = _context.Wishlists.Find(id);
            _context.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _context.Wishlists.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Wishlist wishlist)
        {
            if (id != wishlist.Id)
            {
                return NotFound();
            }
            try
            {
                _context.Update(wishlist);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }


    }
}
