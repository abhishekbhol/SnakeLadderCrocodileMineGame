using SnakeLadderCrocodileMineGame.Models.Obstacles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeLadderCrocodileMineGame.Models
{
    public class Board
    {
        public int size { get; set; }
        public List<Player> players { get; set; }
        public List<IObstacle> obstacles { get; set; }
        
        public Board()
        {
            this.players = new List<Player>();
            this.obstacles = new List<IObstacle>();
        }

        public Board(int size, List<Player> players)
        {
            this.size = size;
            this.players = players;
            this.obstacles = new List<IObstacle>();
        }

        public int ActivePlayersOnBoard()
        {
            return this.players.Where(_ => _.isInPlay == true && _.currentPosition < size).Count();
        }

        public IObstacle GetObstacle(int position)
        {
            return obstacles.Where(x => x.point == position).FirstOrDefault();
        }
    }
}
