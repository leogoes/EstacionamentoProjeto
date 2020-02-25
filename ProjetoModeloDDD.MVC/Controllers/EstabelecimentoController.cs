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
    public class EstabelecimentoController : Controller
    {
        private readonly IEstabelecimentoAppService _estabelecimentoAppService;
        private readonly IVeiculoAppService _veiculoAppService;

        public EstabelecimentoController(IEstabelecimentoAppService estabelecimentoAppService, IVeiculoAppService veiculoAppService)
        {
            _estabelecimentoAppService = estabelecimentoAppService;
            _veiculoAppService = veiculoAppService;
        }

        // GET: Estabelecimento
        public ActionResult Index()
        {
            try
            {
                Estabelecimento estabelecimento = _estabelecimentoAppService.Listar().FirstOrDefault();
  
                if(estabelecimento != null)
                {
                    EstabelecimentoViewModel estabelecimentoViewModel = Mapper.Map<Estabelecimento, EstabelecimentoViewModel>(estabelecimento);
                    estabelecimentoViewModel.VeiculosEstacionados = new List<VeiculoViewModel>();
                    estabelecimentoViewModel.VeiculosNaoEstacionados = new List<VeiculoViewModel>();

                    estabelecimentoViewModel.VeiculosEstacionados = Mapper.Map<List<Veiculos>, List<VeiculoViewModel>>(_veiculoAppService.Listar().FindAll(v => v.IsEstacionado == true));
                    estabelecimentoViewModel.VeiculosNaoEstacionados = Mapper.Map<List<Veiculos>, List<VeiculoViewModel>>(_veiculoAppService.Listar().FindAll(v => v.IsEstacionado == false));

                    return View(estabelecimentoViewModel);
                }

                return RedirectToAction("Create", "Estabelecimento");

            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult SairEstacionamento(int? Id)
        {
            if(Id > 0)
            {
                _estabelecimentoAppService.SaidaVeiculo((int)Id);
                Estabelecimento estabelecimento = new Estabelecimento();

                estabelecimento = _estabelecimentoAppService.Listar().First();
                estabelecimento.QtdeVagaCarro++;

                _estabelecimentoAppService.Update(estabelecimento);

            }

            return RedirectToAction("Index", "Estabelecimento");
        }

        public ActionResult EntrarEstacionamento(int Id)
        {
            _estabelecimentoAppService.EntradaVeiculo((int)Id);

            Estabelecimento estabelecimento = new Estabelecimento();

            estabelecimento = _estabelecimentoAppService.Listar().First();
            estabelecimento.QtdeVagaCarro--;

            _estabelecimentoAppService.Update(estabelecimento);

            return RedirectToAction("Index", "Estabelecimento");
        }


        // GET: Estabelecimento/Details/5
        public ActionResult Details(int id)
        {
            EstabelecimentoViewModel estabelecimentoViewModel = Mapper.Map<Estabelecimento, EstabelecimentoViewModel>(_estabelecimentoAppService.GetById(id));

            return View(estabelecimentoViewModel);
        }

        // GET: Estabelecimento/Create
        public ActionResult Create()
        {

            if(_estabelecimentoAppService.Listar().Count > 0)
            {

                return RedirectToAction("Index", "Estabelecimento");
            }
            else
            {
                return View();

            }

        }

        // POST: Estabelecimento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EstabelecimentoViewModel estabelecimentoViewModel)
        {
            try
            {
                Estabelecimento estabelecimento = Mapper.Map<EstabelecimentoViewModel, Estabelecimento>(estabelecimentoViewModel);
                _estabelecimentoAppService.Add(estabelecimento);

                return RedirectToAction("Index", "Estabelecimento");
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        // GET: Estabelecimento/Edit/5
        public ActionResult Edit(int id)
        {
            var estabelecimento = _estabelecimentoAppService.GetById(id);
            var estabelecimentoViewModel = Mapper.Map<Estabelecimento, EstabelecimentoViewModel>(estabelecimento);
            

            return View(estabelecimentoViewModel);
        }

        // POST: Estabelecimento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EstabelecimentoViewModel estabelecimentoViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var estabelecimento = Mapper.Map<EstabelecimentoViewModel, Estabelecimento>(estabelecimentoViewModel);
                    _estabelecimentoAppService.Update(estabelecimento);

                    return RedirectToAction("index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Estabelecimento/Delete/5
        public ActionResult Delete(int id)
        {

            var estabelecimento = _estabelecimentoAppService.GetById(id);
            var estabelecimentoViewModel = Mapper.Map<Estabelecimento, EstabelecimentoViewModel>(estabelecimento);

            return View();
        }

        // POST: Estabelecimento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EstabelecimentoViewModel estabelecimentoViewModel)
        {
            try
            {
                    Estabelecimento estabelecimento = _estabelecimentoAppService.GetById(id);
                    _estabelecimentoAppService.Remove(estabelecimento);


                return RedirectToAction("Index", "Estabelecimento");
            }
            catch
            {
                return View();
            }
        }
    }
}
