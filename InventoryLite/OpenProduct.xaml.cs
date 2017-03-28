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
using System.Data;

namespace InventoryLite
{
    /// <summary>
    /// Interaction logic for OpenProduct.xaml
    /// </summary>
    public partial class OpenProduct : Window
    {
        private DataSet _specificItem = new DataSet();

        public OpenProduct()
        {
            InitializeComponent();
        }

        public DataSet SpecificOpenItem
        {
            get { return _specificItem; }
            set { _specificItem = value; }
        }

        private void OpenProductCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OpenProductSubmit_Click(object sender, RoutedEventArgs e)
        {
            string sku = OpenSkuBox.Text.ToString().ToUpper();

            if (string.IsNullOrEmpty(sku))
            {
                MessageBox.Show("Please Enter Product SKU");
            }
            else
            {
                SpecificOpenItem = DataAccess.GetSpecificItem(sku);

                if (SpecificOpenItem.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Could Not Find Specified SKU");
                    sku = "";
                }
                else
                {
                    Close();
                }
            }
        }

        private void OpenSkuBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                OpenProductSubmit_Click(this, new RoutedEventArgs());
            }
        }
    }
}
