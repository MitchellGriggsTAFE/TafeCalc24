﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainMenu : Page
	{
		public MainMenu()
		{
			this.InitializeComponent();
		}

		// Event handler for Mortgage Calculator Button
		private void mortgageCalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MortgageCalculator));
		}

		// Event handler for Maths Calculator Button
		private void mathsCalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MainPage));
		}

		// Event handler for Currency Converter Button
		private void currencyConverterButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(CurrencyConverter));
		}

		// Event handler for Exit Button
		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Exit();
		}

		private async void tripCalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			var dialog = new MessageDialog("Trip calculator C# code will be developed later");
			await dialog.ShowAsync();
		}
    }
}
