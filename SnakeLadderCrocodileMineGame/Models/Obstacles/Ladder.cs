using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeLadderCrocodileMineGame.Models.Obstacles
{
    public class Ladder : IObstacle
    {
        public string obstacleName { get => "Ladder"; }
        public int ladderHead { get; set; }
        public int ladderTail { get; set; }

        public int point => ladderHead;

        public Ladder()
        {

        }

        public Ladder(int ladderHead, int ladderTail)
        {
            if (ladderHead > ladderTail)
            {
                throw new Exception("ladder can only take up the board");
            }

            this.ladderHead = ladderHead;
            this.ladderTail = ladderTail;
        }

        public bool ApplyObstacle(Player player)
        {
            player.currentPosition = ladderTail;
            return true;
        }

        public void InitializeObstacleAccordingTolevel(levelEnum level, Board board)
        {

            board.obstacles.Add(
                new Ladder
                {
                    ladderHead = 7,
                    ladderTail = 21
                });

            board.obstacles.Add(
                new Ladder
                {
                    ladderHead = 6,
                    ladderTail = 32,
                });

            if (level == levelEnum.Easy)
            {
                return;
            }


            board.obstacles.Add(
                new Ladder
                {
                    ladderHead = 27,
                    ladderTail = 65,
                });

            if (level == levelEnum.Medium)
            {
                return;
            }

            board.obstacles.Add(
                new Ladder
                {
                    ladderHead = 42,
                    ladderTail = 76,
                });

            board.obstacles.Add(
                new Ladder
                {
                    ladderHead = 13,
                    ladderTail = 84,
                });
        }

    }
}
