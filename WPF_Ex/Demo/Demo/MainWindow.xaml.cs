using System.Collections.ObjectModel;
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

namespace Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ObservableCollection<string> _listBoxItems;
        private ObservableCollection<User> _users;
        private ObservableCollection<Product> _products;

        public MainWindow()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            // ===== KHỞI TẠO DỮ LIỆU CHO LISTBOX =====
            _listBoxItems = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5"
            };
            listBoxItems.ItemsSource = _listBoxItems;

            // ===== KHỞI TẠO DỮ LIỆU CHO COMBOBOX =====
            comboBoxCities.Items.Add("Hà Nội");
            comboBoxCities.Items.Add("Hồ Chí Minh");
            comboBoxCities.Items.Add("Đà Nẵng");
            comboBoxCities.Items.Add("Hải Phòng");
            comboBoxCities.Items.Add("Cần Thơ");
            comboBoxCities.SelectedIndex = 0; // Chọn item đầu tiên mặc định

            // ===== KHỞI TẠO DỮ LIỆU CHO LISTVIEW =====
            _users = new ObservableCollection<User>
            {
                new User { Id = 1, Name = "Nguyễn Văn A", Age = 25, Email = "nguyenvana@example.com" },
                new User { Id = 2, Name = "Trần Thị B", Age = 30, Email = "tranthib@example.com" },
                new User { Id = 3, Name = "Lê Văn C", Age = 22, Email = "levanc@example.com" },
                new User { Id = 4, Name = "Phạm Thị D", Age = 28, Email = "phamthid@example.com" }
            };
            listViewUsers.ItemsSource = _users;

            // ===== KHỞI TẠO DỮ LIỆU CHO DATAGRID =====
            _products = new ObservableCollection<Product>
            {
                new Product { Id = 1, Name = "Laptop Dell XPS 13", Price = 1299.99, InStock = true },
                new Product { Id = 2, Name = "iPhone 15 Pro", Price = 999.99, InStock = true },
                new Product { Id = 3, Name = "Samsung Galaxy S24", Price = 899.99, InStock = false },
                new Product { Id = 4, Name = "Màn hình LG 27 inch", Price = 299.99, InStock = true },
                new Product { Id = 5, Name = "Chuột Logitech MX Master", Price = 99.99, InStock = true }
            };
            dataGridProducts.ItemsSource = _products;
        }

        #region TEXTBLOCK & TEXTBOX EVENTS

        // === Sự kiện khi nhấn nút đổi nội dung TextBlock ===
        private void btnChangeText_Click(object sender, RoutedEventArgs e)
        {
            // Lấy nội dung từ TextBox và gán cho TextBlock
            txtBlockDisplay.Text = txtInput.Text;
            MessageBox.Show($"Đã đổi nội dung TextBlock thành: {txtInput.Text}");
        }

        // === Sự kiện khi nội dung TextBox thay đổi ===
        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Hiển thị nội dung đang gõ trong real-time
            if (!string.IsNullOrEmpty(txtInput.Text))
            {
                txtBlockDisplay.Text = "Đang gõ: " + txtInput.Text;
            }
            else
            {
                txtBlockDisplay.Text = "TextBox đang trống";
            }
        }

        #endregion

        #region CHECKBOX & RADIOBUTTON EVENTS

        // === Sự kiện khi CheckBox thay đổi trạng thái (Checked hoặc Unchecked) ===
        private void chkOption_Changed(object sender, RoutedEventArgs e)
        {
            // Thu thập tất cả các CheckBox đã chọn
            StringBuilder result = new StringBuilder("Đã chọn: ");
            bool hasSelection = false;

            if (chkOption1.IsChecked == true)
            {
                result.Append("Tùy chọn 1, ");
                hasSelection = true;
            }

            if (chkOption2.IsChecked == true)
            {
                result.Append("Tùy chọn 2, ");
                hasSelection = true;
            }

            if (chkOption3.IsChecked == true)
            {
                result.Append("Tùy chọn 3, ");
                hasSelection = true;
            }

            // Hiển thị kết quả lên TextBlock
            if (hasSelection)
            {
                txtCheckBoxResult.Text = result.ToString().TrimEnd(' ', ',');
            }
            else
            {
                txtCheckBoxResult.Text = "Chưa chọn tùy chọn nào";
            }
        }

        // === Sự kiện khi RadioButton được chọn ===
        private void radOption_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton selectedRadio = sender as RadioButton;
            if (selectedRadio != null)
            {
                txtRadioResult.Text = $"Đã chọn: {selectedRadio.Content}";
            }
        }

        #endregion

        #region LISTBOX EVENTS

        // === Sự kiện khi chọn item trong ListBox ===
        private void listBoxItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Lấy tất cả các item đã chọn (vì ListBox có thể chọn nhiều)
            if (listBoxItems.SelectedItems.Count > 0)
            {
                StringBuilder selectedItems = new StringBuilder("Đã chọn: ");
                foreach (var item in listBoxItems.SelectedItems)
                {
                    selectedItems.Append(item.ToString());
                    selectedItems.Append(", ");
                }
                txtListBoxSelection.Text = selectedItems.ToString().TrimEnd(' ', ',');
            }
            else
            {
                txtListBoxSelection.Text = "Chưa chọn item nào";
            }
        }

        // === Sự kiện khi nhấn nút thêm vào ListBox ===
        private void btnAddToListBox_Click(object sender, RoutedEventArgs e)
        {
            // Tạo item mới với index tiếp theo
            string newItem = $"Item {_listBoxItems.Count + 1}";
            _listBoxItems.Add(newItem);

            // Chọn item vừa thêm
            listBoxItems.SelectedItem = newItem;
        }

        // === Sự kiện khi nhấn nút xóa khỏi ListBox ===
        private void btnRemoveFromListBox_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra xem có item nào được chọn không
            if (listBoxItems.SelectedItems.Count > 0)
            {
                // Lấy tất cả các item đã chọn và đưa vào mảng tạm
                // (vì không thể xóa trực tiếp trong collection đang lặp)
                List<string> itemsToRemove = new List<string>();
                foreach (string item in listBoxItems.SelectedItems)
                {
                    itemsToRemove.Add(item);
                }

                // Xóa lần lượt các item đã chọn
                foreach (string item in itemsToRemove)
                {
                    _listBoxItems.Remove(item);
                }

                txtListBoxSelection.Text = "Đã xóa các item được chọn";
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một item để xóa!", "Thông báo");
            }
        }

        // === Sự kiện khi nhấn nút thêm item tùy chỉnh ===
        private void btnAddCustomItem_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNewItem.Text))
            {
                _listBoxItems.Add(txtNewItem.Text);
                txtNewItem.Clear();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập nội dung cho item mới!", "Thông báo");
            }
        }

        #endregion

        #region COMBOBOX EVENTS

        // === Sự kiện khi chọn item trong ComboBox ===
        private void comboBoxCities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxCities.SelectedItem != null)
            {
                txtComboBoxSelection.Text = $"Thành phố đã chọn: {comboBoxCities.SelectedItem}";
            }
        }

        #endregion

        #region LISTVIEW EVENTS

        // === Sự kiện khi chọn item trong ListView ===
        private void listViewUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listViewUsers.SelectedItem != null)
            {
                User selectedUser = (User)listViewUsers.SelectedItem;
                MessageBox.Show($"Đã chọn: {selectedUser.Name}", "Thông báo");
            }
        }

        // === Sự kiện khi nhấn nút xóa trong ListView ===
        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                int userId = (int)btn.Tag;
                User userToRemove = _users.FirstOrDefault(u => u.Id == userId);

                if (userToRemove != null)
                {
                    var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa {userToRemove.Name}?",
                                             "Xác nhận xóa",
                                             MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        _users.Remove(userToRemove);
                    }
                }
            }
        }

        #endregion

        #region DATAGRID EVENTS

        // === Sự kiện khi chọn dòng trong DataGrid ===
        private void dataGridProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridProducts.SelectedItem != null)
            {
                Product selectedProduct = (Product)dataGridProducts.SelectedItem;
                txtDataGridSelection.Text = $"Đã chọn: {selectedProduct.Name}, Giá: {selectedProduct.Price:C}, " +
                                        $"Trạng thái: {(selectedProduct.InStock ? "Còn hàng" : "Hết hàng")}";
            }
        }

        // === Sự kiện khi nhấn nút lưu thay đổi DataGrid ===
        private void btnSaveDataGrid_Click(object sender, RoutedEventArgs e)
        {
            // Kết thúc edit mode của cell hiện tại
            dataGridProducts.CommitEdit();

            StringBuilder result = new StringBuilder("Đã lưu thay đổi cho các sản phẩm:\n");
            foreach (Product product in _products)
            {
                result.AppendLine($"- {product.Name}: {product.Price:C}, {(product.InStock ? "Còn hàng" : "Hết hàng")}");
            }

            MessageBox.Show(result.ToString(), "Thông báo");
        }

        #endregion
    }

    // === CÁC LỚP MODEL ===
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool InStock { get; set; }
    }


}
