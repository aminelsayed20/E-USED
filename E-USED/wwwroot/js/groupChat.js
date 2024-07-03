"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Disable the send button until the connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveGroupMessage", function (userName, userImg, message) {
    var currentTime = new Date().toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });

    document.getElementById("current-chat").insertAdjacentHTML('beforeend', `
       <div class="d-flex justify-content-start mb-4">
            <p>${userName}</p>
            <div class="img_cont_msg">
                <img src="${userImg}" class="rounded-circle user_img_msg">
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

    var user = document.getElementById("current-user").value;
    var groupName = document.getElementById("group-name").value;

    connection.invoke("JoinToGroup", user, groupName).catch(function (err) {
        return console.error(err.toString());
    });

    console.log("join group");
}); 

document.getElementById("sendButton").addEventListener("click", function (event) {
    var groupName = document.getElementById("group-name").value;
    var userName = document.getElementById("current-user").value;
    var userImg = document.getElementById("current-user-img").value;
    var message = document.getElementById("messageInput").value;

    connection.invoke("SendMessageToGroup", userName, userImg, groupName, message).catch(function (err) {
        return console.error(err.toString());
    });

    var currentTime = new Date().toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
    document.getElementById("current-chat").insertAdjacentHTML('beforeend', `
        <div class="d-flex justify-content-end mb-4">
            <p>${userName}</p>
            <div class="msg_cotainer_send">
                ${message}
                <span class="msg_time_send">${currentTime}</span>
            </div>
            <div class="img_cont_msg">
                <img src="${userImg}" class="rounded-circle user_img_msg">
            </div>
        </div>
    `);
    document.getElementById("messageInput").value = "";

    event.preventDefault();
});

connection.on("NewMember", function (user) {
    console.log("receive join");
    var currentTime = new Date().toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });

    document.getElementById("current-chat").insertAdjacentHTML('beforeend', `
       <div class="d-flex justify-content-center mb-4">
            <p>${user} joined the group</p>
        </div>
    `);
});