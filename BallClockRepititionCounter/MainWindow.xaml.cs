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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows;

namespace BallClockRepititionCounter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BallClockViewModel vm;
        public MainWindow()
        {
            vm = new BallClockViewModel();
            DataContext = vm;
            InitializeComponent();
        }

        private void btnSolve(object sender, RoutedEventArgs e)
        {
            vm.Solve();
        }
    }
}
