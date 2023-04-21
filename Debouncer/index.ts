import express from 'express';
import path from 'path';

const server = express();
const port = 5005;

server.use(express.static(path.join(__dirname, 'public')));

server.get('/', function (req, res) {
    res.sendFile('index.html', { root: __dirname });
});


server.listen(port, () => {
    console.info(`Listening on port ${port}`);
});
