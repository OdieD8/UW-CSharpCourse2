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
        public MainWindow()
        {
            InitializeComponent();

            DataSet allItems = DataAccess.GetItems();

            //List<DataRow> itemsList = allItems.Tables[0].AsEnumerable().ToList();

            inventoryItems.ItemsSource = allItems.Tables[0].DefaultView;
        }

        public void OnNew_Click(object sender, RoutedEventArgs e)
        {

        }

        public void OnOpen_Click(object sender, RoutedEventArgs e)
        {

        }

        public void OnExit_Click(object sender, RoutedEventArgs e)
        {

        }

        public void OnFind_Click(object sender, RoutedEventArgs e)
        {

        }

        public void OnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
