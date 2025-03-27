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
    /// Interaction logic for Demo2.xaml
    /// </summary>
    public partial class Demo2 : Window
    {
        public Demo2()
        {
            // nhập dữ liệu từ combobox
            //if (myComboBox.SelectedItem is ComboBoxItem selectedItem)
            //{
            //    string selectedText = selectedItem.Content.ToString();
            //    MessageBox.Show("Bạn đã chọn: " + selectedText);
            //}



            //gán dữ liệu từ database lên 
            //List<string> departments = new List<string> { "IT Department", "Human Resources", "Finance", "Marketing", "Operations" };
            //myComboBox.ItemsSource = departments;







            //Kiểm tra checkbox xem đã tích những gì và hiển thị lên
            //List<string> selectedItems = new List<string>();

            //foreach (var child in myCheckBoxPanel.Children)
            //{
            //    if (child is CheckBox checkBox && checkBox.IsChecked == true)
            //    {
            //        selectedItems.Add(checkBox.Content.ToString());
            //    }
            //}

            //// Hiển thị danh sách các mục đã chọn
            //if (selectedItems.Count > 0)
            //{
            //    MessageBox.Show("Bạn đã chọn: " + string.Join(", ", selectedItems));
            //}
            //else
            //{
            //    MessageBox.Show("Bạn chưa chọn mục nào.");
            //}


            //với 1 danh sách RADIOBUTTON xem đã chọn gì
            //foreach (var child in myRadioPanel.Children)
            //{
            //    if (child is RadioButton radioButton && radioButton.IsChecked == true)
            //    {
            //        MessageBox.Show("Bạn đã chọn: " + radioButton.Content.ToString());
            //        return; // Vì chỉ có 1 RadioButton được chọn, thoát vòng lặp ngay khi tìm thấy
            //    }
            //}

            //MessageBox.Show("Bạn chưa chọn giới tính.");

            //với 1 radiobutton 
            //if (myRadioButton.IsChecked == true)
            //{
            //    MessageBox.Show("Bạn đã chọn: " + myRadioButton.Content.ToString());
            //}
            //else
            //{
            //    MessageBox.Show("Bạn chưa chọn giới tính.");
            //}
        }
    }
}
