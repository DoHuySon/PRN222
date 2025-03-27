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
    /// Interaction logic for Demo3.xaml
    /// </summary>
    public partial class Demo3 : Window
    {
        public Demo3()
        {
            InitializeComponent();
            //muốn người dùng chọn 1 thì đổi mutiple thành single
            //SelectionMode = "Single"



            //đẩy dữ liệu từ database vào listbox
            //List<string> dataFromDB = new List<string> { "ABC1", "ABC2", "ABC3", "ABC4", "ABC5" };

            //// Gán dữ liệu vào ListBox
            //myListBox.ItemsSource = dataFromDB;


            //nhận giá trị từ listbox được chọn vào
            //var selectedItems = myListBox.SelectedItems;

            //// In ra danh sách mục đã chọn
            //foreach (var item in selectedItems)
            //{
            //    MessageBox.Show(item.ToString());
            //}
        }
    }
}
