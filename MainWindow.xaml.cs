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
using Chess_Toshmatovv.Classes;

namespace Chess_Toshmatovv
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow mainWindow;
        public List<Pawn> Pawns = new List<Pawn>();

        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;
        }

        public void SelectTile(object sender, MouseButtonEventArgs e)
        {
        }

        public void OnSelect(Pawn currentPawn)
        {
            foreach (var pawn in Pawns)
            {
                if (pawn != currentPawn)
                {
                    pawn.Select = false;
                }
            }
        }
    }
}
