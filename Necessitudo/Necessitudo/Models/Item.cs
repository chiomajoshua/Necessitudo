namespace Necessitudo.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }

    public class SliderItem
    {
        public string Title
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }


        public string ImagePath
        {
            get;
            set;
        }
    }



    public class ApiCallResult<T>
    {
        public T Result
        {
            get;
            set;

        }


        public bool IsSuccessfull
        {
            get;
            set;
        }



        public string Message
        {
            get;
            set;


        }

    }

   


    public enum StepType
    {
        Personal, Social, Pictures, Interests
    }

    public enum AccessType
    {
        Administrator = 1,
        User
    }
    public enum AccountStatus
    {
        InActive = 0,
        PendingApproval = 1,
        Active = 2
    }

    public enum ResponseCode
    {
        Successful = 200,
        Incorrect_Username_Or_Password = 401,
        Created_Successfully = 201,
        User_Not_Found = 404,
        Failure = 400,
        Server_Failure = 500,
        Model_Invalid = 501,
        Error_Occurred = 101,
        Null_Value = 202,
        Empty_Result = 100
    }

    public class Response
    {
        public const string SUCCESSFUL = "200";
        public const string INCORRECT_USERNAME_OR_PASSWORD = "401";
        public const string USER_NOT_FOUND = "404";
        public const string CREATED_SUCCESSFULLY = "201";
        public const string FAILURE = "400";
        public const string SERVER_FAILURE = "500";
        public const string MODEL_INVALID = "501";
        public const string ERROR_OCCURED = "101";
        public const string NULL_VALUE = "202";
        public const string EMPTY_RESULT = "100";
    }

    public enum SocialMediaType
    {
        Facebook = 1,
        Instagram = 2,
        LinkedIn = 3,
        Twitter = 4
    }

    public enum CustomerStatus
    {
        FirstLaunch,
        Started,
        Completed
    }
}