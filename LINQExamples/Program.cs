using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.WebAPIClient;

namespace LINQExamples
{
    class Program
    {
        static void Main(string[] args)
        {

            ActivityAPIClient.Track(StudentID: "S00211357", StudentName: "Jamie Bredin",
                activityName: "Rad301 2022 Week 1 Lab 1 Part 1",
                Task: "Initial Setup");

            GameObjects _gobjs = new GameObjects();

            foreach (var item in _gobjs.Collectables)
            {
                if (item.selected)
                    Console.WriteLine(" Selected {0} with value", item.id, item.val);
                else Console.WriteLine(" Not Selected {0} with value", item.id, item.val);
            }


            var selected = _gobjs.Collectables
                                 .Where(s => s.selected == true);
            foreach (var item in selected)
                Console.WriteLine("Collected {0}", item.ToString());

            var orderedSelected = _gobjs.Collectables
                                        .Where(s => s.selected == false)
                                        .OrderByDescending(s => s.val);
            foreach (var item in orderedSelected)

                Console.WriteLine("Ordered descending Not Collected {0}", item.ToString());

            var _playerXPDetails = _gobjs.players
                .Select(p => new {
                                    Name = String.Concat(p.firstName, " ", p.sceondName),
                                    PlayerXP = p.XP });

            foreach (var pxp in _playerXPDetails)
                Console.WriteLine("Player XP is {0}", 
                    String.Concat(pxp.Name, " ", pxp.PlayerXP.ToString()));


            var playerScores = (from p in _gobjs.players
                                join s in _gobjs.scores
                                on p.playerId equals s.PlayerID
                                join g in _gobjs.games
                                on  s.GameID equals g.GameID
                                select new { Game = g.GameName,
                                            Name = String.Concat(p.firstName, " ", p.sceondName),
                                             PlayerScore = s.score})
                                .OrderByDescending(order => order.PlayerScore);

            foreach (var item in playerScores)
                Console.WriteLine("Player Score for {0} ", String.Concat("Game name ", item.Game," ",item.Name," score ", item.PlayerScore.ToString())  );

            //foreach (var game in _gobjs.games)
            //    Console.WriteLine("Game is {0} ", game.ToString());
            //foreach (var player in _gobjs.players)
            //    Console.WriteLine("Player is {0}", player.ToString());
            //foreach (var score in _gobjs.scores)
            //    Console.WriteLine("Score is {0}", score.ToString());

            //Select all scores greater than 500
            var g500 = _gobjs.scores.Where(s => s.score > 500);
            foreach (GameScore item in g500)
                Console.WriteLine("{0}", item.ToString());
            //Select all players with XP > 250.

            var xp250 = _gobjs.players.Where(p => p.XP > 250);
            foreach (Player item in xp250)
                Console.WriteLine("{0}", item.ToString());
            // Select the player with the gamer tag Twinny

            Player twinny = _gobjs.players.FirstOrDefault(p => p.GamerTag == "Twinny");
            if (twinny != null)
                Console.WriteLine("{0}", twinny.ToString());
            var twinnyScores = _gobjs.scores.Where(s => s.PlayerID == twinny.playerId);
            foreach (var item in twinnyScores)
                Console.WriteLine("Score for {0} is {1}", 
                                    twinny.playerId, item.ToString());

            // Select all players that have a score greater than 300
            var scoresForPlayersOver300 = (from p in _gobjs.players
                                    join s in _gobjs.scores
                                    on p.playerId equals s.PlayerID
                                    where s.score > 300
                                    select new { player = p.GamerTag,
                                                    playerScore = s.score });

            foreach (var item in scoresForPlayersOver300)
                Console.WriteLine("{0} {1}", item.player, item.playerScore);

            Console.ReadKey();
        }
    }
}
