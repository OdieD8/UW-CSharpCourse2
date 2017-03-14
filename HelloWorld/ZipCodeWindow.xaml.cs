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
using System.Text.RegularExpressions;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for ZipCode.xaml
    /// </summary>
    public partial class ZipCode : Window
    {
        public ZipCode()
        {
            InitializeComponent();
        }

        string _usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";
        string _caZipRegEx = @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$";

        private void IsZipCodeValid()
        {
            if ((Regex.Match(zipCodeText.Text.ToUpper(), _usZipRegEx).Success) || (Regex.Match(zipCodeText.Text.ToUpper(), _caZipRegEx).Success))
            {
                zipCodeButton.IsEnabled = true;
            }
            else
            {
                zipCodeButton.IsEnabled = false;
            }
        }

        private void zipCodeText_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsZipCodeValid();
        }
    }
}
