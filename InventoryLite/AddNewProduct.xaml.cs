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

namespace InventoryLite
{
    /// <summary>
    /// Interaction logic for AddNewProduct.xaml
    /// </summary>
    public partial class AddNewProduct : Window
    {
        public AddNewProduct()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string category = CategoryBox.Text;
            string sku = SKUBox.Text;
            string description = DescriptionBox.Text;
            if (PriceBox.Text == "Price")
            {
                PriceBox.Text = "0";
            }
            decimal price = Convert.ToDecimal(PriceBox.Text);
            if (QuantityBox.Text == "Quantity")
            {
                QuantityBox.Text = "0";
            }
            decimal quantity = Convert.ToDecimal(QuantityBox.Text);
            if (CostBox.Text == "Cost")
            {
                CostBox.Text = "0";
            }
            decimal cost = Convert.ToDecimal(CostBox.Text);

            if (category != "Category" && sku != "SKU" && description != "Description" && price != 0 && quantity != 0)
            {
                int response = DataAccess.InsertNewItem(category, sku, description, price, quantity, cost);

                if (response == 0)
                {
                    MessageBox.Show("Error encountered, could not add item");
                }
                else
                {
                    MessageBox.Show("Item entered into database");

                    Close();
                }
            }
            else
            {
                PriceBox.Text = "Price";
                QuantityBox.Text = "Quantity";
                CostBox.Text = "Cost";
                MessageBox.Show("All fields except for 'Cost' are required");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CategoryBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CategoryBox.Text == "Category")
            {
                CategoryBox.Text = "";
            }
        }

        private void CategoryBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CategoryBox.Text == "")
            {
                CategoryBox.Text = "Category";
            }
        }

        private void SKUBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SKUBox.Text == "SKU")
            {
                SKUBox.Text = "";
            }
        }

        private void SKUBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SKUBox.Text == "")
            {
                SKUBox.Text = "SKU";
            }
        }

        private void DescriptionBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (DescriptionBox.Text == "Description")
            {
                DescriptionBox.Text = "";
            }
        }

        private void DescriptionBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DescriptionBox.Text == "")
            {
                DescriptionBox.Text = "Description";
            }
        }

        private void PriceBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PriceBox.Text == "Price")
            {
                PriceBox.Text = "";
            }
        }

        private void PriceBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PriceBox.Text == "")
            {
                PriceBox.Text = "Price";
            }
        }

        private void QuantityBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (QuantityBox.Text == "Quantity")
            {
                QuantityBox.Text = "";
            }
        }

        private void QuantityBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (QuantityBox.Text == "")
            {
                QuantityBox.Text = "Quantity";
            }
        }

        private void CostBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CostBox.Text == "Cost")
            {
                CostBox.Text = "";
            }
        }

        private void CostBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CostBox.Text == "")
            {
                CostBox.Text = "Cost";
            }
        }
    }
}
