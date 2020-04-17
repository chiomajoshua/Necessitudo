using Necessitudo.APIModels;
using Necessitudo.Models.RequestModel;
using System.Threading.Tasks;

namespace Necessitudo.Contract
{
    public interface IPreferenceEngine
    {
        Task<ApiResponseList<APIPeopleViewModel>> GetSuggestedProfiles(SelectUserViewModel selectUserViewModel);
        Task<ApiResponseList<APIPeopleViewModel>> GetAllProfiles(SelectUserViewModel selectUserViewModel);
    }
}