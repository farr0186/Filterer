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

namespace AForgeViewer.dialogs
{
    /// <summary>
    /// Interaction logic for RGBInputDialog.xaml
    /// </summary>
    public partial class RGBInputDialog : Window
    {

        public float Red
        {
            get
            {
                return AFConvert.ToFloat(tbRed.Text);
            }
        }

        public float Green
        {
            get
            {
                return AFConvert.ToFloat(tbGreen.Text);
            }
        }

        public float Blue
        {
            get
            {
                return AFConvert.ToFloat(tbBlue.Text);
            }
        }

        public RGBInputDialog()
        {
            InitializeComponent();
        }

        private void Button_Click_Ok(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
