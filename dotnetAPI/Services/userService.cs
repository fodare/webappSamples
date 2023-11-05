using dotnetAPI.Models;
using dotnetAPI.Models.Requests;
using dotnetAPI.Models.Responses;

namespace dotnetAPI.Services
{
    public class UserService : IUserInterface
    {
        public Task<ResponseModel<UserModel>> CreateUser(UserModel user)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<UserModel>> GetUser()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<LoginResponseModel>> Login(LoginModel login)
        {
            throw new NotImplementedException();
        }
    }
}