﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;
using CameraSlider.Frontend.Shared.ViewModels;
using CameraSlider.Frontend.Shared.Models;

namespace CameraSlider.Frontend.Forms.Pages
{
    public partial class DeviceSelectionPage : ContentPage
    {
        DeviceSelectionViewModel viewModel;

        public DeviceSelectionPage()
        {
            InitializeComponent();
            viewModel = App.ServiceLocator.DeviceSelectionViewModel;
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.RefreshAsync();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var bluetoothDevice = e.SelectedItem as IBluetoothDevice;
            if (bluetoothDevice != null)
                viewModel.ConnectToDeviceCommand.Execute(bluetoothDevice);

            // Reset selection
            (sender as ListView).SelectedItem = null;
        }
    }
}
