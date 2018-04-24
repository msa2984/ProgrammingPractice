using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProgrammingPractice.MethodSpecificPages
{
    /// <summary>
    /// Interaction logic for SimplifyArrayContents.xaml
    /// </summary>
    public partial class SimplifyArrayContents : Page
    {
        private const string MethodDescription = @"Given an array of integers of size N, organize the array so that if the next entry is identical to the current entry, double the current entry, and replace the next entry with a 0. All zeros should be at the end of the array.";

        public SimplifyArrayContents()
        {
            InitializeComponent();
            MethodSummaryTextBlock.Text = MethodDescription;
        }

        /// <summary>
        /// Event Handler for when any of the method buttons are pressed.
        /// </summary>
        /// <param name="sender">Reference to the control (Button) that raised this event./param>
        /// <param name="e">The data for the event raised.</param>
        private void SimplifyArrayContents_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int[] parsedArray = InputArrayTextBox.Text.Split(',').Select(i => Convert.ToInt32(i)).ToArray();
                int[] resultArray = MathManipulation.PerformArraySimplification(parsedArray);
                ResultsTextBox.Text = String.Format("[{0}]", String.Join(" , ", resultArray));
                ResultsGrid.Visibility = Visibility.Visible;
            }
            catch (Exception)
            {
                MessageBox.Show("Could not simplify the array! Please make sure the input is correct.", "Array Simplificaiton");
            }
        }
    }
}
