﻿using HotelFrontend.Connection;
using HotelFrontend.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HotelFrontend
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

        }


        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Not proper MVVM but the binding just wouldn't update correctly
            var vm = (HotelViewModel)this.DataContext;

            if (textBox != null && textBox1 != null)
            {
                if (vm.SelectedGuest != null)
                {
                    textBox.Text = vm.Name;
                    textBox1.Text = vm.Address;

                }
                else
                {
                    textBox.Text = "";
                    textBox1.Text = "";
                }
            }



        }

        private void UpdateListview(object sender, RoutedEventArgs e)
        {
            var vm = (HotelViewModel)this.DataContext;
            var selection = listView.SelectedItem;
            listView.ItemsSource = new ObservableCollection<Guest>();
            listView.ItemsSource = vm.GuestList;
            listView.SelectedItem = selection;
        }
    }
}
