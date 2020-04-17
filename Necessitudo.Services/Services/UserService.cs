using Necessitudo.APIModels;
using Necessitudo.Contract;
using Necessitudo.Models.RequestModel;
using System.Threading.Tasks;

namespace Necessitudo.Services.Services
{
    public class UserService
    {
        public UserService()
        {

        }

        private IUserEngine _userEngine;

        public UserService(IUserEngine userEngine)
        {
            _userEngine = userEngine;
        }

        public async Task<ApiResponse<bool>> ResetPassword(ResetPasswordViewModel resetPasswordViewModel, string token)
        {
            return await _userEngine.ResetPassword(resetPasswordViewModel, token);
        }

        public async Task<ApiResponse<bool>> UpdateProfile(UpdateUserViewModel updateUserViewModel, string token)
        {
            return await _userEngine.UpdateProfile(updateUserViewModel, token);
        }

        public async Task<ApiResponse<APIUserViewModel>> GetUserProfile(SelectUserViewModel selectUserViewModel, string token)
        {
            return await _userEngine.GetUserProfile(selectUserViewModel, token);
        }

        public async Task<ApiResponse<bool>> AddSocialMediaConnection(AddSocialMediaViewModel addSocialMediaViewModel, string token)
        {
            return await _userEngine.AddSocialMediaConnection(addSocialMediaViewModel, token);
        }

        public async Task<ApiResponseList<APISocialMediaViewModel>> GetSocialMediaConnections(SelectUserViewModel selectUserViewModel, string token)
        {
            return await _userEngine.GetSocialMediaConnections(selectUserViewModel, token);
        }

        public async Task<ApiResponse<bool>> AddProfileLike(AddProfileLikeViewModel addProfileLikeViewModel, string token)
        {
            return await _userEngine.AddProfileLike(addProfileLikeViewModel, token);
        }

        public async Task<ApiResponse<bool>> DeleteProfileLike(ProfileLikeViewModel profileLikeViewModel, string token)
        {
            return await _userEngine.DeleteProfileLike(profileLikeViewModel, token);
        }

        public async Task<ApiResponseList<APIProfileLikeViewModel>> GetProfileLikes(SelectUserViewModel selectUserViewModel, string token)
        {
            return await _userEngine.GetProfileLikes(selectUserViewModel, token);
        }
    }
}