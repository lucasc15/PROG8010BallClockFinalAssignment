using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallClockRepititionCounter
{
    class BallClockSimulator
    {
        private List<int> initialOrder = new List<int>(); // Store initial id order of the balls in the sourceQueue; stores from top to bottom
        private BallFactory ballFactory = new BallFactory();
        private BallQueue sourceQueue, fiveMinuteQueue, oneHourQueue, twelveHourQueue;
        private int timeDelta = 0; // stores the amount of 1 minute intervals; i.e. time passed in minutes
        public int TimeDelta
        {
            get { return timeDelta; }
            private set { timeDelta = value; }
        }
        public BallClockSimulator(int numberOfBalls)
        {
            // Creates each queue with the necessary constructors for each queue type
            sourceQueue = new BallQueue(ref fiveMinuteQueue); // Balls in queue
            twelveHourQueue = new BallQueue(11, ref sourceQueue); // Balls in the 1 hour/ball queue
            oneHourQueue = new BallQueue(11, ref sourceQueue, ref twelveHourQueue); // Balls in the 5 minute/ball queue
            fiveMinuteQueue = new BallQueue(4, ref sourceQueue, ref oneHourQueue); // Balls in the 1 minute/ball queue; maxSize is 5, 
            sourceQueue.SetNextQueue(ref fiveMinuteQueue); // Need to reset because first instance points at null fiveMinuteQueue
            createSourceQueue(numberOfBalls);
        }
        private void createSourceQueue(int ballNumber)
        // Initialzes initial source queue, and populates the initial order of unique IDs for the ball
        {
            for (int i=0; i < ballNumber ; i++) // Use on less ball to one being 'fixed' and not part of the rotation/order
            {
                Ball newBall = ballFactory.NewBall();
                sourceQueue.Queue.Add(newBall);
                initialOrder.Add(newBall.ID);
            }
        }
        public int Solve()
        // Solver advances the balls until they reach the initial order in which the balls were populated
        {
            //sourceQueue.advanceTime(); // to ensure checkOrder fails on first check
            while (!checkOrder() || TimeDelta == 0)
            {
                sourceQueue.advanceTime();
                TimeDelta += 1;
            }
            return TimeDelta;
        }
        private bool checkOrder()
        // Check if there is the same initial order in the sourceQueue ball IDs as the start of the clock
        {
            if (initialOrder.Count() == sourceQueue.Queue.Count()) // If they aren't the same length we know they aren't the same
            {
                for (int i = 0; i < sourceQueue.Queue.Count(); i++)
                {
                    if (sourceQueue.Queue[i].ID != initialOrder[i])
                    {
                        return false;
                    }
                }
                return true;
            } else
            {
                return false;
            }
        }
    }
}
