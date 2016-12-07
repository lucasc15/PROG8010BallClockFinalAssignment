/*
 * Ball Clock Simulator
 * Final Assignment PROG8010, Group 1
 * Author: Lucas Currah, 7674542
 * Conestoga College
 * 
 * Group members:
 *      Oleksandr Rudavka
 *      Jonathan Nagata
 *      Niral Gandhi
 *      Tanmay Teckchandani
 *      Priya Tharuman
 *      Krishna Kanhaiya
 *      Lucas Currah
 * 
 * 7 December, 2016
 */
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
