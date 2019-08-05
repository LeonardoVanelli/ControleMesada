using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.Atributos;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class CargosController : Controller
    {
        private readonly ICargoAppService _cargoApp;

        public CargosController(ICargoAppService cargoApp)
        {
            _cargoApp = cargoApp;
        }

        // GET: Cargos
        public ActionResult Index()
        {
            var cargoViewModel = Mapper.Map<IEnumerable<Cargo>, IEnumerable<CargoViewModel>>(_cargoApp.GetAll());
            return View(cargoViewModel);
        }

        // GET: Cargos/Details/5
        public ActionResult Details(int id)
        {
            var cargo = _cargoApp.GetById(id);
            var cargoViewModel = Mapper.Map<Cargo, CargoViewModel>(cargo);
            return View(cargoViewModel);
        }

        // GET: Cargos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cargos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CargoViewModel cargo)
        {
            if (ModelState.IsValid)
            {
                var cargoDomain = Mapper.Map<CargoViewModel, Cargo>(cargo);
                _cargoApp.Add(cargoDomain);

                return RedirectToAction("Index");
            }

            return View(cargo);
        }

        // GET: Cargos/Edit/5
        public ActionResult Edit(int id)
        {
            var cargo = _cargoApp.GetById(id);
            var cargoViewModel = Mapper.Map<Cargo, CargoViewModel>(cargo);

            return View(cargoViewModel);
        }

        // POST: Cargos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CargoViewModel cargo)
        {
            if (ModelState.IsValid)
            {
                var cargoDomain = Mapper.Map<CargoViewModel, Cargo>(cargo);
                _cargoApp.Update(cargoDomain);

                return RedirectToAction("Index");
            }

            return View(cargo);
        }

        // GET: Cargos/Delete/5
        public JsonResult Delete(int id)
        {
            try
            {
                _cargoApp.Remove(_cargoApp.GetById(id));
                return Json(404);
            }
            catch (Exception exp)
            {
                return Json(exp.Message);
            }
        }        
    }
}

