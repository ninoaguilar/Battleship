using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    public class ShotObject
    {
        private Square target;

        public ShotObject()
        {
            target = new Square();
        }
        public ShotObject(Square square)
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
