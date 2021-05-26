using Microsoft.AspNetCore.Mvc;
using QSpace.Core.Dtos;
using QSpace.Infrastructure.Services.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QSpace.API.Controllers
{
    public class StudentController : BaseController
    {
        private readonly IStudentService _service;
        public StudentController(IStudentService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateStudentDto dto) {
            _service.Create(dto);
            return Ok(GetResponse());
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateStudentDto dto) {
            _service.Update(dto);
            return Ok(GetResponse());
        }
    }
}