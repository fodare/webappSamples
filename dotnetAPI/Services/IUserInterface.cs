using dotnetAPI.Models;
using dotnetAPI.Models.Requests;
using dotnetAPI.Models.Responses;

namespace dotnetAPI.Services
{
    public interface IUserInterface
    {
        Task<ResponseModel<UserModel>> GetUser();
        Task<ResponseModel<UserModel>> CreateUser(UserModel user);
        Task<ResponseModel<LoginResponseModel>> Login(LoginModel login);
    }
}