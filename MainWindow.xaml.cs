using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rotation_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameManager gm;
        public MainWindow()
        {
            InitializeComponent();
            Initialize();

            DataContext = this;
        }

        private void Initialize()
        {
            var pm = new PlayerManager(txtPlayer1, txtPlayer2, txtPlayer3);
            gm = new GameManager(circleImage, pm);
        }

        private void Defense_Click(object sender, RoutedEventArgs e)
        {
            gm.Defend();
        }

        private void Offense_Click(object sender, RoutedEventArgs e)
        {
            gm.Attack();
        }

        private async void Swap1And2_ClickAsync(object sender, RoutedEventArgs e)
        {
            DisableButtons();
            await gm.AttackCrossAsync();
            EnableButtons();
        }        

        private async void Swap1And3_ClickAsync(object sender, RoutedEventArgs e)
        {
            DisableButtons();
            await gm.DefendCrossAsync();
            EnableButtons();
        }

        private async void Swap2And3_Click(object sender, RoutedEventArgs e)
        {
            DisableButtons();
            await gm.Swap2And3Async();
            EnableButtons();
        }
        internal void DisableButtons()
        {
            btnDefense.IsEnabled = false;
            btnOffense.IsEnabled = false;
            btnCrossDefense.IsEnabled=false;
            btnCrossOffense.IsEnabled=false;
            btnSwap2And3.IsEnabled=false;
        }

        internal void EnableButtons()
        {
            btnDefense.IsEnabled = true;
            btnOffense.IsEnabled = true;
            btnCrossDefense.IsEnabled = true;
            btnCrossOffense.IsEnabled = true;
            btnSwap2And3.IsEnabled = true;
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Topmost = true;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            DragMove();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Keyboard.ClearFocus();
        }

    }
}
