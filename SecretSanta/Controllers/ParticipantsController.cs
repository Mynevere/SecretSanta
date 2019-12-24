using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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


        // GET: Participants
        //List all participants from database table
        public IActionResult showList()
        {
            return View(_context.Participants.ToList());
        }

        //Play view
        //GET: Participants/Play
        public IActionResult Play()
        {
            return View();
        }
        // POST: Participants/Play
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        public async Task<IActionResult> Generate()
        {
            await GenerateList();
            return View(_context.Recipients.ToList());
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
            if (!ModelState.IsValid)
            {
                return View(participants);

            }
            _context.Add(participants);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Add));
            
        }


        public async Task<IActionResult> GenerateList()
        {
            List<Participants> pa = new List<Participants>();
            var list = new List<Participants>();             

            using (_context)
            {
                var query = _context.Participants.ToList();
                int n = query.Count;
                Participants[] p = new Participants[n];
                
                foreach (var par in query)
                {
                        pa = query;
                        p = pa.ToArray();
                            list.Add(new Participants { Name = par.Name, Email = par.Email });
                }
                p = list.ToArray();
                GenerateL(list);
                Recipients[] r = new Recipients[p.Length];
                List<Recipients> re = new List<Recipients>();


                for (int i = 0; i < n; i++)
                {
                    re.Add(new Recipients { NameS = p[i].Name, EmailS = p[i].Email, NameR = list[i].Name, EmailR = list[i].Email });

                }
                _context.AddRange(re); 
               await _context.SaveChangesAsync();
               return View();
               
            }
    }

        public static void GenerateL(List<Participants> p)
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
        }
      

   
    }
}


