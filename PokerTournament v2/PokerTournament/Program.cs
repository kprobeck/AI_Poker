using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTournament
{
    /*
     * This program will run a five card draw poker tournament
     * for the Game AI course. This program will use separate PlayerN
     * classes (with N being the team number) for each team whose methods 
     * will be called for decisions.
     * Kevin Bierre  Spring 2017
     */
    class Program
    {
        static void Main(string[] args)
        {
            // create two players
            Human h0 = new Human(0, "Joe", 1000);
            Human h1 = new Human(1, "Sue", 1000);

            // create the Game
            Game myGame = new Game(h0, h1);

            myGame.Tournament(); // run the game
        }
    }
}
