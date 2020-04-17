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
    }
}
