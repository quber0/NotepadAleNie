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
using System.Windows.Shapes;

namespace notepadAleNie
{
    /// <summary>
    /// Logika interakcji dla klasy CustomColor.xaml
    /// </summary>
    public partial class CustomColor : Window
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public CustomColor()
        {

            InitializeComponent();
        }

        private void ConfirmCustomColors_Btn(object sender, RoutedEventArgs e)
        {
            if (!byte.TryParse(rValue.Text, out byte r)) ChooseCorrectColor();
            else {
                R = r;
                Close();
            } 
            if (!byte.TryParse(gValue.Text, out byte g)) ChooseCorrectColor();
            else {
                G = g;
                Close();
            }
            if (!byte.TryParse(bValue.Text, out byte b)) ChooseCorrectColor();
            else {
                B = b;
                Close();
            }
        }
        private void ChooseCorrectColor()
        {
            MessageBox.Show("Choose a correct number from 0 to 255");
        }
    }
}
