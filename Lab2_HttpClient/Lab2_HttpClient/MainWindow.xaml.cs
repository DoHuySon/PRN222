using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;

namespace Lab2_HttpClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        readonly HttpClient client = new HttpClient();
        private void btnClse_Click(object sender, RoutedEventArgs e) => Close();
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lbContent.Text = string.Empty;
        }
        private async void btnViewHTML_Click(object sender, RoutedEventArgs e)
        {
            string uri = lblURL.Text;
            try
            {
                string responseBody = await client.GetStringAsync(uri);
                lbContent.Text = responseBody.Trim();
            }
            catch (HttpRequestException ex) 
            {
                MessageBox.Show($"Message : {ex.Message}");
            }
        }
    }
}