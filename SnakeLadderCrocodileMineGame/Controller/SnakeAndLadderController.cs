using SnakeLadderCrocodileMineGame.Models;
using SnakeLadderCrocodileMineGame.Models.History;
using SnakeLadderCrocodileMineGame.Models.Obstacles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeLadderCrocodileMineGame.Controller
{
    public class SnakeAndLadderController
    {
        public static int TOTALPLAYERS = 3;
        public int BOARDSIZE = 100;
        public levelEnum level = levelEnum.Easy;

        public Board board = null;
        public Dice dice = null;
        public GameHistory history;

        public void Initialize()
        {
            var playerList = InitializePlayers();

            board = new Board(BOARDSIZE, playerList);

            InitializeObstacles();

            dice = new Dice(6);

            history = new GameHistory();
        }

        private static List<Player> InitializePlayers()
        {
            var nameList = new String[] { "ram", "sita", "hanu", "angad", "bali", "ravan" };

            var playerList = new List<Player>();
            int playerCount = 0;

            while (playerCount < TOTALPLAYERS && playerCount < nameList.Count())
            {
                Player player = new Player(nameList[playerCount]);
                playerList.Add(player);
                playerCount++;
            }

            return playerList;
        }

        private void InitializeObstacles()
        {
            IObstacle snake = new Snake();
            snake.InitializeObstacleAccordingTolevel(level, board);

            IObstacle croc = new Crocodile();
            croc.InitializeObstacleAccordingTolevel(level, board);

            IObstacle mine = new Mine();
            mine.InitializeObstacleAccordingTolevel(level, board);

            IObstacle ladder = new Ladder();
            ladder.InitializeObstacleAccordingTolevel(level, board);
        }

        public void startGame()
        {
            Player currentPlayer = board.players.FirstOrDefault();
            int turn = 0;

            while (board.ActivePlayersOnBoard()  >  1)
            {
                var num = dice.RollTheDice();

                IObstacle obstacle = null;
                if (currentPlayer.currentPosition + num <= board.size)
                {
                    currentPlayer.currentPosition += num;
                }

                if (currentPlayer.currentPosition == board.size)
                {
                    HandleWinnerCondition(currentPlayer, num, obstacle);
                    if (board.ActivePlayersOnBoard() == 1)
                    {
                        break;
                    }
                }

                if (currentPlayer.currentPosition < board.size)
                {
                    HandleObstacleIfAny(currentPlayer, num);
                }

                turn = (turn + 1) % TOTALPLAYERS;
                currentPlayer = board.players[turn];

                while (!currentPlayer.isInPlay)
                {
                    turn = (turn + 1) % TOTALPLAYERS;
                    currentPlayer = board.players[turn];
                }

            }

            Console.WriteLine($"Congrats Winner {currentPlayer.name}, Time : {DateTime.Now - currentPlayer.startTime} ");
            Console.WriteLine();

            Console.WriteLine($"History : \n");
            history.ViewHistory();
            Console.ReadKey();
        }

        private void HandleWinnerCondition(Player currentPlayer, int num, IObstacle obstacle)
        {
            history.AddMove(currentPlayer, num, obstacle);

            Console.WriteLine($"Congrats {currentPlayer.name} reachead board end , Time : {DateTime.Now - currentPlayer.startTime}");
            Console.WriteLine();
            currentPlayer.isInPlay = false;
        }

        private void HandleObstacleIfAny(Player currentPlayer, int num)
        {
            IObstacle obstacle = board.GetObstacle(currentPlayer.currentPosition);
            bool historyAdded = false;
            while (obstacle != null && currentPlayer.isInPlay)
            {
                obstacle.ApplyObstacle(currentPlayer);

                history.AddMove(currentPlayer, num, obstacle);
                historyAdded = true;

                obstacle = board.GetObstacle(currentPlayer.currentPosition);
            }

            if (!historyAdded)
            {
                history.AddMove(currentPlayer, num, obstacle);
            }
        }
    }
}
