using System;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace SecretSanta.Controllers
{
    public class SecretSantaController : Controller
    {
        // GET: /SecretSanta/

        public ViewResult Index()
        {
            return View();
        }

        // 
        // GET: /SecretSanta/Welcome/id?name=test
        public string Welcome(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }
    }
}