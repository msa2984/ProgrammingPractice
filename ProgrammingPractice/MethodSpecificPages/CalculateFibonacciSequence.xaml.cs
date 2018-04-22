using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace ProgrammingPractice.MethodSpecificPages
{
    /// <summary>
    /// Interaction logic for CalculateFibonacciSequence.xaml
    /// </summary>
    public partial class CalculateFibonacciSequence : Page
    {
        private const string MethodDescription = @"Given a user-provided number n, return the Fibonacci sequence with n entries.";

        public CalculateFibonacciSequence()
        {
            InitializeComponent();
            MethodSummaryTextBlock.Text = MethodDescription;
        }

        /// <summary>
        /// Event Handler for when any of the method buttons are pressed.
        /// </summary>
        /// <param name="sender">Reference to the control (Button) that raised this event./param>
        /// <param name="e">The data for the event raised.</param>
        private void RunFibonacciCalculate_Click(object sender, RoutedEventArgs e)
        {
            int nValue = 0;
            if (!Int32.TryParse(UserInputTextBox.Text, out nValue))
            {
                MessageBox.Show("The value of n could not be parsed! Please provide an integer.", "Calculate Fibonacci Sequence");
                ResultsGrid.Visibility = Visibility.Hidden;
            }
            else if(nValue > 93)
            {
                MessageBox.Show("The maximum value that can be displayed with a single ulong is less than the value of the 94th number in the Fibonacci sequence. Please choose a different n value!",
                    "Calculate Fibonacci Sequence");
            }
            else
            {
                switch ((sender as Button).Name)
                {
                    case "BruteForceButton":
                        ResultTextBox.Text = MathManipulation.BruteForceFibonacciCalculation(nValue);
                        break;
                    case "RecursiveButton":
                        ResultTextBox.Text = MathManipulation.RecursiveFibonacciCalculation(nValue);
                        break;
                    default:
                        throw new System.Exception("The RunFibonacciCalculate_Click event handler was called from an unexpected button!");
                }
                ResultsGrid.Visibility = Visibility.Visible;
            }

        }
    }
}
