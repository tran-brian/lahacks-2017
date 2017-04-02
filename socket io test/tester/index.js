var socket;

function setupSocket(url) {
	socket = io(url);

	socket.on('connect', function() {
		console.log('tester connected');
	});

	socket.on('data', function(data) {
		console.log("received data");
		console.log(data);
	});
}

function setupEventListeners() {
	console.log("setting up event listeners");

	document.getElementById("btn-data").onclick = function() {
		console.log("attempting to get data...");
		socket.emit("getdata", {});
	}
}