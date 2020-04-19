using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeLadderCrocodileMineGame.Models
{
    public class Dice
    {
        public int sides { get; set; }

        public Dice(int sides)
        {
            this.sides = sides;
        }

        public int RollTheDice()
        {
            Random r = new Random();
            return r.Next(1, this.sides + 1);
        }
    }
}
