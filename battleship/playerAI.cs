using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    public class playerAI
    {
        private int x;
        private int y;
        public void guess()
        {
            //If previous shot was a miss
            miss();
            //Else
            hit();
        }

        public void miss()
        {
            Random rnd = new Random();
            x = rnd.Next(10);

            if (x % 2 == 0)
            {
                y = 1 + 2 * rnd.Next(5);
            }
            else
            {
                y = 2 * rnd.Next(5);
            }
        }

        public void hit()
        {

        }
    }
}
