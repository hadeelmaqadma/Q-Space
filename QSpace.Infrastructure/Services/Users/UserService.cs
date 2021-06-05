using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QSpace.Core.Dtos;
using QSpace.Core.Exceptions;
using QSpace.Core.ViewModels;
using QSpace.Data.Data;
using QSpace.Data.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSpace.Infrastructure.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IMapper _Mapper;
        private readonly QSpaceDbContext _DB;
        private readonly UserManager<User> _userManager;

        public UserService(QSpaceDbContext DB, UserManager<User> userManager, IMapper Mapper)
        {
            _DB = DB;
            _userManager = userManager;
            _Mapper = Mapper;
        }

        public List<UserViewModel> GetUsers()
        {
            var users = _DB.Users.Where(x => !x.IsDelete).ToList();
            return _Mapper.Map<List<UserViewModel>>(users);
        }
        public List<QuizViewModel> GetQuizzes(string Id) {
            var quizzes = _DB.Users.Include(x => x.Quizes).Where(x => x.Id == Id).Select(x => x.Quizes).ToList();
            return _Mapper.Map<List<QuizViewModel>>(quizzes);
        }

        public async Task<string> Create(CreateUserDto dto)
        {
            if( _DB.Users.Any(x => x.UserName == dto.Email)) // used UserName
            {
                throw new InvalidUsernameException();
            }
            var user = _Mapper.Map<User>(dto);
            user.UserName = dto.Email;
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                throw new InValidPasswordException();
            }
            return user.Id;
        }
        public async Task<string> Update(UpdateUserDto dto)
        {
            var user = _DB.Users.SingleOrDefault(x => x.Id == dto.Id && !x.IsDelete);
            if (user == null)
            {
                throw new NotFoundException();
            }
            _Mapper.Map<UpdateUserDto,User>(dto,user);
            user.UpdatedAt = DateTime.Now;
            await _userManager.UpdateAsync(user);
            return user.Id;
        }

        public async Task Delete(string Id)
        {
            var user = _DB.Users.SingleOrDefault(x => x.Id == Id && !x.IsDelete);
            if (user == null)
            {
                throw new NotFoundException();
            }
            user.IsDelete = true;
            //_DB.Users.Update(user);
            //_DB.SaveChanges();
            await _userManager.UpdateAsync(user);
        }
    }
}
