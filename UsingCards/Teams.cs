using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UsingCards
{
    class Teams
    {
        // Fields
        public Player player1 { get; set; }
        public Player player2 { get; set; }
        public int score { get; set; }

        // Constructor
        public Teams (Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.score = 0;
        }

        // No param constructor
        public Teams()
        {
            this.player1 = null;
            this.player2 = null;
            this.score = 0;
        }



    }
}
