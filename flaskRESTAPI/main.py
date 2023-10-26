from flask import Flask, make_response, request

app = Flask(__name__)

USERS = []
user_model = dict(username="",  password="")


def sayHello():
    message = {
        "message": "Server says hello!",
        "success": True
    }
    return make_response(message, 200)


@app.route("/register", methods=["POST"])
def register_new_user():
    content_type = request.headers.get("Content-Type")
    if content_type == "application/json":
        user_request_body = request.get_json()
        return make_response({"message": f'Hello {user_request_body["username"]}',
                              "success": True}, 201)
    else:
        return make_response(
            {"message": "Content type not supported!.", "success": False}, 400)


if __name__ == "__main__":
    app.run(port=3000, debug=True)
