using Microsoft.AspNetCore.Mvc;
using QSpace.Core.Dtos;
using QSpace.Infrastructure.Services.MCQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QSpace.API.Controllers
{
    public class MCQuestionController : BaseController
    {
        private IMCQuestionService _service;
        public MCQuestionController(IMCQuestionService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create(int Id)
        {
            return View(new CreateMCQuestionDto());
        }
        [HttpPost]
        public IActionResult Create(CreateMCQuestionDto dto) {
            List<string> options = new List<string>(){ dto.A, dto.B, dto.C, dto.D };
            if (ModelState.IsValid) {
                if (!options.Contains(dto.CorrectAnswer))
                {
                    ViewBag.ErrorMessage = "Correcr Answer should match one of the options";
                    return View(dto);
                }
                else {
                    _service.Create(dto);
                    return Redirect("~/Quiz/Questions?Id=" + (dto.QuizId));
                }
            }
            return View(dto);
        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            return View(_service.GetById(Id));
        }
        [HttpPost]
        public IActionResult Update(UpdateMCQuestionDto dto) {
            List<string> options = new List<string>() { dto.A, dto.B, dto.C, dto.D };
            if (ModelState.IsValid)
            {
                if (!options.Contains(dto.CorrectAnswer))
                {
                    ViewBag.ErrorMessage = "Correcr Answer should match one of the options";
                    return View(dto);
                }
                else
                {
                    _service.Update(dto);
                    return Redirect("~/Quiz/Questions?Id=" + (dto.QuizId));
                }
            }
            return View(dto);
        }
        [HttpPut]
        public IActionResult ChangeActive(int Id)
        {
            var quizId = _service.GetById(Id).QuizId; 
            _service.ChangeActive(Id);
            return Redirect("~/Quiz/Questions?Id=" + quizId);
        }
        [HttpDelete]
        public IActionResult Delete(int Id) {
            var quizId = _service.GetById(Id).QuizId;
            _service.Delete(Id);
            return Redirect("~/Quiz/Questions?Id=" + quizId);
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var results = _service.GetById(id);
            return Ok(GetResponse(results));
        }
        [HttpGet]
        public IActionResult GetOne(int Id)
        {
            var result = _service.GetById(Id);
            return View(result);
        }
    }
}