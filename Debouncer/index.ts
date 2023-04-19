import express = require('express');
import path = require('path'); 

const server = express();
const port = 5005;

server.get('/', function (req, res) {
    res.sendFile(path.resolve(_dirname,'index.html');
});

server.listen(port, () => {
    console.info(`Listening on port ${port}`);
});
