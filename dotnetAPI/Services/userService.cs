using dotnetAPI.Models;
using dotnetAPI.Models.Requests;
using dotnetAPI.Models.Responses;

namespace dotnetAPI.Services
{
    public class UserService : IUserInterface
    {
        private readonly UserModel[] users = {
            new() {UserName = "admin", Password = "babayega", IsAdmin=true}
        };

        public Task<ResponseModel<UserModel>> CreateUser(UserModel user)
        {
            throw new NotImplementedException();
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