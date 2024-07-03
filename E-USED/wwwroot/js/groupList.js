

"use strict";

//const { signalR } = require("./signalr/dist/browser/signalr");
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();




connection.on("NewGroup", function (user, groupName) {
	console.log("newgroup");
	document.getElementById("group-list").insertAdjacentHTML('beforeend', `

    <a href="/Chat/DisplayGroupChat?groupName=${encodeURIComponent(groupName)}">
							<li>
								<div class="d-flex bd-highlight">
									<div class="img_cont">
										<img src="\\Images\\group.png" class="rounded-circle user_img">
									</div>
									<div class="user_info">
										<span>${groupName}</span>
										<p>Created by ${user}</p>
									</div>
								</div>
							</li>
							</a>

    `);
});


connection.start().then(function () {

}).catch(function (err) {
	return console.error(err.toString());
});


document.getElementById("add-group").addEventListener("click", function (event) {
	// document.getElementById("userInput").value;
	var groupName = document.getElementById("group-name").value;
	/* var sender = document.getElementById("current-user").value;
	 var message = document.getElementById("messageInput").value;*/
	var user = document.getElementById("username").value;

	/* var senderImg = document.getElementById("current-user-img").value;*/

	connection.invoke("CreateGroup", user, groupName).catch(function (err) {
		return console.error(err.toString());
	});

	var currentTime = new Date().toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
	document.getElementById("group-list").insertAdjacentHTML('beforeend', `

     <a href="/Chat/DisplayGroupChat?groupName=${encodeURIComponent(groupName)}">
							<li>
								<div class="d-flex bd-highlight">
									<div class="img_cont">
										<img src="\\Images\\group.png" class="rounded-circle user_img">
									</div>
									<div class="user_info">
										<span>${groupName}</span>
										<p>Created by ${user}</p>
									</div>
								</div>
							</li>
							</a>

    `);

	event.preventDefault();
}); 