var http = require('http');
var fs = require('fs');
var url = require('url');
var qs = require('querystring');
var template = require('./lib/template.js');
var path = require('path');
var sanitizeHtml = require('sanitize-html');
var mysql = require('mysql');

var db = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: '111111',
    database: 'opentutorials'
});
db.connect();

var app = http.createServer(function(request, response) {
    var _url = request.url;
    var queryData = url.parse(_url, true).query;
    var pathname = url.parse(_url, true).pathname;
    //기본페이지(home)
    if (pathname === '/') {
        if (queryData.id === undefined) {
            db.query(`select * from topic`, function(error, topics) {
                var title = 'Web - Board';
                var description = 'Hello';
                var list = template.list(topics);
                var html = template.HTML(title, list,
                    `<h2>${title}</h2>${description}`,
                    `<a href="/create">create</a>`
                );
                response.writeHead(200);
                response.end(html);
            });
            //게시글 선택
        } else {
            db.query(`select * from topic`, function(error, topics) {
                if (error) {
                    throw error;
                }
                db.query(`select * from topic left join author on topic.author_id=author.id where topic.id=?`, [queryData.id], function(error2, topic) {
                    if (error2) {
                        throw error2;
                    }
                    var title = topic[0].title;
                    var description = topic[0].description;
                    var list = template.list(topics);
                    var html = template.HTML(title, list,
                        `
                        <h2>${title}</h2>
                        ${description}
                        <p>by ${topic[0].name}</p>
                        `,
                        `<a href="/create">create</a> 
                         <a href="/update?id=${queryData.id}">update</a>
                         <form action="delete_process" method="post">
                            <input type="hidden" name="id" value="${queryData.id}">
                            <input type="submit" value="delete">
                        </form>`
                    );
                    response.writeHead(200);
                    response.end(html);
                });
            });
        }
        //게시글 생성
    } else if (pathname === '/create') {
        db.query(`select * from topic`, function(error, topics) {
            db.query('select * from author', function(error2, authors) {
                var title = 'Create';
                var list = template.list(topics);
                var html = template.HTML(title, list,
                    `
                    <form action="/create_process" method="post">
                    <p><input type="text" name="title" placeholder="title"></p>
                    <p>
                        <textarea name="description" placeholder="description"></textarea>
                    </p>
                    <p>
                        ${template.authorSelect(authors)}
                    </p>
                    <p>
                        <input type="submit">
                    </p>
                    </form>
                    `,
                    `<a href="/create">create</a>`
                );
                response.writeHead(200);
                response.end(html);
            });
        });
        //게시글 생성 처리
    } else if (pathname === '/create_process') {
        var body = '';
        request.on('data', function(data) {
            body = body + data;
        });
        request.on('end', function() {
            var post = qs.parse(body);
            db.query(`
            insert into topic (title, description, created, author_id) 
                values(?, ?, now(), ?)`, [post.title, post.description, post.author],
                function(error, result) {
                    if (error) {
                        throw error;
                    }
                    response.writeHead(302, { Location: `/?id=${result.insertId}` });
                    response.end();
                }
            )
        });
        // 게시글 수정
    } else if (pathname === '/update') {
        db.query('select * from topic', function(error, topics) {
            if (error) {
                throw error;
            }
            db.query(`select * from topic where id=?`, [queryData.id], function(error2, topic) {
                if (error2) {
                    throw error2;
                }
                db.query('select * from author', function(error2, authors) {
                    var list = template.list(topics);
                    var html = template.HTML(topics[0].title, list,
                        `
                        <form action="/update_process" method="post">
                        <input type="hidden" name="id" value="${topics[0].id}" >
                        <p><input type="text" name="title" placeholder="title" value="${topics[0].title}"></p>
                        <p>
                            <textarea name="description" placeholder="description">${topics[0].description}</textarea>
                        </p>
                        <p>
                            ${template.authorSelect(authors, topic[0].author_id)}
                        </p>
                        <p>
                            <input type="submit">
                        </p>
                        </form>                    
                        `,
                        `<a href="/create">create</a> <a href="/update?id=${topics[0].id}">update</a>`);

                    response.writeHead(200);
                    response.end(html);
                });
            });
        });
        //게시글 수정 처리
    } else if (pathname === '/update_process') {
        var body = '';
        request.on('data', function(data) {
            body = body + data;
        });
        request.on('end', function() {
            var post = qs.parse(body);
            db.query('update topic set title=?, description=?, author_id=? where id=?', [post.title, post.description, post.author, post.id],
                function(error, result) {
                    response.writeHead(302, { Location: `/?id=${post.id}` });
                    response.end();
                });
        });
        //게시글 삭제 처리
    } else if (pathname === '/delete_process') {
        var body = '';
        request.on('data', function(data) {
            body = body + data;
        });
        request.on('end', function() {
            var post = qs.parse(body);
            db.query('delete from topic where id = ?', [post.id], function(error, result) {
                if (error) {
                    throw error;
                }
                response.writeHead(302, { Location: `/` });
                response.end();
            });
        });
    } else {
        response.writeHead(404);
        response.end('Not found');
    }
});
app.listen(3000);