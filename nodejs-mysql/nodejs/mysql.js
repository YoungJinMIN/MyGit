var mysql = require('mysql');
var connection = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: '111111',
    database: 'opentutorials'
});

connection.connect();

connection.query('SELECT * from topic', function(error, result) {
    if (error) {
        console.log(error);
    }
    console.log(result);
});

connection.end();