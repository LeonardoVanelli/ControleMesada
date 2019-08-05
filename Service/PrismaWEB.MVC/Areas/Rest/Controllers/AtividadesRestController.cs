using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Areas.Rest.Controllers
{
    public class AtividadesRestController : Controller
    {
        // GET: Rest/atividadesRest
        private readonly IAtividadeAppService _atividadeApp;

        public AtividadesRestController(IAtividadeAppService atividadeApp)
        {
            _atividadeApp = atividadeApp;
        }

        public JsonResult GetAll()
        {
            var atividadeViewModel = Mapper.Map<IEnumerable<Atividade>, IEnumerable<AtividadeViewModel>>(_atividadeApp.GetAll());
            return Json(atividadeViewModel, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetByUser(int id)
        {
            var atividadeViewModel = Mapper.Map<IEnumerable<Atividade>, IEnumerable<AtividadeViewModel>>(_atividadeApp.GetByUser(id));
            return Json(atividadeViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllByDate(DateTime date)
        {
            var atividadeViewModel = Mapper.Map<IEnumerable<Atividade>, IEnumerable<AtividadeViewModel>>(_atividadeApp.GetAllByDate(date));
            return Json(atividadeViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetById(int id)
        {
            return Json(_atividadeApp.GetById(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(AtividadeViewModel atividade)
        {
            var atividadeEdit = new AtividadeViewModel() {
                Id = atividade.Id,
                DataRealizada = atividade.DataRealizada,
                Pessoa = atividade.Pessoa,
                Pessoa_Id = atividade.Pessoa_Id,
                Tarefa = atividade.Tarefa,
                Tarefa_Id = atividade.Tarefa_Id
            } ;
            Atividade atividadeDomain;
            try
            {
                if (atividadeEdit.Pessoa != null)
                {
                    atividadeEdit.Pessoa_Id = atividadeEdit.Pessoa.Id;
                    atividadeEdit.Pessoa = null;
                }
                if (atividadeEdit.Tarefa != null)
                {
                    atividadeEdit.Tarefa_Id = atividadeEdit.Tarefa.Id;
                    atividadeEdit.Tarefa = null;
                }

                atividadeDomain = Mapper.Map<AtividadeViewModel, Atividade>(atividadeEdit);
                _atividadeApp.Add(atividadeDomain);
                atividade.Id = atividadeEdit.Id;
            }
            catch (Exception exp)
            {
                Response.StatusCode = 500;
                var msg = exp.InnerException == null ? exp.Message : exp.InnerException.InnerException.Message;
                return Json(new { msg }, JsonRequestBehavior.AllowGet);
            }

            return Json(atividade, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            try
            {
                var atividade = _atividadeApp.GetById(id);
                _atividadeApp.Remove(atividade);

                return Json($"atividade {atividade.Id} deletado com sucesso", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exp)
            {
                return Json(exp, JsonRequestBehavior.AllowGet);
            }
        }
    }
}