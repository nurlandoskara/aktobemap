using System.Windows;
using System.Windows.Controls;

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
    }
}
