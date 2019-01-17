"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:5010/chatHub").build();

connection.on("ReceiveMessage", function (firstName, lastName, message, courseTitle) {
    if(document.getElementById("selectedChatCourse").value == courseTitle) {
        var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
        var encodedMsg =  firstName + lastName + " says " + msg;
        var li = document.createElement("li");
        li.textContent = encodedMsg;
        document.getElementById("messagesList").appendChild(li);
    }
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("messageInput").value;
    //firstName, lastName, userId, courseId, courseTitle le dai tu din obiectele lor, idk how
    connection.invoke("SendMessage", firstName, lastName, userId, courseId, courseTitle, message).catch(function (err) {
        return console.error(err.toString());
    });
    //acum aici trebuie sa faci un post la https://localhost:5010/api/chat cu un obiect Chat
    //uita-te in modelul Chat.js sa vezi ce trebuie sa contina
    //again, idk how, it'd be easier for you
    event.preventDefault();
});

//mai trebuie implementata o functie care sa faca un get la https://localhost:5010/api/chat cu id-ul cursului selectat
//de fiecare data cand se selecteaza alt curs din sidebar-ul chat-ului, ca sa primesti din baza de date
//toate mesajele acelui curs si sa le puna pe interfata