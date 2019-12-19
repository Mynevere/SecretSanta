using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
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



        public IActionResult Generate => View(_context.Participants.ToList());

        public SecretSantaContext Context => _context;


        // GET: Participants/Add
        public IActionResult Add()
        {
            return View();
            
        }

       /* public IActionResult RecipientsGenerated()
        {
                return View(_context.Recipients.ToList());
        }*/

        // POST: Participants/Add
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Name", "Email")] Participants participants)
        {

            if (!ModelState.IsValid)
            {
                return View(participants);

            }
            _context.Add(participants);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Add));
        }



        /*public static void GenerateL(List<Participants> p)
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
