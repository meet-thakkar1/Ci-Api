using CI_API.Models.Data;
using CI_API.Core.Interface;
using CI_API.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CI_API.Models.ViewModels;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using CI_API.Common;
using CI_API.Common.Static;

namespace CI_API.Core.Repository
{
    public class UserRepo: GenericRepository<User> ,IUserRepo
    {
        private readonly CiApiContext _db;
        private readonly IConfiguration _config;
        
        public UserRepo(CiApiContext db, IConfiguration config) :base(db)
        {
            _db= db;
            _config = config;
           
        }
       
        public  IEnumerable<User> TestRepo()
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", 37);
            string connectionString = _config.GetConnectionString("DefaultConnection");
            var values = new { id = 38 };
            var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();   
            var user = sqlConnection.Query<User>("spGetUserById", parameters, commandType: CommandType.StoredProcedure).ToList();
            var user1 =  sqlConnection.Execute("spGetUserById", parameters, commandType: CommandType.StoredProcedure);
            sqlConnection.Close();
            var city = sqlConnection.Query<City>("select * from city");
            return user;

        }
        public  User ValidateUser(LoginVM login)
        {
            User u=  _db.Users.Where(x=>x.Email==login.Email && x.Password==login.Password).FirstOrDefault();
            return u;
        }

        public bool IsEmailRegistered(string email)
        {
            User u=_db.Users.Where(user=>user.Email==email).FirstOrDefault();
            if (u != null) { return true; }
            return false;
        }

        public IActionResult ForgotPassword(string email)
        {
            if (email == "")
            {
                return new JsonResult(new ApiResponse<bool> {Result= false,Message=StatusCodeStat.BadRequestMessage,Data=false,StatusCode= StatusCodeStat.BadRequest });
            }
            bool isEmailExists = IsEmailRegistered(email);
            if (!isEmailExists)
            {
                return new JsonResult(new ApiResponse<bool> { Result = false, Message = StatusCodeStat.InvalidEmailMessage, Data = false, StatusCode = StatusCodeStat.InvalidEmail });
            }
            string token=Guid.NewGuid().ToString();

            var connectionString = _config.GetConnectionString("DefaultConnection");
            var sql = $"insert into password_reset (email,token) values ('{email}','{token}')";
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                try
                {
                    sqlConnection.Execute($"delete from password_reset where email='{email}'");
                    sqlConnection.Execute(sql);
                }
                catch(Exception e)
                {
                    return new JsonResult(new ApiResponse<bool> { Result = false, Message = StatusCodeStat.InvalidEmailMessage, Data = false, StatusCode = StatusCodeStat.InvalidEmail });
                }
                finally
                {
                    sqlConnection.Close();
                }
                
            }
            var baseUrl = "http://localhost:4200/reset?";
            var body = "<h1>Please Click below link to reset Your password</h1>" +
               $@"<a href=""{baseUrl}email={email}&token={token}"">click here</a>";   
            
            
            SendEmailModel emailModel = new SendEmailModel(email, "Reset Password",body);
            CommonMethods c = new CommonMethods(_config);
            c.SendEmail(emailModel);
            return new JsonResult(new ApiResponse<bool> { Result = true, Message = StatusCodeStat.SuccessMessage, Data = true, StatusCode = StatusCodeStat.Success });

        }

        public IActionResult ResetPassword(ResetPassword reset)
        {
            if(reset.Password != reset.ConfirmPassword)
            {
                return new JsonResult(new ApiResponse<bool> { Data = false, Message = StatusCodeStat.BadRequestMessage, Result = false, StatusCode = StatusCodeStat.BadRequest });
            }
            if(!IsEmailRegistered(reset.Email))
            {
                return new JsonResult(new ApiResponse<bool> { Data = false, Message = StatusCodeStat.InvalidEmailMessage, Result = false, StatusCode = StatusCodeStat.InvalidEmail });
            }
            var connectionString = _config.GetConnectionString("DefaultConnection");
            PasswordReset passwordReset;
            var sql = $"select email,token,created_at as CreatedAt from password_reset where email='{reset.Email}'";
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                try
                {
                    passwordReset=sqlConnection.QuerySingleOrDefault<PasswordReset>(sql);
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            if (passwordReset == null || passwordReset.CreatedAt.Value.AddMinutes(15) < DateTime.Now || passwordReset.Token != reset.Token)
            {
                return new JsonResult(new ApiResponse<bool> { Data = false, Message = StatusCodeStat.UrlExpireMessage, Result = false, StatusCode = StatusCodeStat.UrlExpire });
            }

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                try
                {
                    sqlConnection.Execute($"Update [user] set password='{reset.Password}' where email='{reset.Email}'");
                    sqlConnection.Execute($"Delete from password_reset where email='{reset.Email}'");
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }


             return new JsonResult(new ApiResponse<bool> { Data = true, Message = StatusCodeStat.SuccessMessage, Result = true, StatusCode = StatusCodeStat.Success });
        }
    }
}
