using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeLadderCrocodileMineGame.Models
{
    public class Player
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public int currentPosition { get; set; } = 1;
        public DateTime startTime { get; set; } = DateTime.Now;
        public bool isInPlay { get; set; } = true;

        public Player(string name)
        {
            this.name = name;
            this.id = Guid.NewGuid();
        }
    }
}
