using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeLadderCrocodileMineGame.Models.Obstacles
{
    public class Snake : IObstacle
    {
        public int snakeHead { get; set; }
        public int snakeTail { get; set; }
        public string obstacleName { get => "Snake"; }
        public int point { get => snakeHead; }

        public Snake()
        {

        }

        public Snake(int snakeHead, int snakeTail)
        {
            if(snakeHead < snakeTail)
            {
                throw new Exception("snake can only take down the board");
            }

            this.snakeHead = snakeHead;
            this.snakeTail = snakeTail;
        }

        public bool ApplyObstacle(Player player)
        {
            player.currentPosition = snakeTail;
            return true;
        }

        public void InitializeObstacleAccordingTolevel(levelEnum level, Board board)
        {
            board.obstacles.Add(
                   new Snake
                   {
                       snakeHead = 82,   // TODO  generate random number according to board size
                        snakeTail = 45,
                   });

            board.obstacles.Add(
                new Snake
                {
                    snakeHead = 19,
                    snakeTail = 8,
                });

            if (level == levelEnum.Easy)
            {
                return;
            }           
            

            board.obstacles.Add(
                new Snake
                {
                    snakeHead = 56,
                    snakeTail = 23,
                });

            if (level == levelEnum.Medium)
            {
                return;
            }

            board.obstacles.Add(
                new Snake
                {
                    snakeHead = 78,
                    snakeTail = 49,
                });

            board.obstacles.Add(
                new Snake
                {
                    snakeHead = 99,
                    snakeTail = 10,
                });
        }
    }
}
