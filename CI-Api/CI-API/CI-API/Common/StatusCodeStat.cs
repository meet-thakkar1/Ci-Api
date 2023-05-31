namespace CI_API.Common
{
    public class StatusCodeStat
    {
        public static string successMessage = "Success";
        public static int success = 200;

        public static string unAuthorizedMessage = "Invalid UserName or Password";
        public static int unAuthorized = 401;

        public static string failMessage = "Failed";
        public static int fail = 0;

        public static string notFoundMessage = "Not Found";
        public static int notFound = 404;

        public static string badRequestMessage = "Bad Request";
        public static int badRequest = 400;

        public static string userExistsMessage = "User Already Registered";
        public static int userExists = 0;
    }
}
