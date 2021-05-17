using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFTFS.Models;
using TFTFS.Utils;

namespace TFTFS.Controllers
{
    public class SaqueController : Controller
    {
        // GET: SaqueController
        public ActionResult Index()
        {
            return View(IOUtils.ListaObjetosArquivo(new Saque()));
        }

        // GET: SaqueController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SaqueController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaqueController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Saque model)
        {
            try
            {
                var usuario = IOUtils.GetUsuario(model.Conta);
                usuario.Valor -= model.Valor;
                IOUtils.EditarUsuario(usuario);
                IOUtils.Criar(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SaqueController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SaqueController/Edit/5
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

        // GET: SaqueController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SaqueController/Delete/5
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
