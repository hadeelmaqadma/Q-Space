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
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var sessions = _service.GetAll();
            //return Ok(GetResponse(data: sessions));
            return View(sessions);
        }
        [HttpGet]
        public IActionResult GetFutureSessions()
        {
            var sessions = _service.GetFutureSessions();
            //return Ok(GetResponse(data: sessions));
            return View();
        }
        [HttpGet]
        public IActionResult GetSessionById(int sessionId)
        {
            var session = _service.GetSessionById(sessionId);
            //return Ok(GetResponse(data: session));
            return View(session);

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
        public IActionResult JoinSession(string Code)
        {
            var session = _service.GetSessionByCode(Code);
            var quiz = _service.GetQuiz(session.Id);
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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateSessionDto dto)
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
            return View(_service.GetSessionById(Id));
        }
        [HttpPut]
        public IActionResult Update(UpdateSessionDto dto)
        {
            if (ModelState.IsValid)
            {
                _service.Update(dto);
                return RedirectToAction("Index");
            }
            return View(dto);
        }
        //[HttpPost]
        //public IActionResult Create([FromBody] CreateSessionDto dto) {
        //    _service.Create(dto);
        //    return Ok(GetResponse());
        //}
        //[HttpPut]
        //public IActionResult Update([FromForm] UpdateSessionDto dto)
        //{
        //    _service.Update(dto);
        //    return Ok(GetResponse());
        //}
        [HttpPut]
        public IActionResult Launch(int sessionId)
        {
            var session = _service.Launch(sessionId);
            //return Ok(GetResponse());
            return View(session);
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
