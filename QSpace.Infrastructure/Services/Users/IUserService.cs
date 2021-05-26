using QSpace.Core.Dtos;
using QSpace.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QSpace.Infrastructure.Services.Users
{
    public interface IUserService
    {
        List<UserViewModel> GetUsers();
        Task<bool> Create(CreateUserDto dto);
        Task Update(UpdateUserDto dto);
        void Delete(string Id);
    }
}
