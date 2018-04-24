using System;
using System.Windows;
using System.Windows.Controls;

namespace ProgrammingPractice.MethodSpecificPages
{
    /// <summary>
    /// Interaction logic for CalculateClockAngle.xaml
    /// </summary>
    public partial class CalculateClockAngle : Page
    {
        private const int MaximumHour = 12;
        private const int MaximumMinute = 59;
        private const string MethodDescription = @"Given a time of day, return the angle between the hour and minute hand on a standard clock.";

        public CalculateClockAngle()
        {
            InitializeComponent();
            MethodSummaryTextBlock.Text = MethodDescription;
            
            for(int i = 1; i <= MaximumHour; i++)
            {
                HourComboBox.Items.Add(i);
            }

            for (int i = 0; i <= MaximumMinute; i++)
            {
                MinuteComboBox.Items.Add(i);
            }
        }

        /// <summary>
        /// Event Handler for when any of the method buttons are pressed.
        /// </summary>
        /// <param name="sender">Reference to the control (Button) that raised this event./param>
        /// <param name="e">The data for the event raised.</param>
        private void CalculateHandAngle_Click(object sender, RoutedEventArgs e)
        {
            bool wasTimeParsed = true; 
            int hour = 0;
            int minute = 0;
            wasTimeParsed &= Int32.TryParse(HourComboBox.SelectedItem.ToString(), out hour);
            wasTimeParsed &= Int32.TryParse(MinuteComboBox.SelectedItem.ToString(), out minute);

            if (wasTimeParsed)
            {
                Tuple<decimal, decimal> calculationResults = MathManipulation.CalculateClockAngle(hour, minute);
                DegreeDifferenceTextBox.Text = calculationResults.Item1.ToString("###.###");
                RadianDifferenceTextBox.Text = calculationResults.Item2.ToString("###.###");
                ResultsGrid.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("A time of day was not selected! The method cannot continue.", "Calculate Clock Angle");
            }
        }
    }
}
