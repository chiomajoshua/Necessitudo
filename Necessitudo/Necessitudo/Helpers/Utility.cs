using Necessitudo.APIModels;
using Necessitudo.Models;

namespace Necessitudo.Helpers
{
    public class Utility
    {
        public static bool HandleResponseCode(string respcode, out string message)
        {
            bool isValid = false;
            message = "Unable to determine status";
            switch (respcode)
            {
                case Response.SUCCESSFUL:
                    isValid = true;
                    message = "Sucessful";
                    break;
                case Response.USER_NOT_FOUND:
                    message = "User Not Found";
                    break;
                case Response.SERVER_FAILURE:
                    message = "An Error Occured";
                    break;
                case Response.NULL_VALUE:
                    message = "Details Do Not Exist";
                    break;
                case Response.MODEL_INVALID:
                    message = "An Error Occured";
                    break;
                case Response.INCORRECT_USERNAME_OR_PASSWORD:
                    message = "Incorrect Username or Password";
                    break;
                case Response.FAILURE:
                    message = "An Error Occured";
                    break;
                case Response.ERROR_OCCURED:
                    message = "An Error Occured";
                    break;
                case Response.EMPTY_RESULT:
                    message = "Details Do Not Exist";
                    break;
                case Response.CREATED_SUCCESSFULLY:
                    message = "Created Successfully";
                    break;
            }
            return isValid;
        }

        public static UserProfile TransformCustomer(APIUserViewModel apiUserViewModel)
        {
            return new UserProfile()
            {
                AboutMe = apiUserViewModel.AboutMe,
                AccountStatus = apiUserViewModel.AccountStatus,
                AgeRange = apiUserViewModel.AgeRange,
                DateJoined = apiUserViewModel.DateJoined,
                DateofBirth = apiUserViewModel.DateofBirth,
                DealBreakers = apiUserViewModel.DealBreakers,
                DealMakers = apiUserViewModel.DealMakers,
                Email = apiUserViewModel.Email,
                FirstName = apiUserViewModel.FirstName,
                Gender = apiUserViewModel.Gender,
                Hobbies = apiUserViewModel.Hobbies,
                Id = apiUserViewModel.Id,
                ImageURL = apiUserViewModel.ImageURL,
                LastName = apiUserViewModel.LastName,
                PhoneNumber = apiUserViewModel.PhoneNumber,
                Profession = apiUserViewModel.Profession,
                StarCount = apiUserViewModel.StarCount,
                UserName = apiUserViewModel.UserName
            };
        }
    }
}
