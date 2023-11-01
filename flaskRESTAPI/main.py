from flask import Flask, make_response, request
from userHandler import userMethods as um 
from posts  import posts
app = Flask(__name__)

@app.route("/", methods=["GET"])
def say_hello():
    return make_response({"message": "Server says hello!","success":True}, 200)

@app.route("/register", methods=["POST"])
def register_user():
    request_body = request.get_json()
    result =  um.create_new_user(request_body["userName"], request_body["password"])
    if result:
        message = {
            "message": "Account created!",
            "success": True
            }
        return make_response(message, 200)
    else:
        message = {"message": "Server error. Please do try again!", "success": False}
        return make_response(message, 500)

@app.route("/login", methods=["POST"])
def login():
    request_body= request.get_json()
    try:
        result = um.login(request_body["userName"], request_body["password"])
        if result["success"]:
            message = {"success": True, "message": result["token"]}
            return make_response(message, 200)
        else: 
            message = {"success": False, "message":"Please check your input and try again!"}
            return make_response(message, 400)
    except Exception as e:
        message =  {"success": False, "message": "Server error. Please do try  again!"}
        return make_response(message, 500)
        
@app.route("/posts", methods = ["GET"])
def get_posts():
    jwt_token = request.headers['Authorization']
    if jwt_token is None:
        message = {"message":"Authorization token missing!", "sucess":False}
        return make_response(message, 401)
    else:
            if um.verify_jwt_token(jwt_token):
                message = {"message": posts, "success": True}
                return make_response(message, 200)
            else:
                message = {"message": "Invalid token!", "success": True}
                return make_response(message, 400)

@app.route("/post/<int:id>")
def get_post_by_id(id):
    jwt_token = request.headers['Authorization']
    if jwt_token is None:
        message = {"message":"Authorization token missing!", "sucess":False}
        return make_response(message, 401)
    else:
        if um.verify_jwt_token(jwt_token):
            try:
                quried_post = um.get_post(id)
                if quried_post is not None:
                    message = {"message": quried_post, "success": True}
                    return make_response(message, 200)
                else: 
                    message = {
                        "message": "Error fecthing queried post. Please try again.", 
                        "success": False
                        }
                    return make_response(message, 400)
            except Exception as e:
                message = {
                    "message":"Server error. Please try again.",
                    "success":  False
                }
                return make_response(message, 500)
        else:
            message = {"message": "Invalid token!", "success": True}
            return make_response(message, 400)
        
if __name__ == "__main__":
    app.run(port=3000)
    
