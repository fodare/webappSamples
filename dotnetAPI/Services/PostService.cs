using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using dotnetAPI.Models;
using dotnetAPI.Models.Requests;

namespace dotnetAPI.Services
{
    public class PostService : IPostService
    {
        private readonly List<PostModel> posts = new()
        {
            new() {
                userId = 1,
                id = 1,
                title = "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
                body = "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
                },
            new() {
                userId = 2,
                id = 2,
                title = "qui est esse",
                body = "consectetur animi nesciunt iure dolore\nenim quia ad\nveniam autem ut quam aut nobis\net est aut quod aut provident voluptas autem voluptas"
                },
            new() {
                userId = 3,
                id = 3,
                title = "adipisci placeat illum aut reiciendis qui",
                body = "rerum ut et numquam laborum odit est sit\nid qui sint in\nquasi tenetur tempore aperiam et quaerat qui"
                }
        };

        public ResponseModel<PostModel> CreatePost(PostModel post)
        {
            var response = new ResponseModel<PostModel>();
            try
            {
                posts.Add(new PostModel
                {
                    userId = post.userId,
                    id = post.id,
                    title = post.title,
                    body = post.body
                });
                response.Data = post;
                response.Message = "Post saved to memory!";
                response.success = true;
            }
            catch (Exception e)
            {
                response.Data = post;
                response.Message = $"Error saving post to memory.{e.Message}";
                response.success = false;
            }
            return response;
        }

        public ResponseModel<string> DeletePost(int postId)
        {
            var qureiedPost = posts.Find(post => post.id == postId);
            var response = new ResponseModel<string>();
            if (qureiedPost != null)
            {
                posts.Remove(qureiedPost);
                response.Message = "Post removed  successfully!";
                response.success = true;
            }
            else
            {
                response.Message = "Querid post not found";
                response.success = false;
            }
            return response;
        }

        public ResponseModel<PostModel> GetPost(int postId)
        {
            var response = new ResponseModel<PostModel>();
            response.Data = posts.Find(post => post.id == postId);
            if (response.Data != null)
            {
                response.Message = "Retrived quried post succesffully!";
                response.success = true;
            }
            else
            {
                response.Message = "Could not retrive queried post!";
                response.success = false;
            }
            return response;
        }

        public ResponseModel<List<PostModel>> GetPosts()
        {
            var response = new ResponseModel<List<PostModel>>
            {
                Data = posts.ToList<PostModel>()
            };
            if (response.Data != null)
            {
                response.Message = "Retrived posts successfully!";
                response.success = true;
            }
            else
            {
                response.Message = "Error retriving post lists.";
                response.success = false;
            }
            return response;
        }

        public ResponseModel<PostModel> UpdatePost(PostModel updatedPost, int postId)
        {
            throw new NotImplementedException();
        }
    }
}