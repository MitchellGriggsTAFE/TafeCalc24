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
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MortgageCalculator : Page
	{
		public MortgageCalculator()
		{
			this.InitializeComponent();
		}

		private void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				// Retrieve input values
				decimal principalAmount = decimal.Parse(principalBorrowTextBox.Text);
				decimal yearlyInterestRate = decimal.Parse(yearlyInterestRateTextBox.Text) / 100; // Convert percentage to decimal
				decimal numberOfYears = decimal.Parse(yearsTextBox.Text);
				decimal numberOfMonths = decimal.Parse(monthsTextBox.Text);

				// Calculate total number of months
				decimal totalMonths = (numberOfYears * 12) + numberOfMonths;

				// Calculate monthly interest rate
				decimal monthlyInterestRate = yearlyInterestRate / 12;

				// Calculate the monthly repayment
				decimal monthlyRepayment = principalAmount *
					(monthlyInterestRate * (decimal)Math.Pow((double)(1 + monthlyInterestRate), (double)totalMonths)) /
					((decimal)Math.Pow((double)(1 + monthlyInterestRate), (double)totalMonths) - 1);

				// Display the monthly interest rate as a percentage
				monthlyInterestRateTextBox.Text = (monthlyInterestRate * 100).ToString("F2") + "%";

				// Display the monthly repayment
				monthlyRepaymentTextBox.Text = monthlyRepayment.ToString("F2"); // Format as currency
			}

			catch (FormatException)
			{
				// Handle parsing errors (e.g., invalid input)
				monthlyRepaymentTextBox.Text = "Invalid input.";
			}
			catch (Exception ex)
			{
				// Handle other potential errors
				monthlyRepaymentTextBox.Text = $"Error: {ex.Message}";
			}

		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			// Sends the user to the MainMenu
			Frame.Navigate(typeof(MainMenu));
		}
	}
}
