using HCID_HM.Data;
using HCID_HM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HCID_HM.Controllers
{
    public class FavoritesListController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FavoritesListController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(z => z.Id == userId)
                .Include(z => z.FavoritesList)
                .Include("FavoritesList.TopicsInFavoritesList")
                .Include("FavoritesList.TopicsInFavoritesList.Topic")
                .FirstOrDefault();

            var favoritesList = user.FavoritesList;

            FavoritesListDTO model = new FavoritesListDTO
            {
                TopicsInFavoritesList = favoritesList.TopicsInFavoritesList.ToList()
            };

            return View(model);
        }

        public IActionResult UpcomingEvents()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(z => z.Id == userId)
                .Include(z => z.FavoritesList)
                .Include("FavoritesList.TopicsInFavoritesList")
                .Include("FavoritesList.TopicsInFavoritesList.Topic")
                .FirstOrDefault();

            var favoritesList = user.FavoritesList;            

            FavoritesListDTO model = new FavoritesListDTO
            {
                TopicsInFavoritesList = favoritesList.TopicsInFavoritesList.ToList()
            };

            return View(model);
        }

        public IActionResult IndexFiltered(string filter)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(z => z.Id == userId)
                .Include(z => z.FavoritesList)
                .Include("FavoritesList.TopicsInFavoritesList")
                .Include("FavoritesList.TopicsInFavoritesList.Topic")
                .FirstOrDefault();

            var favoritesList = user.FavoritesList;

            var filteredtopics = favoritesList.TopicsInFavoritesList.Where(topic => topic.Topic.Category.Contains(filter)).ToList();

            FavoritesListDTO model = new FavoritesListDTO
            {
                TopicsInFavoritesList = filteredtopics.ToList()
            };

            return View(model);
        }

        public IActionResult IndexSearch(string search)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(z => z.Id == userId)
                .Include(z => z.FavoritesList)
                .Include("FavoritesList.TopicsInFavoritesList")
                .Include("FavoritesList.TopicsInFavoritesList.Topic")
                .FirstOrDefault();

            var favoritesList = user.FavoritesList;

            var results = favoritesList.TopicsInFavoritesList.Where(topic => topic.Topic.Name.Contains(search) || topic.Topic.Category.Contains(search) || topic.Topic.Description.Contains(search)).ToList();


            FavoritesListDTO model = new FavoritesListDTO
            {
                TopicsInFavoritesList =results.ToList()
            };

            return View(model);
        }

        public IActionResult UpcomingEventsFiltered(int days)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(z => z.Id == userId)
                .Include(z => z.FavoritesList)
                .Include("FavoritesList.TopicsInFavoritesList")
                .Include("FavoritesList.TopicsInFavoritesList.Topic")
                .FirstOrDefault();

            var favoritesList = user.FavoritesList;


            var today = DateTime.Now;
            favoritesList.TopicsInFavoritesList = favoritesList.TopicsInFavoritesList.Where(x => (x.Topic.Event - today).TotalDays < days).ToList();

            FavoritesListDTO model = new FavoritesListDTO
            {
                TopicsInFavoritesList = favoritesList.TopicsInFavoritesList.ToList()
            };
                       


            return View(model);
        }
    }
}
