using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace ProgrammingPractice.MethodSpecificPages
{
    /// <summary>
    /// Interaction logic for ReverseStringInputPage.xaml
    /// </summary>
    public partial class ReverseStringInputPage : Page
    {
        private const string MethodDescription = @"Given a user-provided string, return the reversed version of that string.For example, if the user - provided string was ""ABCD"",the program should return ""DCBA"".";

        public ReverseStringInputPage()
        {
            InitializeComponent();
            MethodSummaryTextBlock.Text = MethodDescription;
        }

        /// <summary>
        /// Event Handler for when any of the method buttons are pressed.
        /// </summary>
        /// <param name="sender">Reference to the control (Button) that raised this event./param>
        /// <param name="e">The data for the event raised.</param>
        private void RunStringReversal_Click(object sender, RoutedEventArgs e)
        {
            switch((sender as Button).Name)
            {
                case "BruteForceButton":
                    ResultTextBox.Text = StringManipulation.BruteForceStringReversal(UserInputTextBox.Text);
                    break;
                case "RecursiveButton":
                    ResultTextBox.Text = StringManipulation.RecursiveStringReversal(UserInputTextBox.Text);
                    break;
                case "SwappingButton":
                    ResultTextBox.Text =StringManipulation.SwappingStringReversal(UserInputTextBox.Text);
                    break;
                default:
                    throw new System.Exception("The RunStringReversal_Click event handler was called from an unexpected button!");
            }
            ResultsGrid.Visibility = Visibility.Visible;

        }
    }
}
