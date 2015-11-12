using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    public class Shot
    {
        private Square target;  //Square that is being attacked

        /// <summary>
        /// Default constructor, Unlikely to ever be used
        /// </summary>
        public Shot()
        {
            target = new Square();
        }
        public Shot(Square square)
        {
            target = square;
        }
        public Square getTarget()
        {
            return target;
        }
        public void setTarget(Square square)
        {
            target = square;
        }
    }
}
