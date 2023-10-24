import "dotenv/config";
import bcrypt from "bcrypt";
import jwt from "jsonwebtoken";

const localSecret = process.env.SECRET;
const saltingRounds = Number(process.env.SALT_ROUNDS);

// dummy user model
const userModel = {};
const accounts = [];

class User {
   constructor(userName, password) {
      this.userName = userName;
      this.password = bcrypt.hashSync(password, saltingRounds);
   }
}

function addUser(username, password) {
   try {
      var newUser = new User(username, password);
      accounts.push(newUser);
   } catch (error) {
      console.log(`Error writting user to memory. ${error.message}`);
      throw error;
   }
}

function returnUsers() {
   return accounts;
}

function createJwtToken(userName, password) {
   var foundUser = accounts.find((account) => account.userName === userName);
   if (foundUser === null) {
      return { success: false, message: "User not found" };
   } else {
      if (!bcrypt.compareSync(password, foundUser.password)) {
         return { success: false, message: "User name or password invalid!" };
      } else {
         return {
            success: true,
            message: jwt.sign(
               {
                  userName: foundUser.userName,
                  password: foundUser.password,
               },
               localSecret,
               { expiresIn: "20m" }
            ),
         };
      }
   }
}

function validateToken(jwtToken) {
   try {
      jwt.verify(jwtToken, localSecret);
      return { success: true };
   } catch (error) {
      return { success: false, message: error.message };
   }
}

export { addUser, returnUsers, createJwtToken, validateToken };
