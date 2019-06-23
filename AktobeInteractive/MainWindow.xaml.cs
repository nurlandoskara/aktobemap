using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AktobeInteractive
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int CellsCount = 100;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SetCoordinates()
        {
            var width = MapGrid.ActualWidth / CellsCount;
            var height = MapGrid.ActualHeight / CellsCount;
            for (var i = 0; i < CellsCount; i++)
            {
                var columnDefinition = new ColumnDefinition {Width = new GridLength(CellsCount, GridUnitType.Pixel)};
                MapGrid.ColumnDefinitions.Add(columnDefinition);
            }
        }

        private void MapGrid_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var pointToWindow = Mouse.GetPosition(this);
            var x = pointToWindow.X;
            var y = pointToWindow.Y;
            var windowWidth = this.ActualWidth;
            var windowHeight = this.ActualHeight;
            var gridX0 = 55;
            var gridY0 = 10;
            var gridX = x - windowWidth / 100 * gridX0;
            var gridY = y - windowHeight / 100 * gridY0;
            var width = MapGrid.ActualWidth / CellsCount;
            var height = MapGrid.ActualHeight / CellsCount;
            var column = gridX / width;
            var row = gridY / height;
            MessageBox.Show($"{(int) column}:{(int) row}");
        }
    }
}
