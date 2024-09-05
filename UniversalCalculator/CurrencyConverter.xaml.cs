using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CurrencyConverter : Page
	{
		public CurrencyConverter()
		{
			this.InitializeComponent();
		}

		// Array of currency conversion rates (USD, EUR, GBP, INR)
		private readonly double[,] conversionRates = {
            // US Dollar
            { 1.0, 0.85189982, 0.72872436, 74.257327 },
            // Euro
            { 1.1739732, 1.0, 0.8556672, 87.00755 },
            // British Pound
            { 1.371907, 1.1686692, 1.0, 101.68635 },
            // Indian Rupee
            { 0.011492628, 0.013492774, 0.0098339397, 1.0 }
		};

		// Method to get the symbol for a given currency code
		private string getCurrencySymbol(string currencyCode)
		{
			// Switch statement returns the appropriate currency symbol based on the provided code
			switch (currencyCode)
			{
				case "USD":
					return "$";
				case "EUR":
					return "€";
				case "GBP":
					return "£";
				case "INR":
					return "₹";
				default:
					return string.Empty;
			}
		}

		// Event handler for currency conversion button click
		private void currencyConversionButton_Click(object sender, RoutedEventArgs e)
		{
			// Declare a double variable to hold the input amount
			double amount;

			// If the value in amountTextBox can be parsed as a double, proceed with conversion
			if (double.TryParse(amountTextBox.Text, out amount))
			{

				// Get the selected indices from the "from" and "to" ComboBoxes
				int fromIndex = fromComboBox.SelectedIndex;
				int toIndex = toComboBox.SelectedIndex;

				// Get the currency codes (first 3 characters) of the selected "from" and "to" ComboBox items 
				string fromCurrency = fromComboBox.SelectedItem.ToString().Substring(0, 3);
				string toCurrency = toComboBox.SelectedItem.ToString().Substring(0, 3);

				// Get the currency symbols using the getCurrencySymbol method
				string fromSymbol = getCurrencySymbol(fromCurrency);
				string toSymbol = getCurrencySymbol(toCurrency);

				// Get the conversion rates between the selected currencies
				double fromXToYRate = conversionRates[fromIndex, toIndex];
				double toXFromYRate = conversionRates[toIndex, fromIndex];

				// Calculate the conversion result
				double result = amount * fromXToYRate;

				// Clear any existing content in the conversion details TextBlock
				conversionDetailsTextBlock.Inlines.Clear();

				// Display the input amount and currency (first line)
				conversionDetailsTextBlock.Inlines.Add(new Run
				{
					Text = $"{fromSymbol}{amount:F0} {fromCurrency} =\n",
					FontSize = 16
				});

				// Display the converted amount and currency (second line, bold and larger font)
				conversionDetailsTextBlock.Inlines.Add(new Run
				{
					Text = $"{toSymbol}{result:F8} {toCurrency}\n\n",
					FontWeight = Windows.UI.Text.FontWeights.Bold,
					FontSize = 28
				});

				// Display the conversion rate from input currency to output currency (third line)
				conversionDetailsTextBlock.Inlines.Add(new Run
				{
					Text = $"{fromSymbol}1 {fromCurrency} = {toSymbol}{fromXToYRate:F8} {toCurrency}\n",
					FontSize = 16
				});

				// Display the conversion rate from output currency to input currency (fourth line)
				conversionDetailsTextBlock.Inlines.Add(new Run
				{
					Text = $"{toSymbol}1 {toCurrency} = {fromSymbol}{toXFromYRate:F8} {fromCurrency}",
					FontSize = 16
				});
				
			}

			// If the input amount is invalid, display an error message
			else
			{
				conversionDetailsTextBlock.Text = "Please enter a valid amount.";
				FontSize = 28;
			}
		}

		// Event handler for the exit button to return to the main menu
		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MainMenu));
		}
	}
}