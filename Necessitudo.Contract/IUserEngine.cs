using Necessitudo.APIModels;
using Necessitudo.Models.RequestModel;
using System.Threading.Tasks;

namespace Necessitudo.Contract
{
    public interface IUserEngine
    {
        Task<ApiResponse<bool>> ResetPassword(ResetPasswordViewModel resetPasswordViewModel);
        Task<ApiResponse<bool>> UpdateProfile(UpdateUserViewModel updateUserViewModel);
        Task<ApiResponse<APIUserViewModel>> GetUserProfile(SelectUserViewModel selectUserViewModel);
        Task<ApiResponse<bool>> AddSocialMediaConnection(AddSocialMediaViewModel addSocialMediaViewModel);
        Task<ApiResponseList<APISocialMediaViewModel>> GetSocialMediaConnections(SelectUserViewModel selectUserViewModel);
        Task<ApiResponse<bool>> AddProfileLike(AddProfileLikeViewModel addProfileLikeViewModel);
        Task<ApiResponse<bool>> DeleteProfileLike(ProfileLikeViewModel profileLikeViewModel);
        Task<ApiResponseList<APIProfileLikeViewModel>> GetProfileLikes(SelectUserViewModel selectUserViewModel);
    }
}