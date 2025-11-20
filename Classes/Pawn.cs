using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Chess_Toshmatovv.Classes
{
    public class Pawn
    {
        public int X { get; set; }

        public int Y { get; set; }

        public bool Select = false;

        public bool Black = false;

        public Grid Figure { get; set; }

        public Pawn(int X, int Y, bool black)
        {
            this.X = X;
            this.Y = Y;
            this.Black = black;

        }

        public void SelectFigure(object sender, MouseButtonEventArgs e)
        {
            bool attack = false;

            Pawn selectedPawn = MainWindow.mainWindow.Pawns.Find(x => x.Select == true);

            if (selectedPawn != null)
            {

                if (this.Black && this.Y - 1 == selectedPawn.Y && (this.X - 1 == selectedPawn.X || this.X == selectedPawn.X || this.X + 1 == selectedPawn.X) ||
                  !this.Black && this.Y + 1 == selectedPawn.Y && (this.X - 1 == selectedPawn.X || this.X == selectedPawn.X || this.X + 1 == selectedPawn.X))

                {

                    MainWindow.mainWindow.gameBoard.Children.Remove(this.Figure);

                    Grid.SetColumn(selectedPawn.Figure, this.X);
                    Grid.SetRow(selectedPawn.Figure, this.Y);

                    selectedPawn.X = this.X;
                    selectedPawn.Y = this.Y;

                    selectedPawn.SelectFigure(null, null);

                    attack = true;
                }
            }

            if (!attack)
            {
                MainWindow.mainWindow.OnSelect(this);
                {
                    if (this.Select)
                    {
                        if (this.Black)
                            this.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"E:\Chess_Toshmatovv\Images\Pawn (black).png")));
                        else
                            this.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"E:\Chess_Toshmatovv\Images\Pawn (select).png")));

                        this.Select = false;
                    }
                    else
                    {
                        this.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"E:\Chess_Toshmatovv\Images\Pawn.png")));

                        this.Select = true;
                    }
                }
            }
        }
        public void Transform(int X, int Y)
        {
            if (X != this.X)
            {
                SelectFigure(null, null);
                return;
            }

            if (!Black && ((this.Y == 1 && this.Y + 2 == Y) || this.Y + 1 == Y) ||

                Black && ((this.Y == 6 && this.Y - 2 == Y) || this.Y - 1 == Y))
            {

                Grid.SetColumn(this.Figure, X);
                Grid.SetRow(this.Figure, Y);

                this.X = X;
                this.Y = Y;
            }

            SelectFigure(null, null);
        }
    }
}