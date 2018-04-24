using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProgrammingPractice
{
    /// <summary>
    /// Interaction logic for DisplayPane.xaml
    /// </summary>
    public partial class DisplayPane : Window
    {
        public const string WindowCaption = "Method Input Utility";
        public const string MethodPageNamespace = @"ProgrammingPractice.MethodSpecificPages";

        public DisplayPane()
        {
            this.Title = WindowCaption;
            InitializeComponent();
            FindMethodPages();
            MethodPageTabControl.SelectedIndex = 0;
            (MethodPageTabControl.SelectedContent as Frame).IsEnabled = true;
        }

        /// <summary>
        /// Event Handler for when the "About" Button is selected from Toolbar.
        /// </summary>
        /// <param name="sender">Reference to the control (About Button) that raised this event./param>
        /// <param name="e">The data for the event raised.</param>
        public void About_Click(Object sender, EventArgs e)
        {
            MessageBox.Show("This UI allows for the execution of a compilation of programming problems.\nThe code can be found at: " +
               @"https://github.com/msa2984/ProgrammingPractice" , WindowCaption);
        }

        /// <summary>
        /// Event Handler for when the user selects a different TabItem to view.
        /// </summary>
        /// <param name="sender">Reference to the control (Selecting a new TabItem) that raised this event./param>
        /// <param name="e">The data for the event raised.</param>
        private void MethodPageTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.IsActive && !((MethodPageTabControl.SelectedItem as TabItem).Content as Frame).IsEnabled)
            {
                if (MessageBox.Show("Navigating to a new tab will clear the information from the current tab! Are you sure you want to continue?",
                     WindowCaption, MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
                {
                    ((MethodPageTabControl.SelectedItem as TabItem).Content as Frame).IsEnabled = true;
                    ((e.RemovedItems[0] as TabItem).Content as Frame).IsEnabled = false;
                    foreach (TextBox tb in FindVisualChildren<TextBox>(((e.RemovedItems[0] as TabItem).Content as Frame).Content as Page))
                    {
                        tb.Text = String.Empty;
                    }

                    foreach (ComboBox cb in FindVisualChildren<ComboBox>(((e.RemovedItems[0] as TabItem).Content as Frame).Content as Page))
                    {
                        cb.SelectedIndex = -1;
                    }
                }
                else
                {
                    MethodPageTabControl.SelectedItem = e.RemovedItems[0];
                    ((MethodPageTabControl.SelectedItem as TabItem).Content as Frame).IsEnabled = false;
                    ((e.RemovedItems[0] as TabItem).Content as Frame).IsEnabled = true;
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// Create a TabItem to inject into the DisplayPane for the 
        /// type of page provided to the method.
        /// </summary>
        /// <param name="pageType">The page to create the tab for.</param>
        private void CreateMethodTabs(Type pageType)
        {
            Page methodPage = (Page)Activator.CreateInstance(pageType);
            Frame pageFrame = new Frame();
            TabItem tc = new TabItem();
            TextBlock headerBlock = new TextBlock();

            //Using TextBlock allows for text wrapping, 
            //to prevent the Tab Header from becoming too large.
            headerBlock.Text = methodPage.Title;
            headerBlock.MaxWidth = 150;
            headerBlock.TextWrapping = TextWrapping.Wrap;

            pageFrame.Margin = new Thickness(0, 10, 0, 10);
            pageFrame.Content = methodPage;
            pageFrame.IsEnabled = false;

            tc.Header = headerBlock;
            tc.Content = pageFrame;
            this.MethodPageTabControl.Items.Add(tc);
        }

        /// <summary>
        /// Find all of the Pages within the MethodSpecificPages namespace in this project.
        /// </summary>
        private void FindMethodPages()
        {
            var methodPages = from type in Assembly.GetExecutingAssembly().GetTypes()
                              where type.Namespace == MethodPageNamespace && type.IsSubclassOf(typeof(Page))
                              select type;
            methodPages.ToList().ForEach(page => CreateMethodTabs(page));
        }

        /// <summary>
        /// Search through a UI element that has child controls, 
        /// returning the items that match the type provided in 
        /// the method call.
        /// </summary>
        /// <typeparam name="T">The type to search for.</typeparam>
        /// <param name="depObj">The UI element to search through</param>
        /// <returns>IEnumerable of type T.</returns>
        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}
