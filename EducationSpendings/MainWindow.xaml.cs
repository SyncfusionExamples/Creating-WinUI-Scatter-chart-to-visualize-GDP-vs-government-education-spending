using Microsoft.UI.Xaml;

namespace EducationSpendings
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            MainChart.DataContext = new EducationExpenditure();
        }
    }
}