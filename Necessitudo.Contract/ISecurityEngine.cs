using Necessitudo.APIModels;
using Necessitudo.Models.RequestModel;
using System.Threading.Tasks;

namespace Necessitudo.Contract
{
    public interface ISecurityEngine
    {
        Task<ApiResponse<string>> Login(LoginViewModel loginViewModel);
        Task<ApiResponse<bool>> Logout(string token);
        Task<ApiResponse<string>> GenerateToken(SelectUserViewModel selectUserViewModel);
        Task<ApiResponse<bool>> ValidateEmail(SelectUserViewModel selectUserViewModel);
        Task<ApiResponse<bool>> RegisterAccount(RegisterViewModel registerViewModel);        
    }
}