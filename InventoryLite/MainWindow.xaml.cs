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
using System.Data;

namespace InventoryLite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataSet openItemData = new DataSet();
        OpenProduct openProduct = new OpenProduct();

        public MainWindow()
        {
            InitializeComponent();
            GetAllItemsButton.Visibility = Visibility.Hidden;
            UpdateItemsList();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }

        public void UpdateItemsList()
        {
            DataSet allItems = DataAccess.GetItems();
            inventoryItems.ItemsSource = allItems.Tables[0].DefaultView;
        }

        public void OnNew_Click(object sender, RoutedEventArgs e)
        {
            AddNewProduct addProduct = new AddNewProduct();
            addProduct.modify = false;
            addProduct.Show();
            addProduct.Closed += AddProduct_Closed;
        }

        private void AddProduct_Closed(object sender, EventArgs e)
        {
            UpdateItemsList();
        }

        public void OnOpen_Click(object sender, RoutedEventArgs e)
        {
            openProduct.Show();
            openProduct.Closed += OpenProduct_Closed;
        }

        private void OpenProduct_Closed(object sender, EventArgs e)
        {
            openItemData = openProduct.SpecificOpenItem;
            if (openItemData.Tables.Count > 0)
            {
                if (openItemData.Tables[0].Rows.Count > 0)
                {
                    inventoryItems.ItemsSource = openItemData.Tables[0].DefaultView;
                    GetAllItemsButton.Visibility = Visibility.Visible;
                    openProduct = new OpenProduct();
                }
            }
            else
            {
                UpdateItemsList();
                openProduct = new OpenProduct();
            }
        }

        public void OnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void OnModify_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowView = (DataRowView)inventoryItems.SelectedItem;
            if (rowView != null)
            {
                string itemValue = rowView["SKU"].ToString();
                openItemData = DataAccess.GetSpecificItem(itemValue); 
            }
            else
            {
                MessageBox.Show("Please click on item you want to modify");
                return;
            }

            AddNewProduct modifyProduct = new AddNewProduct();
            modifyProduct.modify = true;
            modifyProduct.CategoryBox.Text = openItemData.Tables[0].Rows[0]["Category"].ToString();
            modifyProduct.SKUBox.Text = openItemData.Tables[0].Rows[0]["SKU"].ToString();
            modifyProduct.DescriptionBox.Text = openItemData.Tables[0].Rows[0]["Description"].ToString();
            modifyProduct.PriceBox.Text = openItemData.Tables[0].Rows[0]["Price"].ToString();
            modifyProduct.QuantityBox.Text = openItemData.Tables[0].Rows[0]["Quantity"].ToString();
            modifyProduct.CostBox.Text = openItemData.Tables[0].Rows[0]["Cost"].ToString();
            modifyProduct.Show();
            modifyProduct.Closed += AddProduct_Closed;
        }

        public void OnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GetAllItemsButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateItemsList();
            GetAllItemsButton.Visibility = Visibility.Hidden;
        }
    }
}
