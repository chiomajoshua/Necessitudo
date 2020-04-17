using Flurl.Http;
using Necessitudo.APIModels;
using Necessitudo.Contract;
using Necessitudo.Engine.Constants;
using Necessitudo.Models.RequestModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Necessitudo.Engine
{
    public class UserEngine : BaseEngine, IUserEngine
    {
        private readonly Dictionary<string, string> _header = new Dictionary<string, string>();

        public Task<ApiResponse<bool>> AddProfileLike(AddProfileLikeViewModel addProfileLikeViewModel, string token)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> AddSocialMediaConnection(AddSocialMediaViewModel addSocialMediaViewModel, string token)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> DeleteProfileLike(ProfileLikeViewModel profileLikeViewModel, string token)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponseList<APIProfileLikeViewModel>> GetProfileLikes(SelectUserViewModel selectUserViewModel, string token)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponseList<APISocialMediaViewModel>> GetSocialMediaConnections(SelectUserViewModel selectUserViewModel, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<APIUserViewModel>> GetUserProfile(SelectUserViewModel selectUserViewModel, string token)
        {
            try
            {
                #region headers
                _header.Clear();
                _header.Add("Authorization", "Bearer" + " " + token);
                #endregion
                return JsonConvert.DeserializeObject<ApiResponse<APIUserViewModel>>(await httpClientUtil.PostWithBody(url: Endpoints.GET_USER_PROFILE, headers: _header, selectUserViewModel));
            }
            catch (FlurlHttpException exception)
            {
                string message = HandleHttpError(exception);
                throw new NetworkErrorException(message);
            }
        }

        public Task<ApiResponse<bool>> ResetPassword(ResetPasswordViewModel resetPasswordViewModel, string token)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> UpdateProfile(UpdateUserViewModel updateUserViewModel, string token)
        {
            throw new NotImplementedException();
        }
    }
}