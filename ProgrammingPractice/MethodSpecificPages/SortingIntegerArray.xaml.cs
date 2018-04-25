using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgrammingPractice.MethodSpecificPages
{
    /// <summary>
    /// Interaction logic for SortingIntegerArray.xaml
    /// </summary>
    public partial class SortingIntegerArray : Page
    {

        private const string MethodDescription = @"Given an array of integers of size N, sort the items of the array in numerical order.";

        public SortingIntegerArray()
        {
            InitializeComponent();
            MethodSummaryTextBlock.Text = MethodDescription;
        }

        /// <summary>
        /// Event Handler for when any of the method buttons are pressed.
        /// </summary>
        /// <param name="sender">Reference to the control (Button) that raised this event./param>
        /// <param name="e">The data for the event raised.</param>
        private void SortArrayContents_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int[] parsedArray = InputArrayTextBox.Text.Split(',').Select(i => Convert.ToInt32(i)).ToArray();
                int[] resultArray = null;

                switch((sender as Button).Name)
                {
                    case "BubbleSortButton":
                        resultArray = MathManipulation.PerformBubbleSort(parsedArray);
                        break;
                    case "InsertionSortButton":
                        resultArray = MathManipulation.PerformInsertionSort(parsedArray);
                        break;
                    case "QuickSortButton":
                        MathManipulation.QuickSort(parsedArray, 0, parsedArray.Length - 1);
                        resultArray = parsedArray;
                        break;
                }

                ResultsTextBox.Text = String.Format("[{0}]", String.Join(" , ", resultArray));
                ResultsGrid.Visibility = Visibility.Visible;
            }
            catch (Exception)
            {
                MessageBox.Show("Could not sort the array! Please make sure the input is correct.", "Array Sorting");
            }
        }

    }
}
