using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TFTFS.Models;
using Newtonsoft.Json;

namespace TFTFS.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: UsuarioController
        public ActionResult Index()
        {
            var model = new List<Usuario>();
            string path = @"Usuarios.json";
            if (!System.IO.File.Exists(path))
                System.IO.File.WriteAllText(path, "[]");
            var obj = JArray.Parse(System.IO.File.ReadAllText(path));
            model = obj.ToObject<List<Usuario>>();
            return View(model);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario model)
        {
            try
            {
                string path = @"Usuarios.json";
                string dados = "[]";
                if (System.IO.File.Exists(path))
                {
                    var obj = JArray.Parse(System.IO.File.ReadAllText(path));
                    obj.Add(JToken.FromObject(model));
                    dados = obj.ToString();
                }
                System.IO.File.WriteAllText(path, dados);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
