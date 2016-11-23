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

namespace BallClockRepititionCounter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BallClockSimulator clockSim;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSolve(object sender, RoutedEventArgs e)
        {
            int numberOfBalls = int.Parse(TextBoxInput.Text);
            clockSim = new BallClockSimulator(numberOfBalls);
            clockSim.Solve();
            ResultLabel.Content = (clockSim.TimeDelta/1440).ToString();
        }
    }
}
