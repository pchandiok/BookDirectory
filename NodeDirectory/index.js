const express = require('express');
const app = express();
const root = require("./router/index");
const books = require("./router/books");

const port = process.env.PORT || 3000;

app.use("/", root);
app.use("/books", books);

app.listen(port, () => {
    console.log(`Server running on http://localhost:${port}`);
});