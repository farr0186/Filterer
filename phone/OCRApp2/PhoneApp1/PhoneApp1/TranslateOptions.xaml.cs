﻿using System;
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
using System.Windows.Media.Imaging;
using UserInterface;
using System.Diagnostics;

namespace PhoneApp1
{
    public partial class TranslateOptions : PhoneApplicationPage
    {

        private RadioButton previouslyCheckedTo;
        private RadioButton previouslyCheckedFrom;

        private BitmapImage pic;
        string translateToLanguage;
        string translateFromLanguage;
        public TranslateOptions()
        {
            previouslyCheckedTo = null;
            previouslyCheckedFrom = null;
            translateToLanguage = "";
            translateFromLanguage = "";
            InitializeComponent();
            pic = CameraRoll.getCurrentImage();
        }



        private void translateFromCheckbox(object sender, RoutedEventArgs e)
        {
            RadioButton cb = sender as RadioButton;

            if (previouslyCheckedFrom != null)
            {
                previouslyCheckedFrom.IsChecked = false;
            }

            translateFromLanguage = cb.Content.ToString();
            previouslyCheckedFrom = cb;
        }

        private void translateToCheckbox(object sender, RoutedEventArgs e)
        {
            RadioButton cb = sender as RadioButton;
            if (previouslyCheckedTo != null)
            {
                previouslyCheckedTo.IsChecked = false;

            }
            translateToLanguage = cb.Content.ToString();
            previouslyCheckedTo = cb;
        }

        private void closePopup(object sender, RoutedEventArgs e)
        {
            returnedText.Visibility = System.Windows.Visibility.Collapsed;
            translateButton.Visibility = System.Windows.Visibility.Visible;
            translateToBox.Visibility = System.Windows.Visibility.Visible;
            translateFromBox.Visibility = System.Windows.Visibility.Visible;
            translateFromTitle.Visibility = System.Windows.Visibility.Visible;
            translateToTitle.Visibility = System.Windows.Visibility.Visible;
        }
        public void openPopup(string response)
        {
            Dispatcher.BeginInvoke(() =>
            MessageBox.Show(response)
            );
            //imageWindow.Source = newImage;
            //display image here
            Debug.WriteLine("translating from " + translateFromLanguage + " to " + translateToLanguage);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            switch (button.Name)
            {
                case "translateButton":
                    if (pic != null && !translateFromLanguage.Equals("") && !translateToLanguage.Equals(""))
                    {
                        ImagePreprocessing imagePreprocesor = new ImagePreprocessing(pic, translateToLanguage, translateFromLanguage, this);
                        imagePreprocesor.changeResolution();
                        imagePreprocesor.sendTranslationRequest();
                        //say waiting
                        returnedText.Visibility = System.Windows.Visibility.Visible;

                        //clear all other options
                        translateButton.Visibility = System.Windows.Visibility.Collapsed;
                        translateToBox.Visibility = System.Windows.Visibility.Collapsed;
                        translateFromBox.Visibility = System.Windows.Visibility.Collapsed;
                        translateFromTitle.Visibility = System.Windows.Visibility.Collapsed;
                        translateToTitle.Visibility = System.Windows.Visibility.Collapsed;

                        returnedText.Content = "waiting - click this box\nto go back";
                    }
                    break;
                default:
                    Debug.WriteLine("could not recognize button.");
                    break;
            }
        }
    }
}