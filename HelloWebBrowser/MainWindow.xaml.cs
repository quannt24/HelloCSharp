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
using CefSharp;

namespace HelloWebBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void onBrowserInitializedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            string html = "<iframe width=\"600\" height=\"450\" frameborder=\"0\" style=\"border:0\" src =\"https://www.google.com/maps/embed/v1/view?key=AIzaSyAtIxzCotopiEDOuwTDTID77u2x9zcjPWk&maptype=satellite&center=21.009347,105.824407&zoom=18\"/>";
            chromiumWebBrowser.LoadHtml(html);
        }

        private void canvasOnDragOver(object sender, DragEventArgs e)
        {
            Console.WriteLine("canvasOnDragOver");
            //chromiumWebBrowser.RaiseEvent(e);
        }

        private void canvasOnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("canvasOnMouseDown");
            //chromiumWebBrowser.RaiseEvent(e);
        }

        private void canvasOnMouseMove(object sender, MouseEventArgs e)
        {
            Console.WriteLine("canvasOnMouseMove");
            //chromiumWebBrowser.RaiseEvent(e);
        }

        private void canvasOnMouseUp(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("canvasOnMouseUp");
            //chromiumWebBrowser.RaiseEvent(e);
        }

        private void recOnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("recOnMouseDown");
        }
    }
}
