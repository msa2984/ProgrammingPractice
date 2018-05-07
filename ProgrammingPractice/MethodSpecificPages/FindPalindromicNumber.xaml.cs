using System;
using System.Windows;
using System.Windows.Controls;

namespace ProgrammingPractice.MethodSpecificPages
{
    /// <summary>
    /// Interaction logic for FindPalindromicNumber.xaml
    /// </summary>
    public partial class FindPalindromicNumber : Page
    {
        private const string MethodDescription = @"Given an integer n, find the maximum palindrome from the product of two n-sized integers, where n is less than eleven.";
        
        public FindPalindromicNumber()
        {
            InitializeComponent();
            MethodSummaryTextBlock.Text = MethodDescription;       
        }

        /// <summary>
        /// Event Handler for when any of the method buttons are pressed.
        /// </summary>
        /// <param name="sender">Reference to the control (Button) that raised this event./param>
        /// <param name="e">The data for the event raised.</param>
        private void FindPalindrome_Click(object sender, RoutedEventArgs e)
        {
            bool wasNParsed = UInt64.TryParse(NValueTextBox.Text.ToString(), out ulong nValue);
            wasNParsed &= nValue < 11; 

            if (wasNParsed)
            {
                ulong detectedPalindrome = MathManipulation.FindPalindrome(nValue);
                MaximumPalindromeTextBox.Text = detectedPalindrome.ToString();
                ResultsGrid.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("A valid integer value for n was not selected! The method cannot continue.", "Find Maximum Palindrome");
            }
        }
    }
}
