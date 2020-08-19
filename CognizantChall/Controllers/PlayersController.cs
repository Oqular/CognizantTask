using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CognizantChall.Data;
using CognizantChall.Models;

namespace CognizantChall.Controllers
{
    public class PlayersController : Controller
    {
        private readonly DataContext _context;

        public PlayersController(DataContext context)
        {
            _context = context;
        }

        // GET: Players
        public async Task<IActionResult> Index()
        {
            var players = await _context.players.ToListAsync();
            var sortedP = players.OrderByDescending(p => p.successfulTaskCount).Take(3).ToList();
            return View(sortedP);
        }

        // GET: Players/Details/{id}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var players = await _context.players.Include(p => p.tasks).ThenInclude(t => t.task).FirstOrDefaultAsync(m => m.id == id);
            if (players == null)
            {
                return NotFound();
            }

            return View(players);
        }
    }
}
