import { signalR } from "../lib/signalr/dist/browser/signalr"
const findQuiz = document.getElementById("findQuiz")
const quizNameField = document.getElementById("quizNameField")
const createQuiz = document.getElementById("createQuiz")
var connection = new signalR.HubConnectionBuilder().withUrl("/quizHub").build()

connection.start().catch(function (err) {
    return console.error(err.toString());
})

findQuiz.addEventListener("click", function (event) {
    var user = document.getElementById("usernameField").nodeValue
    connection.invoke("FindExistingQuiz", user, quizNameField.nodeValue).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
})

findQuiz.addEventListener("click", function (event) {
    var user = document.getElementById("usernameField").nodeValue
    var gameOptions = new gameOptions
    connection.invoke("FindExistingQuiz", user, quizNameField.nodeValue).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
})