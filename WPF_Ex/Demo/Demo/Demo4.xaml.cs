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
using System.Windows.Shapes;

namespace Demo
{
    /// <summary>
    /// Interaction logic for Demo4.xaml
    /// </summary>
    public partial class Demo4 : Window
    {
        public Demo4()
        {
            InitializeComponent();

            // nhập giá trị date
            //if (txtDob.SelectedDate.HasValue)
            //{
            //    person.DateOfBirth = txtDob.SelectedDate.Value; // Gán vào object
            //    txtDisplay.Text = "Ngày sinh: " + person.DateOfBirth.ToString("dd/MM/yyyy"); // Hiển thị lại
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn ngày.");
            //}
        }
    }
}
