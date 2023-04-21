import express = require('express');

const server = express();
const port = 5005;

server.get('/', function (req, res) {
    res.sendFile('index.html', { root: __dirname });
});

server.listen(port, () => {
    console.info(`Listening on port ${port}`);
});
