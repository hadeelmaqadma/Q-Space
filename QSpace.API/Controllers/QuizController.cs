using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QSpace.Core.Dtos;
using QSpace.Infrastructure.Services.Quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QSpace.API.Controllers
{
    public class QuizController : BaseController
    {
        private readonly IQuizService _service;
        public QuizController(IQuizService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            return View(result);
        }
        [HttpGet]
        public IActionResult GetById(int Id)
        {
            var result = _service.GetById(Id);
            return Ok(GetResponse(result));
        }
        [HttpGet]
        public IActionResult GetQuiz(int Id)
        {
            var result = _service.GetQuizVMById(Id);
            return View(result);
        }
        [HttpGet]
        public IActionResult Questions(int Id)
        {
            var result = _service.GetQuestions(Id);
            return View(result);
        }
        [HttpGet]
        public IActionResult GetHostingSessions(int Id) {
            var result = _service.GetHostingSessions(Id);
            return Ok(GetResponse(result));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateQuizDto dto)
        {
            if (ModelState.IsValid)
            {
                _service.Create(dto);
                return RedirectToAction("Index");
            }
            return View(dto);
        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            return View(_service.GetById(Id));
        }
        [HttpPut]
        public IActionResult Update(UpdateQuizDto dto)
        {
            if (ModelState.IsValid)
            {
                _service.Update(dto);
                return RedirectToAction("Index");
            }
            return View(dto);
        }
        [HttpPut]
        public IActionResult Activate(int Id)
        {
            _service.Activate(Id);
            return RedirectToAction("GetAll");
        }
        [HttpPut]
        public IActionResult Deactivate(int Id)
        {
            _service.Deactivate(Id);
            return RedirectToAction("GetAll");
        }
        [HttpPut]
        public IActionResult MarkAsInCompleted(int Id)
        {
            _service.MarkAsInCompleted(Id);
            return RedirectToAction("GetAll");
        }
        [HttpPut]
        public IActionResult MarkAsCompleted(int Id)
        {
            _service.MarkAsCompleted(Id);
            return RedirectToAction("GetAll");
        }
        [HttpDelete]
        public IActionResult Delete(int Id) {
            _service.Delete(Id);
            return RedirectToAction("GetAll");
        }
    }
}
