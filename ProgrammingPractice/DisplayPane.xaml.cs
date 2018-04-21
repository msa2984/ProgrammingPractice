using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        }

        /// <summary>
        /// Find all of the Pages within the MethodSpecificPages namespace in this project.
        /// </summary>
        public void FindMethodPages()
        {
            var methodPages = from type in Assembly.GetExecutingAssembly().GetTypes()
                              where type.IsClass && type.Namespace == MethodPageNamespace
                              select type;
            methodPages.ToList().ForEach(page => CreateMethodTabs(page));
        }

        /// <summary>
        /// Create a TabItem to inject into the DisplayPane for the 
        /// type of page provided to the method.
        /// </summary>
        /// <param name="pageType">The page to create the tab for.</param>
        public void CreateMethodTabs(Type pageType)
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

            tc.Header = headerBlock;
            tc.Content = pageFrame;
            this.MethodPageTabControl.Items.Add(tc);
        }

        /// <summary>
        /// Event Handler for when the "About" Button is selected from Toolbar.
        /// </summary>
        /// <param name="sender">Reference to the control (About Button) that raised this event./param>
        /// <param name="e">The data for the event raised.</param>
        public void About_Click(Object sender, EventArgs e)
        {
            MessageBox.Show("This UI allows for the execution of a compilation of programming problems.\nThe code can be found at: ", WindowCaption);
        }

    }
}
