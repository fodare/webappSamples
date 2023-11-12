using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetAPI.Models;
using dotnetAPI.Models.Requests;

namespace dotnetAPI.Services
{
    public interface IPostService
    {
        ResponseModel<List<PostModel>> GetPosts();

        ResponseModel<PostModel> GetPost(int postId);

        ResponseModel<PostModel> CreatePost(PostModel post);

        ResponseModel<PostModel> UpdatePost(PostModel updatedPost, int postId);

        ResponseModel<string> DeletePost(int postId);
    }
}