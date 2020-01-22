using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        public IActionResult ShowList() 
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Play([Bind("Name", "Email")] Participants participants)
        {
            if (ModelState.IsValid)
            {
                _context.Add(participants);
                await _context.SaveChangesAsync().ConfigureAwait(true);
                return RedirectToAction(nameof(Add));
            }
            return View(participants);
        }

        public async Task<IActionResult> Generate()
        {
            await GenerateList().ConfigureAwait(true);
            return View(); 
        }
        
        // GET: Participants/Add
        public IActionResult Add()
        {
            return View();
        }

        // POST: Participants/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Name", "Email")] Participants participants)
        {
            if (!ModelState.IsValid)
            {
                return View(participants);

            }
            _context.Add(participants);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return RedirectToAction(nameof(Add));

        }

        //Generate participants and recipients 
        //Save at Recipients Table 
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
                    /*if (p[i].Email.Equals(list[i].Email))
                    {
                        throw new Exception("Nobody can't be secret santa for itself!");
                    }*/
                }
                _context.AddRange(re);
                await _context.SaveChangesAsync().ConfigureAwait(true);
                sendEmail(re);
                return View(_context.Recipients.ToList());  
            }
        }

        //Generate random list of recipients
        public static void GenerateL(List<Participants> p)
        {
            Random rand = new Random();
            for (var i = p.Count; i > 1;)
            {
                i--;
                var j = (int)(rand.NextDouble() * (i));
                var tmp = p[j];
                p[j] = p[i];
                p[i] = tmp;
            }
        }

        //method-send email to participants
        protected static void sendEmail(List<Recipients> list)  
        {

            string subject = "Secret Santa-NOVUS";
            string fromaddr = "secretsanta-2019@hotmail.com";
            string pass = "Secretsanta2019";
            for (int i = 0; i < list.Count; i++)
            {
                string msg = "Hello from Secret Santa 2019.\nYou should be a secret santa for: \n\n***" 
                    + list[i].NameR + "***\n\nGood Luck!";
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(new MailAddress(list[i].EmailS));
                mailMessage.From = new MailAddress("secretsanta-2019@hotmail.com");
                mailMessage.Subject = subject;
                mailMessage.Body = msg;
                

                SmtpClient client = new SmtpClient("smtp.live.com", 587);
                client.EnableSsl = true;
                NetworkCredential nc = new NetworkCredential(fromaddr, pass);
                
                client.Credentials = nc;
                client.Send(mailMessage);
            }
        }
        
       
    }
}


