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
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            return Ok(GetResponse(result));
        }

        [HttpGet]
        public IActionResult GetById(int Id) {
            var result = _service.GetById(Id);
            return Ok(GetResponse(result));
        }
        [HttpGet]
        public IActionResult GetHostingSessions(int Id) {
            var result = _service.GetHostingSessions(Id);
            return Ok(GetResponse(result));
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateQuizDto dto)
        {
            _service.Create(dto);
            return Ok(GetResponse());
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateQuizDto dto)
        {
            _service.Update(dto);
            return Ok(GetResponse());
        }
        [HttpPut]
        public IActionResult Activate(int Id)
        {
            _service.Activate(Id);
            return Ok(GetResponse());
        }
        [HttpPut]
        public IActionResult Deactivate(int Id)
        {
            _service.Deactivate(Id);
            return Ok(GetResponse());
        }
        [HttpPut]
        public IActionResult MarkAsInCompleted(int Id)
        {
            _service.MarkAsInCompleted(Id);
            return Ok(GetResponse());
        }
        [HttpPut]
        public IActionResult MarkAsCompleted(int Id)
        {
            _service.MarkAsCompleted(Id);
            return Ok(GetResponse());
        }
        [HttpDelete]
        public IActionResult Delete(int Id) {
            _service.Delete(Id);
            return Ok(GetResponse());
        }
    }
}
