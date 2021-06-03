using QSpace.Core.Dtos;
using QSpace.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QSpace.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetUsers();
            return Ok(GetResponse(users));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateUserDto dto)
        {
            var id = await _userService.Create(dto);
            return Ok(GetResponse(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto dto)
        {
            var id = await _userService.Update(dto);
            return Ok(GetResponse(id));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _userService.Delete(id);
            return Ok(GetResponse());
        }

    }
}
