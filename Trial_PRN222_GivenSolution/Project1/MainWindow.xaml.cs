using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Star> starList = new List<Star>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddToListButton_Click(object sender, RoutedEventArgs e)
        {
            Star star = new Star
            {
                Name = NameTextBox.Text,
                Dob = DobDatePicker.SelectedDate,
                Description = DescriptionTextBox.Text,
                Male = MaleCheckBox.IsChecked,
                Nationality = NationlityTextBox.Text
            };

            starList.Add(star);
            StarListBox.Items.Add(star.ToString());
            NameTextBox.Clear();
            DobDatePicker.SelectedDate = null;
            DescriptionTextBox.Clear();
            MaleCheckBox.IsChecked = false;
            NationlityTextBox.Clear();

        }

        private async void SendToServerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(starList);
                using (HttpClient httpClient = new HttpClient())
                {
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync("http://127.0.0.1:5000", content);
                    string responseString = await response.Content.ReadAsStringAsync(); 
                    if (responseString == "accepted")
                    {
                        MessageBox.Show("Data sucessfully sent to the server");
                    } else
                    {
                        MessageBox.Show($"Server response: {responseString}");
                    }
                }

            } catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}