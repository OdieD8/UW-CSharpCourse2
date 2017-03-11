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
using System.ComponentModel;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();

            AddHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(uxList_MouseLeftButtonUp));

            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new Models.User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });

            uxList.ItemsSource = users;
        }

        private void uxList_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            uxList.Items.SortDescriptions.Clear();
            string selected = (e.OriginalSource as FrameworkElement).Name;

            uxList.Items.SortDescriptions.Add(new SortDescription(selected.ToString(), ListSortDirection.Ascending));
        }
    }
}
