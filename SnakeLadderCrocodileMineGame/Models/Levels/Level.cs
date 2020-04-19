using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeLadderCrocodileMineGame.Models.Levels
{
    public class Level
    {
        public levelEnum boardLevel { get; set; }

        public Level(levelEnum boardLevel)
        {
            this.boardLevel = boardLevel;
        }

    }
}
