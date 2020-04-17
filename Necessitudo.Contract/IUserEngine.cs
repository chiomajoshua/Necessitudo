using Necessitudo.APIModels;
using Necessitudo.Models.RequestModel;
using System.Threading.Tasks;

namespace Necessitudo.Contract
{
    public interface IUserEngine
    {
        Task<ApiResponse<bool>> ResetPassword(ResetPasswordViewModel resetPasswordViewModel, string token);
        Task<ApiResponse<bool>> UpdateProfile(UpdateUserViewModel updateUserViewModel, string token);
        Task<ApiResponse<APIUserViewModel>> GetUserProfile(SelectUserViewModel selectUserViewModel, string token);
        Task<ApiResponse<bool>> AddSocialMediaConnection(AddSocialMediaViewModel addSocialMediaViewModel, string token);
        Task<ApiResponseList<APISocialMediaViewModel>> GetSocialMediaConnections(SelectUserViewModel selectUserViewModel, string token);
        Task<ApiResponse<bool>> AddProfileLike(AddProfileLikeViewModel addProfileLikeViewModel, string token);
        Task<ApiResponse<bool>> DeleteProfileLike(ProfileLikeViewModel profileLikeViewModel, string token);
        Task<ApiResponseList<APIProfileLikeViewModel>> GetProfileLikes(SelectUserViewModel selectUserViewModel, string token);
    }
}