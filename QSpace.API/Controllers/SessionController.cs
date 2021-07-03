using Microsoft.AspNetCore.Mvc;
using QSpace.Core.Dtos;
using QSpace.Infrastructure.Services.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QSpace.API.Controllers
{
    public class SessionController : BaseController
    {
        private readonly ISessionService _service;
        public SessionController(ISessionService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetSessions()
        {
            var sessions = _service.GetAll();
            return Ok(GetResponse(data: sessions));
        }
        [HttpGet]
        public IActionResult GetSessionById(int sessionId)
        {
            var session = _service.GetSessionById(sessionId);
            return Ok(GetResponse(data: session));
        }
        [HttpGet]
        public IActionResult GetQuiz(int sessionId)
        {
            var quiz = _service.GetQuiz(sessionId);
            if (quiz == null)
                return Ok();
            return Ok(GetResponse(data: quiz));
        }
        [HttpGet]
        public IActionResult GetStudents(int sessionId) {
            var students = _service.GetStudents(sessionId);
            if (students.Count == 0)
                return Ok();
            else
                return Ok(GetResponse(data: students));
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateSessionDto dto) {
            _service.Create(dto);
            return Ok(GetResponse());
        }
        [HttpPut]
        public IActionResult Update([FromForm] UpdateSessionDto dto)
        {
            _service.Update(dto);
            return Ok(GetResponse());
        }
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            if (_service.Delete(Id))
                return Ok(GetResponse());
            else
                return Ok(GetResponse(message: "Record Not found"));
        }
    }
}
