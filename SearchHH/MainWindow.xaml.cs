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

namespace SearchHH
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            seatchBox.Focus();
        }

        private async void searchButton_Click(object sender, RoutedEventArgs e)
        {
            Responce res = await API.Instance.Get($"vacancies?text={seatchBox.Text}&per_page=500&");

            DataContext = res.Items;
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DetailView window = new DetailView();
            window.DataContext = (sender as ListView).SelectedItem;
            window.Show();
        }

        private void seatchBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                searchButton_Click(null, null);

            e.Handled = true;
        }
    }
}
