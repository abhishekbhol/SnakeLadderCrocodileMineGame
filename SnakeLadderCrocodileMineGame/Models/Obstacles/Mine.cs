using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeLadderCrocodileMineGame.Models.Obstacles
{
    public class Mine : IObstacle
    {
        public string obstacleName { get => "Mine"; }
        public int minePlace { get; set; }

        public int point { get => minePlace; }

        public Mine()
        { }

        public bool ApplyObstacle(Player player)
        {
            player.isInPlay = false;
            return true;
        }

        public void InitializeObstacleAccordingTolevel(levelEnum level, Board board)
        {

            board.obstacles.Add(
                new Mine
                {
                    minePlace = 8
                });

            board.obstacles.Add(
                new Mine
                {
                    minePlace = 55
                });

            if (level == levelEnum.Easy)
            {
                return;
            }

            board.obstacles.Add(
                new Mine
                {
                    minePlace = 30
                });

            if (level == levelEnum.Medium)
            {
                return;
            }


            board.obstacles.Add(
                new Mine
                {
                    minePlace = 77
                });

            board.obstacles.Add(
                new Mine
                {
                    minePlace = 44
                });
        }
    }
}
