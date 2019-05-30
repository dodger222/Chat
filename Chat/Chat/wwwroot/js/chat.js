"use strict"

var hubConnection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

let userName = "";
// получение сообщения от сервера
hubConnection.on("Receive", function (message, userName) {

    // создаем элемент <b> для имени пользователя
    let userNameElem = document.createElement("b");
    userNameElem.appendChild(document.createTextNode(userName + ": "));

    // создает элемент <p> для сообщения пользователя
    let elem = document.createElement("li");
    elem.appendChild(userNameElem);
    elem.appendChild(document.createTextNode(message));

    $("#chatroom").append(elem);
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
