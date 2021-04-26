using Microsoft.AspNetCore.SignalR;
using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz
{
    public class QuizHub : Hub
    {
        public async Task FindExistingQuiz(string username, string quizId)
        {
            var player = new Player
            {
                ConnectionId = Context.ConnectionId,
                Username = username
            };
            var quiz = QuizState.GetExistingQuiz(player, quizId);
            if (QuizState.IsUsernameTaken(quizId, username).GetValueOrDefault())
            {
                await Clients.Caller.SendAsync("UsernameTaken");
                return;
            }
            if (quiz == null)
            {
                //need to wait
                await Groups.AddToGroupAsync(player.ConnectionId, quizId);
                await Clients.Caller.SendAsync("Waiting");
                QuizState.AddToWaiting(player, quizId);
            }
        }

        public async Task MakeNewQuiz(string username, string quizId, QuizOptions quizOptions)
        {
            var player = new Player
            {
                ConnectionId = Context.ConnectionId,
                Username = username
            };
            if(QuizState.IsUsernameTaken(quizId, username).GetValueOrDefault())
            {
                await Clients.Caller.SendAsync("UsernameTaken");
            }
            var quiz = new Models.Quiz
            {
                Id = quizId,
                Players = new List<Player>() { player },
            };
            quiz.Players.Add(player);
            QuizState.GetWaitingPlayers(quizId).ForEach(player =>
            {
                quiz.Players.Add(player);
            });
            await Clients.Group(quizId).SendAsync("NewQuiz");
            QuizState.AddQuiz(quiz);

        }
    }
}
