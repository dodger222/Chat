"use strict"

var hubConnection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

let userName = "";
let toUserId = "";
// receiving a message from the server
hubConnection.on("ReceivePrivateMessage", function (message, userName) {
    
    let userNameElem = document.createElement("b");
    userNameElem.appendChild(document.createTextNode(userName + ": "));
    
    let elem = document.createElement("li");
    elem.appendChild(userNameElem);
    elem.appendChild(document.createTextNode(message));

    $("#privateChatroom").append(elem);

    // scrolling chat
    var scrollinDiv = document.getElementById("privateChatroom");
    scrollinDiv.scrollTop = scrollinDiv.scrollHeight;
});

document.getElementById("sendBtn").addEventListener("click", function (e) {
    userName = document.getElementById("userName").textContent;
    let message = document.getElementById("privateMessage").value;
    toUserId = $('#selectedUser').val();
    document.getElementById("privateMessage").value = "";
    hubConnection.invoke("SendPrivateMessage", toUserId, message);
});

hubConnection.start();
