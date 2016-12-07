using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForms = System.Windows.Forms;
using System.IO;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace BallClockRepititionCounter
{
    class BallClockViewModel: ObservableObject
    {
        const int kMinutesInDay = 60 * 24;
        const int kMinBalls = 27;
        const int kMaxBalls = 127;
        const string kLineEnding = "0";
        BallClockSimulator clockSim;
        private ObservableCollection<BallRepitionModel> ballCounts;
        public ObservableCollection<BallRepitionModel> BallCounts
        {
            get { return ballCounts; }
            set { ballCounts = value; OnPropertyChanged(); }
        }

        public void Solve()
        {
            ballCounts = new ObservableCollection<BallRepitionModel>();
            loadData();
            for (int i=0; i < ballCounts.Count(); i++)
            {
                clockSim = new BallClockSimulator(ballCounts[i].Balls);
                clockSim.Solve();
                ballCounts[i].Reptitions = (clockSim.TimeDelta / kMinutesInDay);
            }
            BallCounts = ballCounts;
        }
        private void loadData()
        {
            var fdb = new System.Windows.Forms.OpenFileDialog();
            WinForms.DialogResult dataFile = fdb.ShowDialog();
            if (File.Exists(fdb.FileName))
            {
                loadFile(fdb.FileName);
            }

        }
        private void loadFile(string filename)
        {
            string line;
            BallRepitionModel ballCount;
            int count;
            using (System.IO.StreamReader f =
                new System.IO.StreamReader(filename))
            {
                while ((line = f.ReadLine()) != null || line == kLineEnding)
                {
                    ballCount = new BallRepitionModel();
                    Debug.Print(line);
                    count = int.Parse(line);
                    if (count >= kMinBalls && count <= kMaxBalls)
                    {
                        ballCount.Balls = count;
                        ballCounts.Add(ballCount);
                    }
                }
            }
            BallCounts = ballCounts;
        }
    }
    public class BallRepitionModel
    {
        public int Balls { get; set; }
        public int Reptitions { get; set; }
    }
}
