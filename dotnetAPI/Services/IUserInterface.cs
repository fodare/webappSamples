using dotnetAPI.Models;
using dotnetAPI.Models.Requests;
using dotnetAPI.Models.Responses;

namespace dotnetAPI.Services
{
    public interface IUserInterface
    {
        UserModel GetUser(String username);
        ResponseModel<List<UserModel>> GetUsers();
        ResponseModel<UserModel> CreateUser(UserModel user);
        ResponseModel<string> Login(LoginModel login);
    }
}