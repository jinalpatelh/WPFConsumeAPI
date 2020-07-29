﻿using BaseLibrary;
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

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int maxNumber = 0;
        private int currentNumber = 0;
        public MainWindow()
        {
            InitializeComponent();
            APIHelper.InitializeClient();
            nextButton.IsEnabled = false;
        }
        private async Task LoadImage(int imageNumber=0)
        {
            var comic = await ComicProcessor.LoadComic(imageNumber);
            if(imageNumber == 0)
            {
                maxNumber = comic.Num;
            }

            currentNumber = comic.Num;

            var uriSource = new Uri(comic.Img, UriKind.Absolute);
            comicImage.Source = new BitmapImage(uriSource);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadImage();
        }

        private async void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if(currentNumber < maxNumber)
            {
                currentNumber++;
                previousButton.IsEnabled = true;
                await LoadImage(currentNumber);

                if(currentNumber == maxNumber)
                {
                    nextButton.IsEnabled = false;
                }
            }
        }
        private async void previousButton_Click(object sender, RoutedEventArgs e)
        {
            if(currentNumber > 1)
            {
                currentNumber--;
                nextButton.IsEnabled = true;
                await LoadImage(currentNumber);

                if(currentNumber == 1)
                {
                    previousButton.IsEnabled = false;
                }
            }
        }

    }
}