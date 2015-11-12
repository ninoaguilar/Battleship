using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    public class ShotResultObject
    {
        private State state;

        public ShotResultObject()
        {
            state = State.MISS;
        }
        public ShotResultObject(State shotResult)
        {
            state = shotResult;
        }
        public State getState()
        {
            return state;
        }
        public void setState(State shotResult)
        {
            state = shotResult;
        }
    }
}
