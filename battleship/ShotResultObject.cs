using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    public class ShotResultObject
    {
        private State state;    //State of the attacked square after the shot was fired
        /// <summary>
        /// Default constructor, unlikely to ever be used
        /// </summary>
        public ShotResultObject()
        {
            state = State.miss;
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
