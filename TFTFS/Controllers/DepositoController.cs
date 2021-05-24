using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFTFS.Models;
using TFTFS.Utils;

namespace TFTFS.Controllers
{
    public class DepositoController : Controller
    {
        // GET: DepositoController
        public ActionResult Index()
        {
            return View(IOUtils.ListaObjetosArquivo(new Deposito()));
        }

        // GET: DepositoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepositoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepositoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Deposito model)
        {
            try
            {
                if (!model.Validate())
                    return View();
                var usuario = IOUtils.GetUsuario(model.Conta);
                usuario.Valor += model.Valor;
                IOUtils.EditarUsuario(usuario);
                IOUtils.Criar(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepositoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepositoController/Edit/5
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

        // GET: DepositoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepositoController/Delete/5
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
