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
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BallClockRepititionCounter
{
    class ObservableObject: INotifyPropertyChanged
    {
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    #endregion
}
}
