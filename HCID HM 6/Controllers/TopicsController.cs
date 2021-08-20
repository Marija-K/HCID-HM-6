using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HCID_HM.Data;
using HCID_HM.Models;
using System.Security.Claims;

namespace HCID_HM.Controllers
{
    public class TopicsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TopicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Topics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Topics.ToListAsync());
        }

        public async Task<IActionResult> IndexFiltered(string filter)
        {
            List<Topic> topics = await _context.Topics.ToListAsync();
            List<Topic> filteredtopics = topics.Where(topic => topic.Category.Contains(filter)).ToList();

            return View(filteredtopics);
        }

        public async Task<IActionResult> IndexSearch(string search)
        {
            List<Topic> topics = await _context.Topics.ToListAsync();
            List<Topic> results = topics.Where(topic => topic.Name.Contains(search) || topic.Category.Contains(search) || topic.Description.Contains(search)).ToList();

            return View(results);
        }

        /*public async Task<IActionResult> AddToFavorites(int TopicId)
        {
            var topic = await _context.Topics.Where(z => z.TopicId == TopicId).FirstOrDefaultAsync();

            var model = new AddToFavoritesListDTO();
            model.SelectedTopic = topic;
            model.TopicId = topic.TopicId;

            return View(model);
        }

        [HttpPost]*/
        public async Task<IActionResult> AddToFavorites(int TopicId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _context.Users.Where(z => z.Id == userId)
                .Include(z => z.FavoritesList)
                .Include("FavoritesList.TopicsInFavoritesList")
                .Include("FavoritesList.TopicsInFavoritesList.Topic")
                .FirstOrDefaultAsync();

            var favoritesList = user.FavoritesList;
            if(favoritesList != null)
            {
                var topic = _context.Topics.Where(z => z.TopicId == TopicId).FirstOrDefault();
                if (topic != null)
                {
                    TopicInFavoritesList itemToAdd = new TopicInFavoritesList
                    {
                        Topic = topic,
                        TopicId = topic.TopicId,
                        FavoritesList = favoritesList
                    };
                    _context.Add(itemToAdd);
                    _context.SaveChanges();
                }
            }

            return Redirect("DetailsToRemove/" + TopicId);
        }

        public async Task<IActionResult> RemoveFromFavorites(int TopicId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _context.Users.Where(z => z.Id == userId)
                .Include(z => z.FavoritesList)
                .Include("FavoritesList.TopicsInFavoritesList")
                .Include("FavoritesList.TopicsInFavoritesList.Topic")
                .FirstOrDefaultAsync();

            var favoritesList = user.FavoritesList;
            var forRemoval = favoritesList.TopicsInFavoritesList.Where(z => z.TopicId == TopicId).FirstOrDefault();

            favoritesList.TopicsInFavoritesList.Remove(forRemoval);

            _context.Update(favoritesList);
            _context.SaveChanges();
            return Redirect("Details/"+TopicId);
        }



        // GET: Topics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics
                .FirstOrDefaultAsync(m => m.TopicId == id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        public async Task<IActionResult> DetailsToRemove(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics
                .FirstOrDefaultAsync(m => m.TopicId == id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        // GET: Topics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Topics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TopicId,Name,Image,Category,Description,Event")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(topic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(topic);
        }

        // GET: Topics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }
            return View(topic);
        }

        // POST: Topics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TopicId,Name,Image,Category,Description,Event")] Topic topic)
        {
            if (id != topic.TopicId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(topic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopicExists(topic.TopicId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(topic);
        }

        // GET: Topics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics
                .FirstOrDefaultAsync(m => m.TopicId == id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        // POST: Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TopicExists(int id)
        {
            return _context.Topics.Any(e => e.TopicId == id);
        }
    }
}
