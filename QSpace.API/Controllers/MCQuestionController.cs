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
        [HttpPost]
        public IActionResult Create([FromForm] CreateMCQuestionDto dto) {
            _service.Create(dto);
            return Ok(GetResponse());
        }
        [HttpPut]
        public IActionResult Update([FromForm] UpdateMCQuestionDto dto) {
            _service.Update(dto);
            return Ok(GetResponse());
        }
        [HttpDelete]
        public IActionResult Delete(int Id) {
            if(_service.Delete(Id))
                return Ok(GetResponse());
            else
                return Ok(GetResponse(message:"Record Not found"));
        }
    }
}
