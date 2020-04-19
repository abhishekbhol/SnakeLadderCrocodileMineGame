using SnakeLadderCrocodileMineGame.Models.Obstacles;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeLadderCrocodileMineGame.Models.History
{
    public class GameHistory
    {
        public IList<GameMove> moves { get; set; }

        public GameHistory()
        {
            moves = new List<GameMove>();
        }

        public void AddMove(Player currentPlayer, int num, IObstacle obstacle)
        {
            moves.Add(new GameMove
            {
                name = currentPlayer.name,
                diceNumber = num,
                obstacle = obstacle,
                currPosition = currentPlayer.currentPosition
            });
        }



        public void ViewHistory()
        {
            foreach(var move in moves)
            {
                var obstacle = move.obstacle == null ? "-" : move.obstacle.obstacleName;
                Console.WriteLine($" Player {move.name} , rolled and got {move.diceNumber} , current position : {move.currPosition},  obstacle found : {obstacle}");
            }
        }
    }

    public class GameMove
    {
        public string name { get; set; }
        public int diceNumber { get; set; }
        public int currPosition { get; set; }
        public IObstacle obstacle { get; set; }

        public GameMove()
        {

        }
        public GameMove(string player, int number, IObstacle obstacle)
        {
            this.name = name;
            this.diceNumber = number;
            this.obstacle = obstacle;
        }
    }
}
