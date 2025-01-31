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
        public List<int> fontSizes { get; set; } = new List<int>();
        public int size { get; set; } = 12;
        public FontStyle Style { get; set; } = FontStyles.Normal;
        public FontWeight Weight { get; set; } = FontWeights.Normal;
        public FormatText()
        {
            InitializeComponent();
            for (int i = 6; i < 40; i += 2) { 
            fontSizes.Add(i);
            }
            DataContext = this;
        }

        private void ConfirmChoices(object sender, RoutedEventArgs e)
        {
            size = (int)listView.SelectedItem;
            sampleText.FontSize = size;
            switch (styleComboBox.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    Weight = FontWeights.Bold;
                    Style = FontStyles.Normal;
                    break;
                case 2:
                    Weight = FontWeights.Normal;
                    Style = FontStyles.Italic;
                    break;
                case 3:
                    Weight = FontWeights.Bold;
                    Style = FontStyles.Italic;
                    break;
                default:
                    break;
            }   
            sampleText.FontWeight = Weight;
            sampleText.FontStyle = Style;
        }
    }
}
