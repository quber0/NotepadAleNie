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
    /// Logika interakcji dla klasy FormatText.xaml
    /// </summary>
    public partial class FormatText : Window
    {
        public List<int> fontSizes = [];
        public FormatText()
        {
            InitializeComponent();
            DataContext = this;
            for (int i = 6; i < 40; i += 2) { 
            fontSizes.Add(i);
            }
        }
    }
}
