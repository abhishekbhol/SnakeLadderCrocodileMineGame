using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeLadderCrocodileMineGame.Models.Obstacles
{
    public class Crocodile : IObstacle
    {
        public string obstacleName => "Crocodile";
        public int crocPlace { get; set; }

        public int point { get => crocPlace; }


        public Crocodile()
        { }

        public bool ApplyObstacle(Player player)
        {
            player.currentPosition -= 5;  // TODO : validate board corners
            return true;
        }

        public void InitializeObstacleAccordingTolevel(levelEnum level, Board board)
        {

            board.obstacles.Add(
                new Crocodile
                {
                    crocPlace = 18
                });

            if (level == levelEnum.Easy)
            {
                return;
            }


            board.obstacles.Add(
                new Crocodile
                {
                    crocPlace = 33
                });

            if (level == levelEnum.Medium)
            {
                return;
            }


            board.obstacles.Add(
                new Crocodile
                {
                    crocPlace = 61
                });

            board.obstacles.Add(
               new Crocodile
               {
                   crocPlace = 66
               });

        }
    }
}
