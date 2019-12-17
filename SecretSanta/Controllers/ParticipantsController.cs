using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.DAL;
using SecretSanta.Models;

namespace SecretSanta.Controllers
{

    public class ParticipantsController : Controller
    {
        private readonly SecretSantaContext _context;

        public ParticipantsController(SecretSantaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Participants.ToListAsync());
        }
        [HttpGet]
        [ValidateAntiForgeryToken]
        /*public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participants = await _context.Participants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participants == null)
            {
                return NotFound();
            }

            return View(participants);
        }*/

        // GET: Participants

        public IActionResult List()
        {
            return View();
        }


        public IActionResult Play()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Play([Bind("Name", "Email")] Participants participants)
        {
            if (ModelState.IsValid)
            {
                _context.Add(participants);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Add));
            }
            return View(participants);
        }

        // GET: Participants/Add
        public IActionResult Add()
        {
            return View();
        }


        // POST: Participants/Add
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Name", "Email")] Participants participants)
        {
            if (ModelState.IsValid)
            {
                _context.Add(participants);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Add));
            }
            return View(participants);
        }



        // GET: Participants/Add

        /*public async Task<IActionResult> Add([Bind("Name","Email")] List<Participants> participants)
        {

            if (ModelState.IsValid)
            {

                // Participants p = new Participants
                 {
                     Name = participants.Name 
                 };//

                List<Participants> pa = new List<Participants>();
                foreach (var p in pa)
                {
                    pa.Add(participants);
                }
                _context.AddRange(pa);
                await _context.SaveChangesAsync();




                // await _context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }
            return View(participants);

        } */

        /* public static void Generate(List<Participants> p)
         {

             Random rand = new Random();
             for (var i = p.Count(); i > 1;)
             {
                 i--;
                 var j = (int)(rand.NextDouble() * (i));
                 var tmp = p[j];
                 p[j] = p[i];
                 p[i] = tmp;

             }
         }*/
       
      
    }
}
