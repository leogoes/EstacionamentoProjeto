using AutoMapper;
using ProjetoModeloDDD.Application.Interfaces;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly IEstabelecimentoAppService _estabelecimentoAppService;
        private readonly IVeiculoAppService _veiculoAppService;

        public VeiculoController(IEstabelecimentoAppService estabelecimentoAppService, IVeiculoAppService veiculoAppService)
        {
            _estabelecimentoAppService = estabelecimentoAppService;
            _veiculoAppService = veiculoAppService;
        }

        public ActionResult Index()
        {
            try
            {
                List<Veiculos> veiculos = _veiculoAppService.Listar();

                if (veiculos != null)
                {
                    List<VeiculoViewModel> veiculoViewModel = Mapper.Map<List<Veiculos>, List<VeiculoViewModel>>(veiculos);

                    return View(veiculoViewModel);
                }

                return RedirectToAction("Create", "Veiculo");

            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Details(int id)
        {
            VeiculoViewModel veiculoViewModel = Mapper.Map<Veiculos, VeiculoViewModel>(_veiculoAppService.GetById(id));

            return View(veiculoViewModel);
        }

        public ActionResult Create()
        {
            VeiculoViewModel veiculoViewModel = new VeiculoViewModel();

            veiculoViewModel.EstabelecimentoId = _estabelecimentoAppService.GetAll().First().Id;
            return View(veiculoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VeiculoViewModel veiculoViewModel)
        {
            try
            {
                Veiculos veiculos = Mapper.Map<VeiculoViewModel, Veiculos>(veiculoViewModel);
                _veiculoAppService.Add(veiculos);

                return RedirectToAction("Index", "Veiculo");
            }
            catch (Exception e)
            {
                throw e;
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var veiculos = _veiculoAppService.GetById(id);
            var veiculoViewModel = Mapper.Map<Veiculos, VeiculoViewModel>(veiculos);

            return View(veiculoViewModel);
        }


        [HttpPost]
        public ActionResult Edit(int id, VeiculoViewModel veiculoViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var veiculos = Mapper.Map<VeiculoViewModel, Veiculos>(veiculoViewModel);
                    _veiculoAppService.Update(veiculos);

                    return RedirectToAction("index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {

            var veiculo = _veiculoAppService.GetById(id);
            var veiculoViewModel = Mapper.Map<Veiculos, VeiculoViewModel>(veiculo);

            return View(veiculoViewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id, VeiculoViewModel veiculoViewModel)
        {
            try
            {
                Veiculos veiculo = _veiculoAppService.GetById(id);
                _veiculoAppService.Remove(veiculo);


                return RedirectToAction("Index", "Veiculo");
            }
            catch
            {
                return View();
            }
        }
    }
}
