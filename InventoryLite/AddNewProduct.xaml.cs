using System;
using System.Collections.Generic;
using System.Data;
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
        string Category;
        string Sku;
        string Description;
        decimal Price;
        decimal Quantity;
        decimal Cost;
        public bool modify;

        public AddNewProduct()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, EventArgs e)
        {
            if (modify == false)
            {
                SubmitButton.Visibility = Visibility.Visible;
                ModifyButton.Visibility = Visibility.Hidden;
                DeleteButton.Visibility = Visibility.Hidden;
            }

            if (modify == true)
            {
                SubmitButton.Visibility = Visibility.Hidden;
                ModifyButton.Visibility = Visibility.Visible;
                DeleteButton.Visibility = Visibility.Visible;
                SKUBox.IsReadOnly = true;
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Category = CategoryBox.Text;
            Sku = SKUBox.Text;
            Description = DescriptionBox.Text;
            if (PriceBox.Text == "Price")
            {
                PriceBox.Text = "0";
            }
            Price = Convert.ToDecimal(PriceBox.Text);
            if (QuantityBox.Text == "Quantity")
            {
                QuantityBox.Text = "0";
            }
            Quantity = Convert.ToDecimal(QuantityBox.Text);
            if (CostBox.Text == "Cost")
            {
                CostBox.Text = "0";
            }
            Cost = Convert.ToDecimal(CostBox.Text);

            if (Category != "Category" && Sku != "SKU" && Description != "Description" && Price != 0 && Quantity != 0)
            {
                int response = DataAccess.InsertNewItem(Category, Sku, Description, Price, Quantity, Cost);

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

        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            Category = CategoryBox.Text;
            Sku = SKUBox.Text;
            Description = DescriptionBox.Text;
            if (PriceBox.Text == "Price")
            {
                PriceBox.Text = "0";
            }
            Price = Convert.ToDecimal(PriceBox.Text);
            if (QuantityBox.Text == "Quantity")
            {
                QuantityBox.Text = "0";
            }
            Quantity = Convert.ToDecimal(QuantityBox.Text);
            if (CostBox.Text == "Cost")
            {
                CostBox.Text = "0";
            }
            Cost = Convert.ToDecimal(CostBox.Text);

            if (Category != "Category" && Sku != "SKU" && Description != "Description" && Price != 0 && Quantity != 0)
            {
                int response = DataAccess.ModifySpecificItem(Category, Sku, Description, Price, Quantity, Cost);

                if (response == 0)
                {
                    MessageBox.Show("Error encountered, could not modify item");
                }
                else
                {
                    MessageBox.Show("Item has been modified in the database");
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


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to delete this item?", "Delete Item?", MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                string sku = SKUBox.Text;
                int response = DataAccess.DeleteSpecificItem(sku);
                if (response == 0)
                {
                    MessageBox.Show("Error encountered, could not delete item");
                }
                else
                {
                    MessageBox.Show("Item has been delete from the database");
                    Close();
                }
            }
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
