using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI_API.Common.Static
{
    public class StatusCodeStat
    {
        public static string SuccessMessage = "Success";
        public static int Success = 200;

        public static string UnAuthorizedMessage = "Invalid UserName or Password";
        public static int UnAuthorized = 401;

        public static string FailMessage = "Failed";
        public static int Fail = 0;

        public static string NotFoundMessage = "Not Found";
        public static int NotFound = 404;

        public static string BadRequestMessage = "Bad Request";
        public static int BadRequest = 400;

        public static string UserExistsMessage = "User Already Registered";
        public static int UserExists = 0;

        public static string InvalidEmailMessage = "Email Address Invalid";
        public static int InvalidEmail = 0;

        public static string InternalServerErrorMessage = "Internal Server Error";
        public static int InternalServerError = 500;

        public static string UrlExpireMessage = "Invalid Url ";
        public static int UrlExpire = 0;
    }
}
