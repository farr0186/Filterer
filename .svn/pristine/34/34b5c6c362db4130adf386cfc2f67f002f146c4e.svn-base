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
    /// Interaction logic for OilPaintingInputDialog.xaml
    /// </summary>
    public partial class BrushSizeInputDialog : Window
    {

        public int BrushSize
        {
            get
            {
                return AFConvert.ToInt(tbBrushSize.Text);
            }
        }

        public BrushSizeInputDialog()
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
