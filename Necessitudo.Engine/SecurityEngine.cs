using Flurl.Http;
using Necessitudo.APIModels;
using Necessitudo.Contract;
using Necessitudo.Engine.Constants;
using Necessitudo.Models.RequestModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Necessitudo.Engine
{
    public class SecurityEngine : BaseEngine, ISecurityEngine
    {
        private readonly Dictionary<string, string> _header = new Dictionary<string, string>();
        public async Task<ApiResponse<string>> GenerateToken(SelectUserViewModel selectUserViewModel)
        {
            try
            {                               
               return JsonConvert.DeserializeObject<ApiResponse<string>>(await httpClientUtil.PostwithBody(Endpoints.GENERATE_TOKEN, null, selectUserViewModel));
            }
            catch (FlurlHttpException exception)
            {
                string message = HandleHttpError(exception);
                throw new NetworkErrorException(message);
            }
        }

        public async Task<ApiResponse<string>> Login(LoginViewModel loginViewModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<ApiResponse<string>>(await httpClientUtil.PostwithBody(url: Endpoints.LOGIN_ENDPOINT, null, req: loginViewModel));
            }
            catch (FlurlHttpException exception)
            {
                string message = HandleHttpError(exception);
                throw new NetworkErrorException(message);
            }
        }

        public async Task<ApiResponse<bool>> Logout(string token)
        {
            try
            {
                #region headers
                _header.Clear();
                _header.Add("Authorization", "Bearer" + " " + token);
                #endregion
                return JsonConvert.DeserializeObject<ApiResponse<bool>>(await httpClientUtil.PostwithBody(url: Endpoints.LOGOUT_ENDPOINT, headers: _header, null));
            }
            catch (FlurlHttpException exception)
            {
                string message = HandleHttpError(exception);
                throw new NetworkErrorException(message);
            }
        }

        public async Task<ApiResponse<bool>> RegisterAccount(RegisterViewModel registerViewModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<ApiResponse<bool>>(await httpClientUtil.PostwithBody(url: Endpoints.REGISTER_ACCOUNT, null, req: registerViewModel));
            }
            catch (FlurlHttpException exception)
            {
                string message = HandleHttpError(exception);
                throw new NetworkErrorException(message);
            }
        }

        public async Task<ApiResponse<bool>> ValidateEmail(SelectUserViewModel selectUserViewModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<ApiResponse<bool>>(await httpClientUtil.GetWithBody(url: Endpoints.VALIDATE_EMAIL, null, req: selectUserViewModel));
            }
            catch (FlurlHttpException exception)
            {
                string message = HandleHttpError(exception);
                throw new NetworkErrorException(message);
            }
        }
    }
}