var app = require('express')();
var fs = require('fs');
var os = require('os');
var path = require('path');
var http = require('http').Server(app);
var io = require('socket.io')(http);
var port = 3001;

console.log('io');
console.log(io);
app.get('/', function(req, res){
  res.send('Use your local index.html');
});

io.on('connection', function(socket) {
	console.log(io);
	console.log('established connection');

	socket.on('getdata', function(data) {
		console.log("getting data...");
		socket.emit("data", {'blah': 'foo'});
	});
});

http.listen(port, function(){
  console.log('listening on *:'+port);
});