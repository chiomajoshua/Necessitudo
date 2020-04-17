namespace Necessitudo.Engine.Constants
{
    public class Endpoints
    {        
       const string BASE_ENDPOINT = "https://necessitudodatingapi.azurewebsites.net/api/";


        #region Security
        public const string LOGIN_ENDPOINT = BASE_ENDPOINT + "account/Login";
        public const string LOGOUT_ENDPOINT = BASE_ENDPOINT + "account/Logout";
        public const string GENERATE_TOKEN = BASE_ENDPOINT + "account/GenerateToken";
        public const string VALIDATE_EMAIL = BASE_ENDPOINT + "account/ValidateEmail";
        #endregion

        #region Accounts
        public const string REGISTER_ACCOUNT = BASE_ENDPOINT + "account/RegisterAccount";
        public const string RESET_PASSWORD = BASE_ENDPOINT + "account/ResetPassword";
        public const string UPDATE_PROFILE = BASE_ENDPOINT + "account/UpdateProfile";
        public const string GET_USER_PROFILE = BASE_ENDPOINT + "account/GetUserProfile";
        #endregion

        #region SocialMedia
        public const string ADD_SOCIAL_MEDIA_CONNECTION = BASE_ENDPOINT + "account/AddSocialMediaConnection";
        public const string GET_SOCIAL_MEDIA_CONNECTIONS = BASE_ENDPOINT + "account/GetSocialMediaConnections";
        #endregion

        #region ProfileLikes
        public const string ADD_PROFILE_LIKE = BASE_ENDPOINT + "account/AddProfileLike";
        public const string GET_PROFILE_LIKE = BASE_ENDPOINT + "account/GetProfileLikes";
        public const string DELETE_PROFILE_LIKE = BASE_ENDPOINT + "account/DeleteProfileLike";
        #endregion

        #region Preferences
        public const string GET_ALL_PROFILES = BASE_ENDPOINT + "preference/GetAllProfiles";
        public const string GET_SUGGESTED_PROFILES = BASE_ENDPOINT + "preference/GetSuggestedProfiles";
        #endregion
    }
}
