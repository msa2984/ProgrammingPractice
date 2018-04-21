using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace ProgrammingPractice.MethodSpecificPages
{
    /// <summary>
    /// Interaction logic for FindFirstDuplicatePage.xaml
    /// </summary>
    public partial class FindFirstDuplicatePage : Page
    {
        private const string MethodDescription = @"Given a user-provided string / array of characters, return the first character that occurs more than once.";

        public FindFirstDuplicatePage()
        {
            InitializeComponent();
            MethodSummaryTextBlock.Text = MethodDescription;
        }

        /// <summary>
        /// Event Handler for when any of the method buttons are pressed.
        /// </summary>
        /// <param name="sender">Reference to the control (Button) that raised this event./param>
        /// <param name="e">The data for the event raised.</param>
        private void RunRecurringDetection_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "BruteForceButton":
                    ResultTextBox.Text = StringManipulation.BruteForceRecurringDetection(UserInputTextBox.Text);
                    break;
                case "DictionaryLookupButton":
                    ResultTextBox.Text = StringManipulation.DictionaryLookupRecurringDetection(UserInputTextBox.Text);
                    break;
                default:
                    throw new System.Exception("The RunStringReversal_Click event handler was called from an unexpected button!");
            }
            if (ResultTextBox.Text == " ")
            {
                ResultTextBox.Text = "First recurring character is a space.";
            }
            else if(String.IsNullOrEmpty(ResultTextBox.Text))
            {
                ResultTextBox.Text = "There are no recurring characters in the provided string.";
            }                    

            ResultsGrid.Visibility = Visibility.Visible;

        }
    }
}
