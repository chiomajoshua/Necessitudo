using Necessitudo.APIModels;
using Necessitudo.Models.RequestModel;
using Necessitudo.Services.Services;
using System.Threading.Tasks;

namespace Necessitudo.Services.ViewModels
{
    public class SecurityViewModel : BaseViewModel
    {
        public SecurityViewModel()
        {

        }

        private readonly SecurityService _securityService;
        public SecurityViewModel(SecurityService securityService)
        {
            _securityService = securityService;
        }

        public async Task<ApiResponse<string>> GenerateToken(SelectUserViewModel selectUserViewModel)
        {
            return await _securityService.GenerateToken(selectUserViewModel);
        }

        public async Task<ApiResponse<string>> Login(LoginViewModel loginViewModel)
        {
            return await _securityService.Login(loginViewModel);
        }

        public async Task<ApiResponse<bool>> Logout(string token)
        {
            return await _securityService.Logout(token);
        }

        public async Task<ApiResponse<bool>> RegisterAccount(RegisterViewModel registerViewModel)
        {
            return await _securityService.RegisterAccount(registerViewModel);
        }
        public async Task<ApiResponse<bool>> ValidateEmail(SelectUserViewModel selectUserViewModel)
        {
            return await _securityService.ValidateEmail(selectUserViewModel);
        }
    }
}