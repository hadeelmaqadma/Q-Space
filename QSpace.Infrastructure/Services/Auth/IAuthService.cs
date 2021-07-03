using QSpace.Core.Dtos;
using QSpace.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QSpace.Infrastructure.Services.Auth
{ 
    public interface IAuthService
    {
        Task<LoginResponseViewModel> LoginAsync(LoginDto dto);

        Task SaveFcmToken(string fcm, string userId);


    }
}
