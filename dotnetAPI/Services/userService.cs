using dotnetAPI.Models;
using dotnetAPI.Models.Requests;
using dotnetAPI.Models.Responses;
using Microsoft.AspNetCore.Identity;

namespace dotnetAPI.Services
{
    public class UserService : IUserInterface
    {
        private readonly List<UserModel> users = new(){
            new() {UserName = "admin", Password = "babayega", IsAdmin=true}
        };

        public ResponseModel<UserModel> CreateUser(UserModel user)
        {
            var response = new ResponseModel<UserModel>();
            users.Add(new UserModel { UserName = user.UserName, Password = user.Password, IsAdmin = user.IsAdmin });
            Console.WriteLine(users);
            response.Data = user;
            response.Message = "User account created!";
            response.success = true;
            return response;
        }

        public Task<ResponseModel<UserModel>> GetUser()
        {
            throw new NotImplementedException();
        }

        public ResponseModel<List<UserModel>> GetUsers()
        {
            var response = new ResponseModel<List<UserModel>>
            {
                Data = users.ToList<UserModel>()
            };
            if (response.Data != null)
            {
                response.Message = "Retrive users!";
                response.success = true;
            }
            else
            {
                response.Message = "Error retriving user list";
                response.success = false;
            }
            return response;
        }

        public Task<ResponseModel<LoginResponseModel>> Login(LoginModel login)
        {
            throw new NotImplementedException();
        }
    }
}