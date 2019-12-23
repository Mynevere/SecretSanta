using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.EntityClient;
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


        public IActionResult Generate()
        {
            GenerateList();
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


        public void GenerateList()
        {

            List<Participants> pa = new List<Participants>();
            var list = new List<Participants>();
            Recipients[] r = new Recipients[pa.Count];
            Participants[] p = new Participants[pa.Count];

            using (_context)
            {
                var query = _context.Participants.ToList();
                foreach(var par in query)
                {

                    for(int i = 0; i < pa.Count; i++)
                    {
                        pa[i].Name = par.Name;
                        pa[i].Email = par.Email; 
                    }
                    list.Add(new Participants { Name = par.Name, Email = par.Email });
                    p = list.ToArray();
                    GenerateL(list);

                    for(int i = 0; i < r.Length; i++)
                    {
                        r[i].NameS = p[i].Name;
                        r[i].EmailS = p[i].Email;
                        r[i].NameR = list[i].Name;
                        r[i].EmailR = list[i].Email;
                    }
                }
               
            }
            
            
           


            

           /* for (int i = 0; i < p.Length; i++)
            {
                r[i].NameS = p[i].Name;
                r[i].EmailS = p[i].Email;
                r[i].NameR = list[i].Name;
                r[i].EmailR = list[i].Name;
            }*/
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




    /*public ActionResult InsertParticipants()
    {
        Participants objParticipants = new Participants();
        DataSet ds = new DataSet();
        using (SqlConnection conn = new SqlConnection("Data Source=(local); Initial Catalog=SecretSantaContext-eb167473-0ebc-4a07-bfa2-3bbba676a177; Integrated Security=SSPI ")) ;
        {
            using (SqlCommand cmd = new SqlCommand("participantsOperations", conn))
            {


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "GET");
                //conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //da.Fill(ds);
                List<Participants> parList = new List<Participants>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Participants pobj = new Participants();
                    pobj.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                    pobj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    pobj.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                    parList.Add(pobj);
                }
                objParticipants.participantsInfo = parList;
            }
            //con.Close();
        }
        return View(objParticipants);
    }
    [HttpPost]
    public ActionResult InsertParticipant(Participants p)
    {
        Participants pobj = new Participants();
        using (SqlConnection con = new SqlConnection("SecretSantaContext"))
        {
            using (SqlCommand cmd = new SqlCommand("participantsOperation", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", p.Name);
                cmd.Parameters.AddWithValue("@email", p.Email);
                cmd.Parameters.AddWithValue("@status", "Insert");
                con.Open();
                ViewData["result"] = cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        return View();*/
}



