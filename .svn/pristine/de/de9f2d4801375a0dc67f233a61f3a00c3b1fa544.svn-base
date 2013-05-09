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
    /// Interaction logic for KernelSizeGaussiaSigmaInputDialog.xaml
    /// </summary>
    public partial class KernelSizeGaussiaSigmaInputDialog : Window
    {

        public int KernelSize
        {
            get
            {
                return AFConvert.ToInt(tbKernelSize.Text);
            }
        }

        public float GaussiaSigma
        {
            get
            {
                return AFConvert.ToFloat(tbGaussiaSigma.Text);
            }
        }

        public KernelSizeGaussiaSigmaInputDialog()
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
