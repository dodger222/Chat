"use strict"

var hubConnection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

let userName = "";
// receiving a message from the server
hubConnection.on("Receive", function (message, userName) {
    
    let userNameElem = document.createElement("b");
    userNameElem.appendChild(document.createTextNode(userName + ": "));
    
    let elem = document.createElement("li");
    elem.appendChild(userNameElem);
    elem.appendChild(document.createTextNode(message));

    $("#chatroom").append(elem);

    // scrolling chat
    var scrollinDiv = document.getElementById("chatroom");
    scrollinDiv.scrollTop = scrollinDiv.scrollHeight;
});

document.getElementById("sendBtn").addEventListener("click", function (e) {
    userName = document.getElementById("userName").textContent;
    let message = document.getElementById("message").value;
    document.getElementById("message").value = "";
    hubConnection.invoke("Send", message, userName);
});

hubConnection.start();
