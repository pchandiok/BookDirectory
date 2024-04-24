const express = require('express');
const brouter = express();
const books = require('../data/books.json');

brouter.get('/', (req, res) => {
    res.json(books);
});

brouter.get('/language/:lang', (req, res) => {
    const {lang} = req.params;
    res.json(books.filter((book) => book.language == lang));
});

brouter.get('/author/:author', (req, res) => {
    const {author} = req.params;
    res.json(books.filter((book) => book.author == author));
});

module.exports = brouter;