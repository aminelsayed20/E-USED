"use strict";
//const { signalR } = require("./signalr/dist/browser/signalr");
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Disable the send button until connection is established
document.getElementById("sendButton").disabled = true;



alert("chat");
connection.on("ReceiveMessage", function ( message) {
    var currentTime = new Date().toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
    var receiverImg = document.getElementById("other-user-img").value;
    document.getElementById("current-chat").insertAdjacentHTML('beforeend', `
       <div class="d-flex justify-content-start mb-4">
				<div class="img_cont_msg">
				<img src="${receiverImg}" class="rounded-circle user_img_msg">
				</div>
				<div class="msg_cotainer">
								${message}
								<span class="msg_time">${currentTime}</span>
				</div>
        </div>
    `);
});


connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    // document.getElementById("userInput").value;
    var receiver = document.getElementById("other-user").value;
    var sender = document.getElementById("current-user").value;
    var message = document.getElementById("messageInput").value;

    var senderImg = document.getElementById("current-user-img").value;

    connection.invoke("SendMessage",  receiver, sender, message).catch(function (err) {
        return console.error(err.toString());
    });
    var currentTime = new Date().toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
    document.getElementById("current-chat").insertAdjacentHTML('beforeend', `

					<div class="d-flex justify-content-end mb-4">
				<div class="msg_cotainer_send">
								${message}
								<span class="msg_time_send">${currentTime}</span>
				</div>
				<div class="img_cont_msg">
								<img src="${senderImg}" class="rounded-circle user_img_msg">
				</div>
               </div>
    `);
    document.getElementById("messageInput").value = "";

    event.preventDefault();
}); 




