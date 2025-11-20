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
        public List<Classes.Pawn> Pawns = new List<Classes.Pawn>();

        public MainWindow()
        {
            InitializeComponent();
            MainWindow.mainWindow = this; // Исправлено: MainWindow вместо Mainwindow

            Pawns.Add(new Classes.Pawn(0, 1, false));
            Pawns.Add(new Classes.Pawn(1, 1, false));
            Pawns.Add(new Classes.Pawn(2, 1, false));
            Pawns.Add(new Classes.Pawn(3, 1, false));
            Pawns.Add(new Classes.Pawn(4, 1, false));
            Pawns.Add(new Classes.Pawn(5, 1, false));
            Pawns.Add(new Classes.Pawn(6, 1, false));
            Pawns.Add(new Classes.Pawn(7, 1, false));

            Pawns.Add(new Classes.Pawn(0, 6, true));
            Pawns.Add(new Classes.Pawn(1, 6, true));
            Pawns.Add(new Classes.Pawn(2, 6, true));
            Pawns.Add(new Classes.Pawn(3, 6, true));
            Pawns.Add(new Classes.Pawn(4, 6, true));
            Pawns.Add(new Classes.Pawn(5, 6, true));
            Pawns.Add(new Classes.Pawn(6, 6, true));
            Pawns.Add(new Classes.Pawn(7, 6, true));

            CreateFigure();
        }

        public void CreateFigure()
        {
            // Перебираем коллекцию пешек
            foreach (Classes.Pawn pawn in Pawns)
            {
                // Создаём элемент Grid с размерами тайла
                pawn.Figure = new Grid()
                {
                    Width = 50,
                    Height = 50  
                };

                if (pawn.Black) // Исправлено: pawn вместо Pawn
                    pawn.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"E:\Chess_Toshmatovv\Images\Pawn (black).png")));
                else
                    pawn.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@" E:\Chess_Toshmatovv\Images\Pawn.png")));

                // Размещаем пешку на указанной позиции
                Grid.SetColumn(pawn.Figure, pawn.X);
                Grid.SetRow(pawn.Figure, pawn.Y);

                // Подписываемся на событие нажатия на пешку
                pawn.Figure.MouseDown += pawn.SelectFigure;

                // Добавляем созданную пешку на игровую доску
                gameBoard.Children.Add(pawn.Figure);
            }
        }

        public void SelectTile(object sender, MouseButtonEventArgs e)
        {
            Grid Tile = sender as Grid;

            int X = Grid.GetColumn(Tile);
            int Y = Grid.GetRow(Tile);

            Classes.Pawn SelectPawn = Pawns.Find(x => x.Select == true); // Исправлено: Classes.Pawn SelectPawn вместо Classes.Pawn_SelectPawn

            if (SelectPawn != null)
            {
                SelectPawn.Transform(X, Y);
            }
        } // Добавлена закрывающая фигурная скобка

        public void OnSelect(Classes.Pawn SelectPawn)
        {
            foreach (Classes.Pawn Pawn in Pawns)
                if (Pawn != SelectPawn)
                    if (Pawn.Select)
                        Pawn.SelectFigure(null, null);
        }
    }
}