"use strict";

function showJoinDiv() {
    document.getElementById("Join").style.display = "block";
    document.getElementById("Create").style.display = "none";
    document.getElementById("JoinButton").style.display = "none";
    document.getElementById("CreateButton").style.display = "block";
}

function showCreateDiv() {
    document.getElementById("Create").style.display = "block";
    document.getElementById("Join").style.display = "none";
    document.getElementById("JoinButton").style.display = "block";
    document.getElementById("CreateButton").style.display = "none";
}