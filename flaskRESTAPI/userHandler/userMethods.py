import hashlib
import bcrypt

USERS = []

def create_new_user(user_name, user_password):
    based_password = hashlib.sha256(user_password.encode('utf8')).hexdigest()
    try:
        password_hash = bcrypt.hashpw(based_password, bcrypt.gensalt())
        new_user = {
        "username": user_name,
        "passwor": password_hash
        }
        USERS.append(new_user)
        print(password_hash)
        return True
    except Exception as e:
        print(f'Error creating user. {e}')
        return False