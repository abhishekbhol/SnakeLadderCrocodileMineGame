using SnakeLadderCrocodileMineGame.Controller;
using SnakeLadderCrocodileMineGame.Models;
using System;

namespace SnakeLadderCrocodileMineGame
{
    class Program
    {       

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Snake and Ladder and crocodile and mine Game !!!!! \n");
            CommencePlay();
        }

        public static void CommencePlay()
        {
            SnakeAndLadderController controller = new SnakeAndLadderController();
            controller.Initialize();
            controller.startGame();
        }
    }
}
