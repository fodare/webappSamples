using dotnetAPI.Models;
using dotnetAPI.Models.Requests;
using dotnetAPI.Models.Responses;

namespace dotnetAPI.Services
{
    public interface IUserInterface
    {
        Task<ResponseModel<UserModel>> GetUser();
        ResponseModel<List<UserModel>> GetUsers();
        ResponseModel<UserModel> CreateUser(UserModel user);
        Task<ResponseModel<LoginResponseModel>> Login(LoginModel login);
    }
}