using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallClockRepititionCounter
{
    class Ball
    {
        private int idCounter = 1;
        public int ID { get; private set; } //Private constructor to control unique ids
        private Ball(int id)
        {
            ID = id;
        }
        public Ball()
        {
            return;
        }
        public Ball NewBall()
        {
            Ball ball = new Ball(idCounter);
            idCounter += 1;
            return ball;
        }
    }
}
