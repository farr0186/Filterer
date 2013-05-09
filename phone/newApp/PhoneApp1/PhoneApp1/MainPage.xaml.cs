using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework.Media;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;

namespace UserInterface
{
    public partial class MainPage : PhoneApplicationPage
    {

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }




        private void buttonDispatcher(object sender, RoutedEventArgs e)
        {
            Button clickedButon = sender as Button;
            switch (clickedButon.Name)
            {
                case "takePic":
                    NavigationService.Navigate(new Uri("/Camera.xaml", UriKind.Relative));
                    break;
                case "cameraRoll":
                    NavigationService.Navigate(new Uri("/CameraRoll.xaml", UriKind.Relative));
                    break;
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}