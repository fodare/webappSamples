import "dotenv/config";
import express from "express";
import bodyParser from "body-parser";
import bcrypt from "bcrypt";
import jwt from "jsonwebtoken";
import {
   addUser,
   returnUsers,
   createJwtToken,
   validateToken,
} from "./methods/userHandler.js";
import posts from "./methods/posts.js";

const app = express();
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

const serverPort = process.env.PORT;
const localSecret = process.env.SECRET;

app.listen(serverPort, () => {
   console.log(`Server listening on port ${serverPort}`);
});

app.get("/", (req, res) => {
   res.status(200).json({ message: "Server says hello!", success: true });
});

app.post("/register", (req, res) => {
   var { username, password } = req.body;
   try {
      addUser(username, password);
      res.status(201).json({ message: returnUsers(), success: true });
   } catch (error) {
      console.log(error.message);
      res.status(500).json({
         message: "Server error. Please try again!",
         success: true,
      });
   }
});

app.post("/token", (req, res) => {
   var { userName, password } = req.body;
   try {
      var result = createJwtToken(userName, password);
      if (result.success) {
         res.status(200).json({ message: result.message, success: true });
      } else {
         res.status(400).json({ message: result.message, success: false });
      }
   } catch (error) {
      console.log(error.message);
      res.status(500).json({
         message: "Server error. Please try again!",
         success: false,
      });
   }
});

app.get("/posts", (req, res) => {
   var authToken = req.headers.authorization;
   try {
      var tokenStatus = validateToken(authToken);
      if (!tokenStatus.success) {
         res.status(401).json({ message: tokenStatus.message });
      } else {
         res.status(200).json({ message: posts, success: true });
      }
   } catch (error) {
      console.log(error.message);
      res.status(500).json({ message: "Server error. Please try again!" });
   }
});
