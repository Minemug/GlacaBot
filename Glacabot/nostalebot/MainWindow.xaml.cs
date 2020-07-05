using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace nostalebot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {       
        [DllImportAttribute("User32.dll")]
        private static extern int FindWindow(String ClassName, String WindowName);
        [DllImportAttribute("User32.dll")]
        private static extern IntPtr SetForegroundWindow(int hWnd);
        public MainWindow()
        {
            InitializeComponent();         
        }

        Methods Checkers = new Methods();

        bool work = true;

        private void ClickScanButton(object sender, RoutedEventArgs e)
        {
            var Intervaltime = InputBox.Text;
            bool success = Int32.TryParse(Intervaltime, out int time);
            if (success == false)
            {
                MessageBox.Show("Nie wprowadziles interwału");
                work = false;
            } 
                               
            while (work == true)
            {                
                Bitmap screenshot = Screenshot();
                Screenshot();
                //screenshot.Save("C:/tmp/test.jpeg", ImageFormat.Jpeg);
                Checkers.CheckPercantage(screenshot);
                Checkers.CheckIfRaid(screenshot);
                Thread.Sleep(time * 60 * 1000);
            }
        }




        /// <summary>
        /// takes the screenshot
        /// </summary>
        /// <returns></returns>
        private Bitmap Screenshot()
        {
            int hWnd = FindWindow(null, "NosTale");
            //System.Windows.MessageBox.Show($"{ hWnd}");
            if (hWnd == 0)
            {
                MessageBox.Show("Nie znalazłem NosTale");
                work = false;
                
            }
            SetForegroundWindow(hWnd);
            Thread.Sleep(500);            
            Bitmap bmpScreeenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            var g = Graphics.FromImage(bmpScreeenshot);

            g.CopyFromScreen(877, 967, 877, 967, Screen.PrimaryScreen.Bounds.Size);

           
            return bmpScreeenshot;

        }
    }
}
