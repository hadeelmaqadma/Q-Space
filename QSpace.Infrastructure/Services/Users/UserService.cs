using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QSpace.Core.Dtos;
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
        private QSpaceDbContext _DB;
        private UserManager<QSpace.Data.DbEntities.User> _userManager;

        public UserService(QSpaceDbContext DB, UserManager<QSpace.Data.DbEntities.User> userManager, IMapper Mapper)
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
        public List<QuizViewModel> GetQuizes(string Id) {
            var quizes = _DB.Users.Include(y => y.Quizes).Where(x => x.Id.Equals(Id)).Select(q => q.Quizes).ToList();
            return _Mapper.Map<List<QuizViewModel>>(quizes);
        }

        public async Task<bool> Create(CreateUserDto dto)
        {
            /*Console.WriteLine("*****************");
            var user = _Mapper.Map<User>(dto);
            Console.WriteLine("/////////////////");
            var result = await _userManager.CreateAsync(user, "Ahmed11$$");

            return result.Succeeded;*/
            var user = new QSpace.Data.DbEntities.User();
            user.FCMToken = "";
            user.Name = dto.Name;
            user.Email = dto.Email;
            user.PhoneNumber = dto.PhoneNumber;
            user.CreatedAt = DateTime.Now;
            user.UserName = dto.PhoneNumber;

            var result = await _userManager.CreateAsync(user, "Hend2744$");

            return result.Succeeded;
        }
        public async Task Update(UpdateUserDto dto)
        {
            /*
            //var user = _DB.Users.SingleOrDefault(x => x.Id == dto.Id && !x.IsDelete);
            var user = _Mapper.Map<User>(dto);
            await _userManager.UpdateAsync(user);
            */
            var user = _DB.Users.SingleOrDefault(x => x.Id == dto.Id && !x.IsDelete);
            user.Name = dto.Name;
            user.FCMToken = dto.FCMToken;
            user.Email = dto.Email;
            user.UpdatedAt = DateTime.Now;

            await _userManager.UpdateAsync(user);

        }
        public void Delete(string Id)
        {
            var user = _DB.Users.SingleOrDefault(x => x.Id == Id && !x.IsDelete);
            user.IsDelete = true;
            _DB.Users.Update(user);
            _DB.SaveChanges();
        }
    }
}
