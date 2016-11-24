using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallClockRepititionCounter
{
    class BallFactory
    {
        private int idCounter = 1;
        public BallFactory()
        {
            idCounter = 1;
        }
        public Ball NewBall()
        {
            Ball ball = new Ball(idCounter);
            idCounter += 1;
            return ball;
        }
    }
    class Ball
    {
        public int ID { get; private set; } //Private setter to avoid changing ball ID
        public Ball(int id)
        {
            ID = id;
        }
    }
}
