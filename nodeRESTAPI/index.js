import "dotenv/config";
import express from "express";
import bodyParser from "body-parser";
import bcrypt from "bcrypt";
import jwt from "jsonwebtoken";

const app = express();
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json);

const serverPort = process.env.PORT;
const localSecret = process.env.SECRET;

app.listen(serverPort, () => {
   console.log(`Server listening on port ${serverPort}`);
});

app.get("/", (req, res) => {
   res.status(200).json({ message: "Server says hello!" });
});
