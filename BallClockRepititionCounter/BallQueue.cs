using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallClockRepititionCounter
{
    // The convention for the ball queue is the <bottom, ... , top> so list.Add() adds a ball to the top of the queue
    // Next queue references a BallQueue where balls advance to the next time step, the last queue does not have a reference!
    // returnQueue represents the source queue, note that the source queue will not have a return queue!
    // Constructors support assignments that create these special cases
    class BallQueue
    {
        private BallQueue nextQueue;
        private BallQueue returnQueue;
        private int? maxQueueSize;
        private List<Ball> queue;
        public List<Ball> Queue
        {
            get { return queue; }
            set { queue = value; }
        }
        public BallQueue(int MaxQueueSize, ref BallQueue ReturnQueue, ref BallQueue NextQueue)
        {
            maxQueueSize = MaxQueueSize; // Size of queue before triggering the 'advance' event
            nextQueue = NextQueue; // The next queue that the balls are passed to; if null, they are not advanced and returned to the source
            returnQueue = ReturnQueue;
            queue = new List<Ball>();
        }
        public BallQueue(int MaxQueueSize, ref BallQueue ReturnQueue)
        {
            // Constructor for 12 hour queue
            returnQueue = ReturnQueue;
            maxQueueSize = MaxQueueSize;
            nextQueue = null;
            queue = new List<Ball>();
        }
        public BallQueue(ref BallQueue NextQueue) 
        {
            // Constructor for source queue
            maxQueueSize = null;
            nextQueue = NextQueue;
            queue = new List<Ball>();
        }
        public void advanceTime()
        {
                Ball nextBall = Queue[0];
                Queue.RemoveAt(0);
                nextQueue.AddBall(nextBall);
        }
        public void AddBall(Ball ball)
        {
            // Constructor for 5 minute and 1 hours queues
            if (maxQueueSize == null) // Case where the maxSize is null which is the source queue, where there is neither a return queue or a maxSize;
            {
                queue.Add(ball); // Put at the start of the list as this is the 'top' of a queue;
                return;
            }
            if (queue.Count() >= maxQueueSize) // Other case where there is a maxSize
            {
                for (int i = queue.Count() - 1; i >= 0; i--) // Remove the balls in reverse order and add to the return queue
                {
                    returnQueue.AddBall(queue[i]); // Add the ball to the return queue
                    queue.RemoveAt(i); // Remove the ball from the current queue
                }
                if (nextQueue != null) // Case where next queue is not null, i.e. source queue, 5 min queue, 1 hour queue
                {
                    nextQueue.AddBall(ball); // Add the ball to the top of the next queue
                }
                else
                {
                    returnQueue.AddBall(ball); // Add the ball to the bottom current queue before returning if there is not next queue (i.e. the 12 hour ball queue and the last ball is added last)
                }
            }
            else
            {
                queue.Add(ball); // if it isn't over the max size add the ball to the top of the queue
            }
        }
        public void SetNextQueue(ref BallQueue NextQueue)
        {
            nextQueue = NextQueue;
        }
    }
}
