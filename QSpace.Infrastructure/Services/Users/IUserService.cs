using QSpace.Core.Dtos;
using QSpace.Core.ViewModels;
using QSpace.Data.DbEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QSpace.Infrastructure.Services.Users
{
    public interface IUserService
    {
        List<UserViewModel> GetUsers();
        Task<string> Create(CreateUserDto dto);
        Task<string> Update(UpdateUserDto dto);
        Task Delete(string Id);
        List<QuizViewModel> GetQuizzes(string Id);
    }
}
