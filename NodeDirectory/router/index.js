const express = require('express');
const root = express.Router();

root.get('/', (req, res) => {
    res.send("Book Dictionary");
});

root.get('/about', (req, res) => {
    res.send("About");
});

root.get('/contact', (req, res) => {
    res.send("Contact Us");
});
module.exports = root;