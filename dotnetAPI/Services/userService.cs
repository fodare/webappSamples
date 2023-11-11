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
            response.Data = user;
            response.Message = "User account created!";
            response.success = true;
            return response;
        }

        public UserModel GetUser(String username)
        {
            var userFound = users.FirstOrDefault(user => user.UserName == username);
            if (userFound != null)
            {
                return userFound;
            }
            else
            {
                return null;
            }
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

        public ResponseModel<string> Login(LoginModel login)
        {
            var response = new ResponseModel<string>();
            var userfound = GetUser(login.UserName);
            if (userfound != null && userfound.Password == login.Password)
            {
                response.Data = "Go out, touch some grass!";
                response.Message = "Loged in successfully!";
                response.success = true;
            }
            else
            {
                response.Data = null;
                response.Message = "Login failed!";
                response.success = false;
            }
            return response;
        }
    }
}