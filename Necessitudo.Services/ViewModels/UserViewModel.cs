using Necessitudo.APIModels;
using Necessitudo.Models.RequestModel;
using Necessitudo.Services.Services;
using System.Threading.Tasks;

namespace Necessitudo.Services.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public UserViewModel()
        {

        }
        private readonly UserService _userService;

        public UserViewModel(UserService userService)
        {
            _userService = userService;
        }

        public async Task<ApiResponse<bool>> ResetPassword(ResetPasswordViewModel resetPasswordViewModel, string token)
        {
            return await _userService.ResetPassword(resetPasswordViewModel, token);
        }

        public async Task<ApiResponse<bool>> UpdateProfile(UpdateUserViewModel updateUserViewModel, string token)
        {
            return await _userService.UpdateProfile(updateUserViewModel, token);
        }

        public async Task<ApiResponse<APIUserViewModel>> GetUserProfile(SelectUserViewModel selectUserViewModel, string token)
        {
            return await _userService.GetUserProfile(selectUserViewModel, token);
        }

        public async Task<ApiResponse<bool>> AddSocialMediaConnection(AddSocialMediaViewModel addSocialMediaViewModel, string token)
        {
            return await _userService.AddSocialMediaConnection(addSocialMediaViewModel, token);
        }

        public async Task<ApiResponseList<APISocialMediaViewModel>> GetSocialMediaConnections(SelectUserViewModel selectUserViewModel, string token)
        {
            return await _userService.GetSocialMediaConnections(selectUserViewModel, token);
        }

        public async Task<ApiResponse<bool>> AddProfileLike(AddProfileLikeViewModel addProfileLikeViewModel, string token)
        {
            return await _userService.AddProfileLike(addProfileLikeViewModel, token);
        }

        public async Task<ApiResponse<bool>> DeleteProfileLike(ProfileLikeViewModel profileLikeViewModel, string token)
        {
            return await _userService.DeleteProfileLike(profileLikeViewModel, token);
        }

        public async Task<ApiResponseList<APIProfileLikeViewModel>> GetProfileLikes(SelectUserViewModel selectUserViewModel, string token)
        {
            return await _userService.GetProfileLikes(selectUserViewModel, token);
        }
    }
}
