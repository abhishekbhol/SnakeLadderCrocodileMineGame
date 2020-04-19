using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeLadderCrocodileMineGame.Models.Obstacles
{
    public interface IObstacle
    {
        public string obstacleName { get; }
        public int point { get; }
        public bool ApplyObstacle(Player player);
        public void InitializeObstacleAccordingTolevel(levelEnum level, Board board);
    }
}
