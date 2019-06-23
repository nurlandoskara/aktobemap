using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AktobeInteractive
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int CellsCount = 20;
        private const int GridX0 = 25;
        private const int GridY0 = 1;
        public double WindowWidth => SystemParameters.PrimaryScreenWidth;
        public double WindowHeight => SystemParameters.PrimaryScreenHeight;
        public double CellWidth => MapGrid.Width / CellsCount;
        public double CellHeight => MapGrid.Height / CellsCount;
        public MainWindow()
        {
            InitializeComponent();
            MapGrid.Width = WindowWidth / 100 * 45;
            MapGrid.Height = WindowHeight / 100 * 80;
            SetCoordinates();
        }

        private void SetCoordinates()
        {
            for (var i = 0; i < CellsCount; i++)
            {
                var columnDefinition = new ColumnDefinition {Width = new GridLength(CellWidth, GridUnitType.Pixel)};
                MapGrid.ColumnDefinitions.Add(columnDefinition);
                var rowDefinition = new RowDefinition {Height = new GridLength(CellHeight, GridUnitType.Pixel)};
                MapGrid.RowDefinitions.Add(rowDefinition);
            }
            SetPoint(14, 8);
        }

        private void SetPoint(int x, int y)
        {
            var brush = new ImageBrush
            {
                ImageSource = new BitmapImage(
                    new Uri("pack://application:,,,/AktobeInteractive;component/Resources/icon.png")),
                Stretch = Stretch.Uniform
            };
            var point = new Border
            {
                Background = brush,
                Height = CellHeight,
                Width = CellWidth,
            };
            Grid.SetColumn(point, x);
            Grid.SetRow(point, y);
            MapGrid.Children.Add(point);
        }

        private void MapGrid_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
#if !DEBUG
            var pointToWindow = Mouse.GetPosition(this);
            var x = pointToWindow.X;
            var y = pointToWindow.Y;
            var gridX = x - WindowWidth / 100 * GridX0;
            var gridY = y - WindowHeight / 100 * GridY0;
            var column = gridX / CellWidth;
            var row = gridY / CellHeight;
            MessageBox.Show($"{(int) column}:{(int) row}");
#endif
        }
    }
}
