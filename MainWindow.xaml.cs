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
using System.Windows.Threading;

namespace TOW.QuestCounter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        Manager outerworlds = new Manager();
        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromMilliseconds(1000);

            timer.Tick += (s, e) =>
            {
                outerworlds.FindAndHook();

                outerworlds.UpdateQuests();

                QuestCount.Content = outerworlds.QuestsCompleted;
                LastQuest.Content = outerworlds.LastQuest.Replace("_", "__");
            };

            timer.Start();
        }
    }
}
