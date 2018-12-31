module.exports = {
    HTML: function(title, list, body, control) {
        return `
        <!DOCTYPE html>
        <html>
        <head>
            <title>Web - ${title}</title>
            <meta charset="utf-8">
        </head>
        <body>
            <h1><a href="/"> WEB </h1></a>
            ${list}
            ${control}
            ${body}
        </body>
        </html>  
        `;
    },
    list: function(topics) {
        var list = '<ul>';
        var i = 0;
        while (i < topics.length) {
            list = list + `<li><a href="/?id=${topics[i].id}">${topics[i].title}</a></li>`;
            i = i + 1;
        }
        list = list + '</ul>';
        return list
    },
    authorSelect: function(authors, author_id) {
        var tag = '';
        var i = 0;
        while (i < authors.length) {
            var selected = '';
            if (authors[i].id === author_id) {
                selected = 'selected';
            }
            tag = tag + `<option value="${authors[i].id}"${selected}>${authors[i].name}</option>`;
            i++;
        }
        return `
        <select name="author">
        ${tag}
        </select>        
        `
    }
}

//module.exports = template;