using Necessitudo.APIModels;
using Necessitudo.Contract;
using Necessitudo.Models.RequestModel;
using System.Threading.Tasks;

namespace Necessitudo.Services.Services
{
    public class SecurityService
    {
        public SecurityService()
        {

        }
        private ISecurityEngine _securityEngine;
      
        public SecurityService(ISecurityEngine securityEngine)
        {
            _securityEngine = securityEngine;
        }

        public async Task<ApiResponse<string>> GenerateToken(SelectUserViewModel selectUserViewModel)
        {
            return await _securityEngine.GenerateToken(selectUserViewModel);
        }

        public async Task<ApiResponse<string>> Login(LoginViewModel loginViewModel)
        {
            return await _securityEngine.Login(loginViewModel);
        }

        public async Task<ApiResponse<bool>> Logout(string token)
        {
            return await _securityEngine.Logout(token);
        }

        public async Task<ApiResponse<bool>> RegisterAccount(RegisterViewModel registerViewModel)
        {
            return await _securityEngine.RegisterAccount(registerViewModel);
        }

        public async Task<ApiResponse<bool>> ValidateEmail(SelectUserViewModel selectUserViewModel)
        {
            return await _securityEngine.ValidateEmail(selectUserViewModel);
        }
    }
}