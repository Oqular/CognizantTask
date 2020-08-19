using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CognizantChall.Data;
using CognizantChall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CognizantChall.Controllers
{
    public class SolveController : Controller
    {
        private readonly DataContext _context;

        public SolveController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Tasks> task = _context.tasks.ToList();
            ViewData["tasks"] = new SelectList(task, "id", "name");
            ViewBag.fullTask = task;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SolveTask(TempPlayers player)
        {
            if (!checkOutput(player))
            {
                return RedirectToAction(nameof(Index));
            }
            if (ModelState.IsValid)
            {
                var existingPlayer = await _context.players.FirstOrDefaultAsync(p => p.nickname == player.nickname);
                if (existingPlayer != null)
                {
                    existingPlayer.successfulTaskCount += 1;
                    PlayerTasks playerTasks = new PlayerTasks();
                    playerTasks.tasksId = player.taskId;
                    playerTasks.playersId = existingPlayer.id;
                    _context.Update(existingPlayer);
                    _context.Add(playerTasks);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    Players newPlayer = new Players();
                    newPlayer.nickname = player.nickname;
                    newPlayer.successfulTaskCount = 1;
                    PlayerTasks playerTasks = new PlayerTasks();
                    playerTasks.tasksId = player.taskId;

                    _context.Add(newPlayer);
                    await _context.SaveChangesAsync();

                    var tempPlayer = await _context.players.FirstOrDefaultAsync(p => p.nickname == player.nickname);
                    playerTasks.playersId = tempPlayer.id;

                    _context.Add(playerTasks);
                    await _context.SaveChangesAsync();
                }
                
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private bool checkOutput(TempPlayers player)
        {
            var task = _context.tasks.FirstOrDefault(t => t.id == player.taskId);
            if (task != null)
            {
                if(task.testOutput == player.result)
                {
                    return true;
                }
            }
            return false;
        }
    }
}