from posts import posts
import jwt
import datetime
import os
import hashlib
from argon2 import PasswordHasher
ph = PasswordHasher()
secret_key = os.environ.get("secret_key")

USERS = []


def create_new_user(user_name, user_password):
    try:
        password_hash = ph.hash(user_password)
        new_user = {
            "username": user_name,
            "password": password_hash
        }
        USERS.append(new_user)
        return True
    except Exception as e:
        print(f'Error creating user. {e}')
        return False


def login(user_name, user_password):
    for user in USERS:
        if user["username"] == user_name and ph.verify(user["password"], user_password):
            jwt_token = jwt.encode({
                "exp": datetime.datetime.now(tz=datetime.timezone.utc) + datetime.timedelta(seconds=900),
                "user": user
            }, secret_key, algorithm="HS256")
            return {"success": True, "token": jwt_token}
        elif user["username"] == user_name and not ph.verify(user["password"], user_password):
            return {"success": False, "token": None}
        else:
            return {"success": False, "token": None}


def verify_jwt_token(token):
    try:
        valid = jwt.decode(token, secret_key, algorithms=["HS256"])
        return True
    except Exception as e:
        return False


def get_post(id):
    found_post = [post for post in posts if post["id"] == id]
    return found_post
