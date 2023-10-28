from flask import Flask, make_response, request
from userHandler import userMethods as um 

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
        
    
if __name__ == "__main__":
    app.run(port=3000, debug=True)
    
